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
            BChar.AddShieldValue(nameof(B_KamiyoShield_21341), (int)(BChar.GetStat.maxhp * 0.20f));
            BChar.GetBuff<B_KamiyoCounterRandomDraw21431>(nameof(B_KamiyoCounterRandomDraw21431), true)?.GainStack();
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            BChar.AddShieldValue(nameof(B_KamiyoShield_21341), (int)(BChar.GetStat.maxhp * 0.20f));
        }
    }
}