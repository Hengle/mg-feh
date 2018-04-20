using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireEmblemHeroes
{
  public class DrawBack : BaseMovementAssistSkill
  {
    public override IEnumerable<IMove> ValidMovesFor(MapCellLocation location, HeroState owner, HeroState target, MapState map)
    {
      // can the target move to the cell we're on?
      if (map.CanMoveTo(target, location, out MapCellState currentCell))
      {
        yield break;
      }

      // if the target can move to my position, I need to be able to move
      // in the same direction to the next cell
      var (dr, dc) = MapCellLocation.Diff(location, target.Location);
      (int r, int c) = location;
      if (map.CanMoveTo(owner, (r + dr, c + dc), out MapCellState desiredCell))
      {
        var moveTargetBack = new MoveHeroTo(target, 1, currentCell, map);
        var moveMeBack = new MoveHeroTo(owner, 1, desiredCell, map);
        yield return new AggregateMove(moveMeBack, moveTargetBack);
      }
    }
  }
}
