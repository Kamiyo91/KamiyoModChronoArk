using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace KamiyoMod
{
    /// <summary>
    ///     Focus
    /// </summary>
    public class S_Kamiyo21341_4 : Skill_Extended, IP_Targeted
    {
        public void Targeted(Skill SkillD, List<BattleChar> Targets)
        {
            foreach (var _ in BattleSystem.instance.CastSkills.Where(castingSkill =>
                         MySkill.OriginalSelectSkill  == castingSkill.skill.OriginalSelectSkill))
            {
                BChar.BuffAdd("B_KamiyoCounterDraw21431", BChar);
            }
        }
    }
}