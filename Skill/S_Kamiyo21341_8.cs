using System.Collections.Generic;

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
            BChar.BuffAdd("B_KamiyoShield_21341", BChar);
            BChar.BuffReturn("B_KamiyoShield_21341").BarrierHP += (int)(BChar.GetStat.maxhp * 0.10f);
        }
    }
}