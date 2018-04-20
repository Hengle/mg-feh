using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireEmblemHeroes
{
  public class HeroState
  {
    public HeroState(int teamId, Hero hero, MapCellLocation location)
    {
      TeamId = teamId;
      Hero = hero;
      Location = location;
    }

    public int TeamId { get; }
    public Hero Hero { get; }
    public HeroStats CurrentStats;

    public MapCellLocation Location { get; }

    public bool IsInfantry => Hero.Movement == HeroMovementType.Infantry;
    public bool IsCavalry => Hero.Movement == HeroMovementType.Cavalry;
    public bool IsFlying => Hero.Movement == HeroMovementType.Flying;

    public bool NeedsHealing => CurrentStats.HP < Hero.BaseStats.HP;
  }
}
