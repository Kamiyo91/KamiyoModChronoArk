using System.Linq;

namespace KamiyoMod
{
    /// <summary>
    ///     Focus
    /// </summary>
    public class S_Kamiyo21341_6 : Skill_Extended, IP_PlayerTurn, IP_SkillCastingStart, IP_SkillUse_Target
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
                var buff = BChar.BuffAdd("B_KamiyoCounterMana21431", BChar) as B_KamiyoCounterMana21431;
                buff?.GainStack();
            }
            else
            {
                var buff = BChar.Buffs.FirstOrDefault(x => x is B_KamiyoCounterMana21431) as B_KamiyoCounterMana21431;
                buff?.GainStack();
            }
        }
        public void AttackEffect(BattleChar hit, SkillParticle SP, int DMG, bool Cri)
        {
            if (!BChar.BuffFind("B_KamiyoCounterDraw21431")) return;
            var buff = BChar.Buffs.FirstOrDefault(x => x is B_KamiyoCounterDraw21431) as B_KamiyoCounterDraw21431;
            buff?.SubStack();
        }
    }
}