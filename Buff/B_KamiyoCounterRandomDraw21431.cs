using System.Collections.Generic;
using System.Linq;
using _1ChronoArkKamiyoUtil;
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
            var castingSkill = KamiyoUtil.GetCastingSkill<S_Kamiyo21341_9>(Char);
            if (castingSkill == null) return;
            KamiyoUtil.DrawCharacterSkill(BChar,
                KamiyoUtil.PrepareRandomSkill(BChar, SkillKeys,
                    new KamiyoSkillChangeParameters(ap: -99, autoDelete: 2)));
            KamiyoUtil.Counter(BChar, castingSkill, false, false);
            SubStack();
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
    }
}