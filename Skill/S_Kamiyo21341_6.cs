using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace KamiyoMod
{
    /// <summary>
    ///     Focus
    /// </summary>
    public class S_Kamiyo21341_6 : Skill_Extended, IP_TargetedAlly
    {
        private bool usedInHand;

        public IEnumerator Targeted(BattleChar Attacker, List<BattleChar> SaveTargets, Skill skill)
        {
            if (usedInHand) return null;
            foreach (var _ in BattleSystem.instance.CastSkills.Where(castingSkill =>
                         MySkill == castingSkill.skill && castingSkill.Target == Attacker))
            {
                BChar.BuffAdd("B_KamiyoCounterMana21431", BChar, true);
                usedInHand = true;
                var flag = SaveTargets.Any(t => t == BChar);
                if (flag) continue;
                for (var j = 0; j < SaveTargets.Count; j++)
                {
                    if (SaveTargets[j] == BChar) continue;
                    SaveTargets[j] = BChar;
                    return null;
                }
            }

            foreach (var _ in BattleSystem.instance.SaveSkill.Where(castingSkill2 =>
                         MySkill == castingSkill2.skill && castingSkill2.Target == Attacker))
            {
                BChar.BuffAdd("B_KamiyoCounterMana21431", BChar, true);
                usedInHand = true;
                var flag2 = SaveTargets.Any(t => t == BChar);
                if (flag2) continue;
                for (var l = 0; l < SaveTargets.Count; l++)
                {
                    if (SaveTargets[l] == BChar) continue;
                    SaveTargets[l] = BChar;
                    return null;
                }
            }

            return null;
        }

        public override void SkillUseHand(BattleChar Target)
        {
            usedInHand = false;
        }
    }
}