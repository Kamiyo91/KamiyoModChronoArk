using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace KamiyoMod
{
    public class B_KamiyoCounterRandomDraw21431 : Buff, IP_Dodge, IP_SkillUse_User
    {
        private static readonly List<string> SkillKeys = new List<string>
            { "S_Kamiyo21341_1", "S_Kamiyo21341_2", "S_Kamiyo21341_4" };

        private int _stack;

        public void Dodge(BattleChar Char, SkillParticle SP)
        {
            if (_stack == 0 || Char != BChar || SP.UseStatus.Info.Ally == BChar.Info.Ally) return;
            var castingSkill = BattleSystem.instance.SaveSkill.FirstOrDefault(x =>
                x.Usestate == BChar && x.skill.AllExtendeds.Any(y => y is S_Kamiyo21341_9));
            if (castingSkill != null) ActivateSkillSpecialEffect(castingSkill);
        }

        public void SkillUse(Skill SkillD, List<BattleChar> Targets)
        {
            if (SkillD.AllExtendeds.Any(x => x is S_Kamiyo21341_9)) SubStack();
        }

        public void GainStack()
        {
            _stack++;
            _stack = Mathf.Clamp(_stack, 0, 99);
            PlusStat.PerfectDodge = true;
        }

        public void SubStack()
        {
            _stack--;
            _stack = Mathf.Clamp(_stack, 0, 99);
            if (_stack < 1) SelfDestroy();
        }

        public void ActivateSkillSpecialEffect(CastingSkill castingSkill)
        {
            var keyword = SkillKeys[Random.Range(0, SkillKeys.Count)];
            var skill = Skill.TempSkill(keyword, BChar, BChar.MyTeam);
            skill.AP = 0;
            skill.AutoDelete = 2;
            skill.isExcept = true;
            BChar.MyTeam.Add(skill.CloneSkill(), true);
            BattleSystem.instance.ActWindow.CastingWaste(castingSkill.skill);
            BattleSystem.instance.SaveSkill.Remove(castingSkill);
            SubStack();
        }
    }
}