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
  }
}
