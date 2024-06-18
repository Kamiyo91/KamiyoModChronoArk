using System.Collections.Generic;
using _1ChronoArkKamiyoUtil;
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
                var ex = new Extended_Kamiyo_0();
                ex.SetAdditionalDamage(SkillBasePlus.Target_BaseDMG);
                KamiyoUtil.AdditionalAttack(BChar, Targets[0],
                    KamiyoUtil.PrepareSkill(BChar, "S_Kamiyo21341_7_0",
                        new KamiyoSkillChangeParameters(0, true, 0, 0, new List<Skill_Extended> { ex })), _dodgeCount);
            }
        }
    }
}