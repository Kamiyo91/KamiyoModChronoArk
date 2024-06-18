using System.Collections.Generic;
using _1ChronoArkKamiyoUtil;

namespace KamiyoMod
{
    /// <summary>
    ///     Mask of Perception
    /// </summary>
    public class S_Kamiyo21341_5 : Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            BattleSystem.instance.AllyTeam.AP += 3;
            BattleSystem.instance.AllyTeam.Draw(2);
            KamiyoUtil.IncreaseEnemyActionCountByValue(1);
        }
    }
}