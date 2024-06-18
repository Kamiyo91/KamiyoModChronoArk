using System.Collections.Generic;
using _1ChronoArkKamiyoUtil;

namespace KamiyoMod
{
    /// <summary>
    ///     Rest
    /// </summary>
    public class S_Kamiyo21341_9 : Skill_Extended, IP_SkillCastingStart
    {
        public void SkillCasting(CastingSkill ThisSkill)
        {
            BChar.Heal(BChar, 2f, false, true);
            KamiyoUtil.AddShieldValue(BChar, nameof(B_KamiyoShield_21341), (int)(BChar.GetStat.maxhp * 0.20f));
            KamiyoUtil.GetBuff<B_KamiyoCounterRandomDraw21431>(BChar, nameof(B_KamiyoCounterRandomDraw21431))
                ?.GainStack();
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            KamiyoUtil.AddShieldValue(BChar, nameof(B_KamiyoShield_21341), (int)(BChar.GetStat.maxhp * 0.20f));
        }
    }
}