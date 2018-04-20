using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireEmblemHeroes
{
  public class Swap : BaseMovementAssistSkill
  {
    public override IEnumerable<IMove> ValidMovesFor(MapCellLocation location, HeroState owner, HeroState target, MapState map)
    {
      // can the owner move to the target's position?
      if (!map.CanMoveTo(owner, target.Location, out MapCellState targetCell))
      {
        yield break;
      }

      // can the target move to the owner's position?
      if (!map.CanMoveTo(target, location, out MapCellState ownerCell))
      {
        yield break;
      }

      // the swap can be done!
      var moveOwnerToTarget = new MoveHeroTo(owner, 1, targetCell, map);
      var moveTargetToOwner = new MoveHeroTo(target, 1, ownerCell, map);
      yield return new AggregateMove(moveOwnerToTarget, moveTargetToOwner);
    }
  }
}
