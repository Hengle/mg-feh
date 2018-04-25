using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireEmblemHeroes
{
  public abstract class Weapon<T> : IWeapon
    where T : WeaponColor, new()
  {
    public Weapon() => Color = new T();

    public T Color { get; }
    public abstract int Might { get; }
    public abstract int Range { get; }
    public abstract WeaponType Type { get; }
    public abstract string Name { get; }
  }
}
