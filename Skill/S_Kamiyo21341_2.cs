using System.Collections.Generic;

namespace KamiyoMod
{
    /// <summary>
    ///     Charged Horizontal Slash
    ///     Recover 1 Mana for each enemy killed. If this skill attack a single enemy, it deal 10 additional damage
    /// </summary>
    public class S_Kamiyo21341_2 : Skill_Extended, IP_Kill
    {
        public void KillEffect(SkillParticle SP)
        {
            BattleSystem.instance.AllyTeam.AP += 1;
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            SkillBasePlus.Target_BaseDMG = 0;
            if (Targets.Count == 1) SkillBasePlus.Target_BaseDMG = 10;
        }
    }
}