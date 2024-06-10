using System.Linq;

namespace KamiyoMod
{
    /// <summary>
    ///     Lower Slash
    ///     If there is any skill from the user in the Cast List, the cost of this skill is reduced to 0
    /// </summary>
    public class S_Kamiyo21341_1 : Skill_Extended
    {
        public override void FixedUpdate()
        {
            MySkill.APChange = BattleSystem.instance.CastSkills.Any(x => x.skill.Master == MySkill.Master) ? -1 : 0;
        }
    }
}