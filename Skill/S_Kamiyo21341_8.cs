using System.Collections.Generic;
using _1ChronoArkKamiyoUtil;

namespace KamiyoMod
{
    /// <summary>
    ///     Combat Stance
    /// </summary>
    public class S_Kamiyo21341_8 : Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            BattleSystem.instance.AllyTeam.Draw(1);
            BChar.AddShieldValue(nameof(B_KamiyoShield_21341), (int)(BChar.GetStat.maxhp * 0.10f));
        }
    }
}