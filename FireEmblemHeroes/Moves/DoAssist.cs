using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireEmblemHeroes
{
  public abstract class DoAssist<T> : IMove where T : AssistSkill
  {
    protected readonly T _skill;
    protected readonly HeroState _owner;
    protected readonly HeroState _target;
    protected readonly MapState _map;

    public DoAssist(T skill, HeroState owner, HeroState target, MapState map)
    {
      _skill = skill;
      _owner = owner;
      _target = target;
      _map = map;
    }
  }
}
