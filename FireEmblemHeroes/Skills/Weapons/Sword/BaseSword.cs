using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireEmblemHeroes
{
  public abstract class BaseSword : Weapon
  {
    public override int Range => 1;
    public override WeaponColor Color => WeaponColor.Red;
    public override WeaponType Type => WeaponType.Sword;
  }
}
