using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireEmblemHeroes
{
  public abstract class BaseRedTome : BaseTome
  {
    public override WeaponColor Color => WeaponColor.Red;
  }
}
