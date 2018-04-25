using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireEmblemHeroes
{
  public interface IWeapon
  {
    int Might { get; }
    int Range { get; }
    WeaponType Type { get; }
    string Name { get; }
  }
}
