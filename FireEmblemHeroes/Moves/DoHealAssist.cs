namespace FireEmblemHeroes
{
  public class DoHealAssist : DoAssist<HealingAssistSkill>
  {
    public DoHealAssist(HealingAssistSkill skill, HeroState owner, HeroState target, MapState map) 
      : base(skill, owner, target, map)
    {
    }
  }
}