using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireEmblemHeroes
{
  public abstract class BaseBreath : Weapon<WCBreath>
  {
    public override WeaponType Type => WeaponType.Dragon;
    public override int Range => 1;
  }
}
