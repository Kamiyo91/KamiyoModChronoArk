using System.Collections.Generic;
using System.Linq;

namespace KamiyoMod
{
    /// <summary>
    ///     Focus
    /// </summary>
    public class S_Kamiyo21341_6 : Skill_Extended, IP_Targeted, IP_PlayerTurn
    {
        public void Turn()
        {
            var battleCard = BattleSystem.instance.AllyList.FirstOrDefault(x => x == BChar)?.MyBasicSkill.buttonData;
            var skill = battleCard?.ExtendedFind<S_Kamiyo21341_6>();
            if (skill == null) return;
            skill.NotCount = true;
            skill.APChange = -2;
        }

        public void Targeted(Skill SkillD, List<BattleChar> Targets)
        {
            foreach (var _ in BattleSystem.instance.CastSkills.Where(castingSkill =>
                         MySkill.OriginalSelectSkill == castingSkill.skill.OriginalSelectSkill))
                BChar.BuffAdd("B_KamiyoCounterMana21431", BChar);
        }
    }
}