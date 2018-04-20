using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireEmblemHeroes
{
  public abstract class Hero
  {
    public abstract HeroMovementType Movement { get; }

    public HeroStats BaseStats;

    public Weapon Weapon;
    public AssistSkill Assist;
    public SpecialSkill Special;

    public PassiveSkill A;
    public PassiveSkill B;
    public PassiveSkill C;
    public PassiveSkill S;

    public decimal SP;
    public decimal HM;
  }
}
