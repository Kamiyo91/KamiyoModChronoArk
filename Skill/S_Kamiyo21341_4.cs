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
            KamiyoUtil.GetBuff<B_KamiyoCounterDraw21431>(BChar, nameof(B_KamiyoCounterDraw21431))?.GainStack();
        }
    }
}