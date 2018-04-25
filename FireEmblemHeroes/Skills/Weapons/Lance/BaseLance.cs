using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireEmblemHeroes
{
  public abstract class BaseLance<T> : Weapon<T> where T : WeaponColor, new()
  {
    public override WeaponType Type => WeaponType.Lance;
    public override int Range => 1;
  }
}
