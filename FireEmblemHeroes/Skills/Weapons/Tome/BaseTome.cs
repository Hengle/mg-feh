using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireEmblemHeroes
{
  public abstract class BaseTome : Weapon
  {
    public override int Range => 2;
    public override WeaponType Type => WeaponType.Tome;
  }
}
