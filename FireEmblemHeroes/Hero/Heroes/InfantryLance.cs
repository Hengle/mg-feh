using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireEmblemHeroes
{
  public class InfantryLance : Hero
  {
    public override HeroMovementType Movement => HeroMovementType.Infantry;
    public override HeroColor Color => HeroColor.Blue;
  }
}
