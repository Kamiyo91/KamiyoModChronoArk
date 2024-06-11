using System.Collections;
using System.Linq;
using UnityEngine;

namespace KamiyoMod
{
    public class B_KamiyoCounterMana21431 : Buff, IP_Dodge, IP_SkillUse_Target
    {
        private int _stack;

        public void Dodge(BattleChar Char, SkillParticle SP)
        {
            if (_stack == 0 || Char != BChar || SP.UseStatus.Info.Ally == BChar.Info.Ally) return;
            foreach (var castingSkill in BattleSystem.instance.CastSkills.Where(castingSkill =>
                         castingSkill.Usestate == BChar))
            {
                Counter(SP.UseStatus, SP, castingSkill);
                return;
            }
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

        public void Counter(BattleChar target, SkillParticle SP, CastingSkill CastingSkill)
        {
            BattleSystem.instance.AllyTeam.AP += 1;
            switch (target.Info.Ally)
            {
                case true:
                    BattleSystem.instance.ActWindow.CastingWaste(CastingSkill.skill);
                    return;
                case false when !target.IsDead:
                    CastingSkill.Target = target;
                    BattleSystem.DelayInput(Counter(CastingSkill));
                    BattleSystem.DelayInputAfter(StrengthOff());
                    break;
            }
        }

        public IEnumerator Counter(CastingSkill CastingSkill)
        {
            yield return BattleSystem.instance.StartCoroutine(
                BattleSystem.instance.AllyCastingSkillUse(CastingSkill, false));
            BattleSystem.instance.CastSkills.Remove(CastingSkill);
            BattleSystem.instance.SaveSkill.Remove(CastingSkill);
            PlusStat.Strength = false;
            yield return null;
        }

        public IEnumerator StrengthOff()
        {
            PlusStat.Strength = false;
            PlusStat.def = 0f;
            yield return null;
        }
    }
}