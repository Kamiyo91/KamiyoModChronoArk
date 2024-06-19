namespace KamiyoMod
{
    /// <summary>
    ///     Evade Up
    ///     Increase Evasion Rate
    /// </summary>
    public class B_KamiyoEvadeUp_21341 : Buff, IP_Dodge
    {
        public void Dodge(BattleChar Char, SkillParticle SP)
        {
            if (Char != BChar) return;
            BattleSystem.instance.AllyTeam.Draw(1);
        }

        public override void BuffStat()
        {
            PlusStat.dod = 10f;
        }
    }
}