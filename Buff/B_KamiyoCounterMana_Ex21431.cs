using System.Collections;
using System.Linq;
using UnityEngine;

namespace KamiyoMod
{
    public class B_KamiyoCounterMana_Ex21431 : Buff, IP_Dodge, IP_SkillUse_Target
    {
        private int _stack;

        public void Dodge(BattleChar Char, SkillParticle SP)
        {
            if (_stack == 0 || Char != BChar || SP.UseStatus.Info.Ally == BChar.Info.Ally) return;
            var castingSkill = BattleSystem.instance.CastSkills.FirstOrDefault(x =>
                x.Usestate == BChar && x.skill.AllExtendeds.Any(y => y is SkillEn_Kamiyo21341_0));
            Counter(SP.UseStatus, SP, castingSkill);
        }

        public void AttackEffect(BattleChar hit, SkillParticle SP, int DMG, bool Cri)
        {
            if (SP.SkillData.AllExtendeds.Any(x => x is SkillEn_Kamiyo21341_0)) SubStack();
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
                    BattleSystem.instance.CastSkills.Remove(CastingSkill);
                    BattleSystem.instance.SaveSkill.Remove(CastingSkill);
                    SubStack();
                    return;
                case false when !target.IsDead:
                    CastingSkill.Target = target;
                    BattleSystem.DelayInput(Counter(CastingSkill));
                    return;
            }
        }

        public IEnumerator Counter(CastingSkill CastingSkill)
        {
            yield return BattleSystem.instance.StartCoroutine(
                BattleSystem.instance.AllyCastingSkillUse(CastingSkill, false));
            BattleSystem.instance.CastSkills.Remove(CastingSkill);
            BattleSystem.instance.SaveSkill.Remove(CastingSkill);
            yield return null;
        }
    }
}