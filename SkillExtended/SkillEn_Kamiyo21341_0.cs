using System.Linq;

namespace KamiyoMod
{
    /// <summary>
    ///     Focus
    ///     If attacked while this skill is in Countdown, dodge the attack,cast the skill on the attacker and restore 1 Mana.
    /// </summary>
    public class SkillEn_Kamiyo21341_0 : Skill_Extended, IP_SkillCastingStart
    {
        public void SkillCasting(CastingSkill ThisSkill)
        {
            if (!BChar.BuffFind("B_KamiyoCounterMana_Ex21431"))
            {
                var buff = BChar.BuffAdd("B_KamiyoCounterMana_Ex21431", BChar, true) as B_KamiyoCounterMana_Ex21431;
                buff?.GainStack();
            }
            else
            {
                var buff =
                    BChar.Buffs.FirstOrDefault(x => x is B_KamiyoCounterMana_Ex21431) as B_KamiyoCounterMana_Ex21431;
                buff?.GainStack();
            }
        }

        public override bool CanSkillEnforce(Skill MainSkill)
        {
            return !MainSkill.IsHeal;
        }

        public override void Init()
        {
            Counting += 2;
            CountingExtedned = true;
        }
    }
}