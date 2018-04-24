using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireEmblemHeroes
{
  public abstract class BaseBreath : Weapon
  {
    public override WeaponType Type => WeaponType.Dragon;
    public override WeaponColor Color => WeaponColor.Breath;
  }
}
