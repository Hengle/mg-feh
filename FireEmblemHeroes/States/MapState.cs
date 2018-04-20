using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireEmblemHeroes
{
  public class MapState
  {
    public delegate bool CanTraverseDelegate(MapCellState cell, int depth, int distance);

    static readonly Dictionary<Direction, (int dc, int dr)> DirectionMods = new Dictionary<Direction, (int dc, int dr)>
    {
      { Direction.West, (-1, 0) },
      { Direction.North, (0, -1) },
      { Direction.East, (1, 0) },
      { Direction.South, (0, 1) },
    };

    static readonly Dictionary<HeroMovementType, int> MovesPerMovementType = new Dictionary<HeroMovementType, int>
    {
      { HeroMovementType.Armored, 1 },
      { HeroMovementType.Cavalry, 3 },
      { HeroMovementType.Flying, 2 },
      { HeroMovementType.Infantry, 2 },
    };

    private MapCellState[,] _cells;
    private HeroState[] _heroes;

    public MapState()
    {

    }

    public IMove[] GetMoves(HeroState hero)
    {
      return CalculateAllMovesFor(hero).ToArray();
    }

    private IEnumerable<IMove> CalculateAllMovesFor(HeroState hero)
    {
      // from the current position, can we use any skills?
      foreach (var initialUseSkill in CalculateAllSkillMoves(hero.Location, hero))
      {
        yield return initialUseSkill;
      }

      // in addition to using skills, we can also move!
      var moves = MovesPerMovementType[hero.Hero.Movement];
      foreach (var n in Neighbors(hero.Location, moves, CanTraverse))
      {
        var (cell, depth, distance) = n;

        // can the hero move there?
        if (!CanMoveTo(hero, cell))
        {
          continue;
        }

        // the hero can move here, so add it to the moves
        var moveTo = new MoveHeroTo(hero, distance, cell, this);
        yield return moveTo;

        // can we use any of our skills from this position?
        foreach (var useSkill in CalculateAllSkillMoves(cell.Location, hero))
        {
          yield return new AggregateMove(moveTo, useSkill);
        }
      }

      bool CanTraverse(MapCellState cell, int depth, int distance)
      {
        // if an infantry is moving to a forest cell then this is the only move it can make
        if (cell.IsForest && hero.IsInfantry)
        {
          return false;
        }

        // if a cavalry is moving to a trench cell, then this is the only move it can make
        if (cell.IsTrench && hero.IsCavalry)
        {
          return false;
        }

        return true;
      }
    }

    private IEnumerable<IMove> CalculateAllSkillMoves(MapCellLocation location, HeroState hero)
    {
      // from the hero's current position, can we use a weapon?
      foreach (var useWeapon in CalculateAllWeaponMoves(location, hero))
      {
        yield return useWeapon;
      }

      // from the hero's current position, can we use an assist skill?
      foreach (var useAssist in CalculateAllAssistMoves(location, hero))
      {
        yield return useAssist;
      }
    }

    private IEnumerable<IMove> CalculateAllWeaponMoves(MapCellLocation location, HeroState owner)
    {
      var weapon = owner.Hero.Weapon;
      if (weapon == null)
      {
        yield break;
      }

      foreach (var (cell, depth, distance) in Neighbors(location, weapon.Range))
      {
        if (distance == weapon.Range)
        {
          // if cell is breakable and hasn't been broken yet, we can attack it
          if (cell.IsBreakable && !cell.IsBroken)
          {
            yield return new BreakWall(owner, cell);
          }

          // if there is no unit in range, then there is nothing more to be done
          var target = _heroes.SingleOrDefault(h => h.Location.Equals(cell.Location));
          if (target == null)
          {
            continue;
          }

          // there is a unit in range! If the unit is on the other team, then we can attack them
          if (target.TeamId != owner.TeamId)
          {
            yield return new InitateAttack(owner, target);
          }
        }
      }
    }

    private IEnumerable<IMove> CalculateAllAssistMoves(MapCellLocation location, HeroState owner)
    {
      var assist = owner.Hero.Assist;
      if (assist == null)
      {
        yield break;
      }

      foreach (var (cell, depth, distance) in Neighbors(location, assist.Range))
      {
        if (distance == assist.Range)
        {
          // if there is no unit in range, then there is nothing more to be done
          var target = _heroes.SingleOrDefault(h => h.Location.Equals(cell.Location));
          if (target == null)
          {
            continue;
          }

          // if the assist is team only, then the target and hero must be on
          // the same team
          if (assist.TeamOnly && owner.TeamId != target.TeamId)
          {
            continue;
          }

          // there is a unit in range. Can the assist even be used?
          var moves = assist.ValidMovesFor(location, owner, target, this);
          foreach (var move in moves)
          {
            yield return move;
          }
        }
      }
    }

    public bool TryGet(int r, int c, out MapCellState cell)
    {
      cell = null;
      if (!Contains(r, c))
      {
        return false;
      }

      cell = _cells[r, c];
      return true;

      bool Contains(int row, int col)
      {
        var ur = (uint)row;
        var uc = (uint)col;

        var rows = (uint)_cells.GetLength(0);
        var cols = (uint)_cells.GetLength(1);

        return (ur < rows) && (uc < cols);
      }
    }

    public IEnumerable<(MapCellState cell, int depth, int distance)> Neighbors(MapCellLocation location, int maxDepth, CanTraverseDelegate traverse = null, int totalDistance = 1)
    {
      if (maxDepth <= 0)
      {
        yield break;
      }

      foreach (var kvp in DirectionMods)
      {
        var (dc, dr) = kvp.Value;
        (int r, int c) = location;
        r += dr;
        c += dc;

        // does the map contain the square?
        if (!TryGet(r, c, out MapCellState cell))
        {
          continue;
        }

        yield return (cell, maxDepth, totalDistance);

        if (traverse == null || traverse.Invoke(cell, maxDepth, totalDistance))
        {
          foreach (var value in Neighbors(cell.Location, maxDepth - 1, traverse, totalDistance + 1))
          {
            yield return value;
          }
        }
      }
    }

    public bool CanMoveTo(HeroState hero, MapCellLocation location, out MapCellState cell)
    {
      (int r, int c) = location;
      return CanMoveTo(hero, (r, c), out cell);
    }

    public bool CanMoveTo(HeroState hero, (int, int) location, out MapCellState cell)
    {
      var (r, c) = location;
      return TryGet(r, c, out cell) && CanMoveTo(hero, cell);
    }

    public bool CanMoveTo(HeroState hero, MapCellState cell)
    {
      // is there a hero already here?
      if (_heroes.Any(h => cell.Location.Equals(h.Location)))
      {
        return false;
      }

      // is there a wall here?
      if (cell.IsWall)
      {
        return false;
      }

      // if the unit is flying, then we're good. Flying units can move over
      // everything else
      if (hero.IsFlying)
      {
        return true;
      }

      // cavalry units cannot move through trees
      if (hero.IsCavalry && cell.IsForest)
      {
        return false;
      }

      // only flying units can move over water
      if (cell.IsWater)
      {
        return false;
      }

      // only flying units can move over mountains
      if (cell.IsMountains)
      {
        return false;
      }

      // only flying units can soar through the air
      if (cell.IsAir)
      {
        return false;
      }

      // otherwise; we can move here
      return true;
    }
  }
}
