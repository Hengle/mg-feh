using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireEmblemHeroes
{
  public abstract class Weapon
  {
    public abstract int Range { get; }
    public abstract WeaponColor Color { get; }
    public abstract WeaponType Type { get; }
  }
}
