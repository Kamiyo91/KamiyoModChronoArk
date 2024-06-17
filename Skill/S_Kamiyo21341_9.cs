using System.Linq;

namespace KamiyoMod
{
    /// <summary>
    ///     Rest
    /// </summary>
    public class S_Kamiyo21341_9 : Skill_Extended, IP_SkillCastingStart
    {
        public void SkillCasting(CastingSkill ThisSkill)
        {
            BChar.Heal(BChar, 2f, false, true);
            BChar.BuffAdd("B_KamiyoShield_21341", BChar);
            BChar.BuffReturn("B_KamiyoShield_21341").BarrierHP += (int)(BChar.GetStat.maxhp * 0.20f);
            if (!BChar.BuffFind("B_KamiyoCounterRandomDraw21431"))
            {
                var buff =
                    BChar.BuffAdd("B_KamiyoCounterRandomDraw21431", BChar, true) as B_KamiyoCounterRandomDraw21431;
                buff?.GainStack();
            }
            else
            {
                var buff =
                    BChar.Buffs.FirstOrDefault(x => x is B_KamiyoCounterRandomDraw21431) as
                        B_KamiyoCounterRandomDraw21431;
                buff?.GainStack();
            }
        }
    }
}