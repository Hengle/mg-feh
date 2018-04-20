using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireEmblemHeroes
{
  public abstract class SpecialSkill
  {
    public abstract int Cost { get; }
    public abstract int Cooldown { get; }
  }
}
