using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireEmblemHeroes
{
  public class Smite : BaseMovementAssistSkill
  {
    public override IEnumerable<IMove> ValidMovesFor(MapCellLocation location, HeroState owner, HeroState target, MapState map)
    {
      var (dr, dc) = MapCellLocation.Diff(target.Location, location);
      (int r, int c) = target.Location;
      dr = Math.Sign(dr);
      dc = Math.Sign(dc);

      // can we push the target 2 spaces away?
      var distance = 2;
      if (!map.CanMoveTo(target, (r + dr + dr, c + dc + dc), out MapCellState cell))
      {
        // no? Can we push them one square away?
        distance = 1;
        if (!map.CanMoveTo(target, (r + dr, c + dc), out cell))
        {
          yield break;
        }
      }

      // we can push the target 2/1 squares away
      yield return new MoveHeroTo(target, distance, cell, map, true);
    }
  }
}
