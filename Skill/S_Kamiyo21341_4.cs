using _1ChronoArkKamiyoUtil;

namespace KamiyoMod
{
    /// <summary>
    ///     Focus
    /// </summary>
    public class S_Kamiyo21341_4 : Skill_Extended, IP_SkillCastingStart
    {
        public void SkillCasting(CastingSkill ThisSkill)
        {
            BChar.GetBuff<B_KamiyoCounterDraw21431>(nameof(B_KamiyoCounterDraw21431), true)?.GainStack();
            ThisSkill.Target.GetBuffTarget<B_Taunt>(BChar, nameof(B_Taunt));
        }
    }
}