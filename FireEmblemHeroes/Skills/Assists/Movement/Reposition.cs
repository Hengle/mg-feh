using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireEmblemHeroes
{
  public class Reposition : BaseMovementAssistSkill
  {
    public override IEnumerable<IMove> ValidMovesFor(MapCellLocation location, HeroState owner, HeroState target, MapState map)
    {
      var potentialPlaces = map.Neighbors(location, 1);
      foreach (var (cell, depth, distance) in potentialPlaces)
      {
        if (map.CanMoveTo(target, cell))
        {
          // we can reposition the target to this spot
          yield return new MoveHeroTo(target, 1, cell, map);
        }
      }
    }
  }
}
