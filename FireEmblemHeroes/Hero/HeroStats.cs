using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireEmblemHeroes
{
  public struct HeroStats
  {
    public decimal HP;
    public decimal Atk;
    public decimal Spd;
    public decimal Def;
    public decimal Res;

    public static implicit operator HeroStats((decimal hp, decimal atk, decimal spd, decimal def, decimal res) stats)
    {
      return new HeroStats
      {
        HP = stats.hp,
        Atk = stats.atk,
        Spd = stats.spd,
        Def = stats.def,
        Res = stats.res,
      };
    }
  }
}
