using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireEmblemHeroes
{
  public abstract class BaseLance : Weapon
  {
    public override int Range => 1;
    public override WeaponColor Color => WeaponColor.Blue;
    public override WeaponType Type => WeaponType.Lance;
  }
}
