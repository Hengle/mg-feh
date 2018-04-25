using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireEmblemHeroes
{
  public class Heal : IMove
  {
    private HealingAssistSkill _skill;
    private HeroState _owner;
    private HeroState _target;

    public Heal(HealingAssistSkill skill, HeroState owner, HeroState target)
    {
      _skill = skill;
      _owner = owner;
      _target = target;
    }

    void IMove.Do()
    {
      var (ownerAmount, targetAmount) = _skill.GetHealAmount(_owner, _target);
      _owner.CurrentStats.HP += ownerAmount;
      _target.CurrentStats.HP += targetAmount;
    }
  }
}
