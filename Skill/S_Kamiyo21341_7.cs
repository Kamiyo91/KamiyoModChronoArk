using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KamiyoMod
{
    /// <summary>
    ///     Energy Release
    /// </summary>
    public class S_Kamiyo21341_7 : Skill_Extended, IP_Dodge
    {
        private int _dodgeCount;

        public void Dodge(BattleChar Char, SkillParticle SP)
        {
            if (Char != BChar) return;
            _dodgeCount++;
            _dodgeCount = Mathf.Clamp(_dodgeCount, 0, 5);
            SkillBasePlus.Target_BaseDMG += 2;
            SkillBasePlus.Target_BaseDMG = Mathf.Clamp(SkillBasePlus.Target_BaseDMG, 0, 10);
        }

        public override void Init()
        {
            base.Init();
            OnePassive = true;
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", (_dodgeCount + 1).ToString())
                .Replace("&b", SkillBasePlus.Target_BaseDMG.ToString());
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            if (Targets[0] == null) return;
            for (var i = 0; i < _dodgeCount; i++)
            {
                if (Targets[0].IsDead) return;
                var skill = Skill.TempSkill("S_Kamiyo21341_7_0", BChar, BChar.MyTeam);
                skill.isExcept = true;
                var ex = new Extended_Kamiyo_0();
                ex.SetAdditionalDamage(SkillBasePlus.Target_BaseDMG);
                skill.ExtendedAdd(ex);
                BattleSystem.DelayInput(PassiveAttack(skill, Targets[0]));
            }
        }

        public IEnumerator PassiveAttack(Skill skill, BattleChar target)
        {
            yield return new WaitForSeconds(0f);
            if (BattleSystem.instance.EnemyList.Count != 0)
                yield return BattleSystem.instance.ForceAction(skill, target, false, false, true);
        }
    }
}