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
      yield return new Heal(this, owner, target);
    }

    public abstract (decimal ownerAmount, decimal targetAmount) GetHealAmount(HeroState owner, HeroState target);
  }
}
