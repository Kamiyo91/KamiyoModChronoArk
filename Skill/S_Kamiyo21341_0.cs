using _1ChronoArkKamiyoUtil;

namespace KamiyoMod
{
    /// <summary>
    ///     Imminent Fight
    /// </summary>
    public class S_Kamiyo21341_0 : Skill_Extended, IP_SkillCastingStart
    {
        public void SkillCasting(CastingSkill ThisSkill)
        {
            ThisSkill.Target.GetBuffTarget<B_Taunt>(BChar, nameof(B_Taunt));
        }
    }
}