using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireEmblemHeroes
{
  public class Shove : BaseMovementAssistSkill
  {
    public override IEnumerable<IMove> ValidMovesFor(MapCellLocation location, HeroState owner, HeroState target, MapState map)
    {
      var (dr, dc) = MapCellLocation.Diff(target.Location, location);
      (int r, int c) = target.Location;
      dr = Math.Sign(dr);
      dc = Math.Sign(dc);

      // can we push the target 1 space away?
      if (map.CanMoveTo(target, (r + dr, c + dc), out MapCellState cell))
      {
        yield return new MoveHeroTo(target, 1, cell, map, true);
      }
    }
  }
}
