using System.Linq;

namespace KamiyoMod
{
    /// <summary>
    ///     Focus
    /// </summary>
    public class S_Kamiyo21341_4 : Skill_Extended, IP_SkillCastingStart
    {
        public void SkillCasting(CastingSkill ThisSkill)
        {
            if (!BChar.BuffFind("B_KamiyoCounterDraw21431"))
            {
                var buff = BChar.BuffAdd("B_KamiyoCounterDraw21431", BChar) as B_KamiyoCounterDraw21431;
                buff?.GainStack();
            }
            else
            {
                var buff = BChar.Buffs.FirstOrDefault(x => x is B_KamiyoCounterDraw21431) as B_KamiyoCounterDraw21431;
                buff?.GainStack();
            }
        }
    }
}