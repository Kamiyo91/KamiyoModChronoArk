using _1ChronoArkKamiyoUtil;

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
            BChar.GetBuff<B_KamiyoCounterMana_Ex21431>(nameof(B_KamiyoCounterMana_Ex21431), true)?.GainStack();
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