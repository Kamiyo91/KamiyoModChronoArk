namespace KamiyoMod
{
    public class Extended_Kamiyo_1 : Skill_Extended
    {
        public override bool TargetSelectExcept(BattleChar ExceptTarget)
        {
            return (BChar.Info.Passive as P_Kamiyo21341)?.CanAct() ?? true;
        }
    }
}