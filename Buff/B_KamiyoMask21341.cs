using System.Linq;
using UnityEngine;

namespace KamiyoMod
{
    /// <summary>
    ///     Mask of Perception
    ///     Gain 20% Lifesteal on attacks. Attacking enemies with 1 Action point will make you draw 1 Skill.
    /// </summary>
    public class B_KamiyoMask21341 : Buff, IP_SkillUse_Target
    {
        public void AttackEffect(BattleChar hit, SkillParticle SP, int DMG, bool Cri)
        {
            if (DMG > 0)
            {
                var healAmount = Misc.PerToNum(DMG, 10f);
                if (healAmount >= 1) BChar.Heal(BChar, healAmount, false);
            }

            if (!(hit is BattleEnemy battleEnemy)) return;
            if (battleEnemy.SkillQueue.Count == 0 ||
                (battleEnemy.SkillQueue[0].CastSpeed != 0 && battleEnemy.SkillQueue[0].CastSpeed != 1)) return;
            var skillList = BattleSystem.instance.AllyTeam.Skills_Deck.Where(x => x.Master == BChar).ToList();
            var skill = skillList[Random.Range(0, skillList.Count)];
            if (skill != null) BattleSystem.instance.AllyTeam.Draw(skill);
            else BattleSystem.instance.AllyTeam.Draw(1);
        }
    }
}