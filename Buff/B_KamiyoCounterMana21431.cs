using System.Linq;
using _1ChronoArkKamiyoUtil;
using UnityEngine;

namespace KamiyoMod
{
    public class B_KamiyoCounterMana21431 : Buff, IP_Dodge, IP_SkillUse_Target
    {
        private int _stack;

        public void Dodge(BattleChar Char, SkillParticle SP)
        {
            if (_stack == 0 || Char != BChar || SP.UseStatus.Info.Ally == BChar.Info.Ally) return;
            var castingSkill = Char.GetCastingSkill<S_Kamiyo21341_6>();
            KamiyoUtil.Counter(SP.UseStatus, castingSkill, false, true);
            SubStack();
        }

        public void AttackEffect(BattleChar hit, SkillParticle SP, int DMG, bool Cri)
        {
            if (SP.SkillData.AllExtendeds.Any(x => x is S_Kamiyo21341_6)) SubStack();
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