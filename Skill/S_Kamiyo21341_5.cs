using System.Collections.Generic;
using System.Linq;

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
            foreach (var enemy in BattleSystem.instance.EnemyTeam.GetAliveChars().Select(x => x as BattleEnemy))
            {
                if (enemy == null) continue;
                foreach (var skill in enemy.SkillQueue)
                    skill.CastSpeed += 1;
            }
        }
    }
}