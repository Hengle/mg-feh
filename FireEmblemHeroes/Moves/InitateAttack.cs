using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireEmblemHeroes
{
  public class InitateAttack : IMove
  {
    private HeroState _owner;
    private HeroState _target;

    public InitateAttack(HeroState owner, HeroState target)
    {
      _owner = owner;
      _target = target;
    }

    void IMove.Do()
    {
      var attack = _owner.CurrentStats.HP + _owner.Hero.Weapon.Might;
      attack -= _target.CurrentStats.Def;
      if (attack > 0)
      {
        _target.CurrentStats.HP -= attack;
        if (_target.CurrentStats.HP < 0)
        {
          _target.IsDead = true;
        }
      }
    }
  }
}
