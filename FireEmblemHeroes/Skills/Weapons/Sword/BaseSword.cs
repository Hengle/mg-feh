using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireEmblemHeroes
{
  public abstract class BaseSword<T> : Weapon<T> where T : WeaponColor, new()
  {
    public override WeaponType Type => WeaponType.Sword;
    public override int Range => 1;
  }
}
