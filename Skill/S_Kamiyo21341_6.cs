using System.Linq;
using UnityEngine;

namespace KamiyoMod
{
    /// <summary>
    ///     Focus
    /// </summary>
    public class S_Kamiyo21341_6 : Skill_Extended, IP_PlayerTurn, IP_SkillCastingStart
    {
        public void Turn()
        {
            var battleCard = BattleSystem.instance.AllyList.FirstOrDefault(x => x == BChar)?.MyBasicSkill.buttonData;
            var skill = battleCard?.ExtendedFind<S_Kamiyo21341_6>();
            if (skill == null) return;
            skill.NotCount = true;
            skill.APChange = -2;
        }

        public void SkillCasting(CastingSkill ThisSkill)
        {
            if (!BChar.BuffFind("B_KamiyoCounterMana21431"))
            {
                Debug.LogError("Add New Buff");
                var buff = BChar.BuffAdd("B_KamiyoCounterMana21431", BChar, true) as B_KamiyoCounterMana21431;
                buff?.GainStack();
            }
            else
            {
                var buff = BChar.Buffs.FirstOrDefault(x => x is B_KamiyoCounterMana21431) as B_KamiyoCounterMana21431;
                buff?.GainStack();
            }
        }
    }
}