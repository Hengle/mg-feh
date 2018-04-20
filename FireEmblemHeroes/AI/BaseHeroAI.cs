using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireEmblemHeroes
{
  public abstract class BaseHeroAI
  {
    public BaseHeroAI(HeroState owner)
    {
      Owner = owner;
    }

    public HeroState Owner { get; }

    public abstract IMove GetMove(MapState state);
  }
}
