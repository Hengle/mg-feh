using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireEmblemHeroes
{
  public abstract class BaseBlueTome : BaseTome
  {
    public override WeaponColor Color => WeaponColor.Blue;
  }
}
