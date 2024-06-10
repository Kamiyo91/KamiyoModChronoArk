using System.Collections.Generic;
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
            if (DMG == 0 || !(Misc.PerToNum(DMG, 20f) >= 1f)) return;
            BChar.Heal(BChar, Misc.PerToNum(DMG, 20f), false);
            if (!(hit is BattleEnemy battleEnemy)) return;
            if (battleEnemy.SkillQueue.Count == 0 ||
                (battleEnemy.SkillQueue[0].CastSpeed != 0 && battleEnemy.SkillQueue[0].CastSpeed != 1)) return;
            var skill = SelectOne(BattleSystem.instance.AllyTeam.Skills_Deck.Where(x => x.Master == BChar))
                .FirstOrDefault();
            if (skill != null) BattleSystem.instance.AllyTeam.Draw(skill);
            else BattleSystem.instance.AllyTeam.Draw(1);
        }
        public T SelectOne<T>(params T[] list)
        {
            return list[Random.Range(0, list.Length)];
        }

        public T SelectOne<T>(List<T> list)
        {
            return list[Random.Range(0, list.Count)];
        }
    }
}