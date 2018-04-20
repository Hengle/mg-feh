using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireEmblemHeroes
{
  public abstract class HealingAssistSkill : AssistSkill
  {
    public override IEnumerable<IMove> ValidMovesFor(MapCellLocation location, HeroState owner, HeroState target, MapState map)
    {
      yield return new DoHealAssist(this, owner, target, map);
    }
  }
}
