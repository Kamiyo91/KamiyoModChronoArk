using System.Linq;
using _1ChronoArkKamiyoUtil;

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
            BChar.GetBuff<B_KamiyoCounterMana21431>(nameof(B_KamiyoCounterMana21431), true)?.GainStack();
            ThisSkill.Target.GetBuffTarget<B_Taunt>(BChar, nameof(B_Taunt));
        }
    }
}