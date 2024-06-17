namespace KamiyoMod
{
    /// <summary>
    ///     Evade Up
    ///     Increase Evasion Rate
    /// </summary>
    public class B_KamiyoEvadeUp_21341 : Buff
    {
        public override void BuffStat()
        {
            PlusStat.dod = 10f;
        }
    }
}