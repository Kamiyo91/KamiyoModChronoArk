using System;
using System.Collections;
using System.Linq;
using GameDataEditor;
using UnityEngine;
using static CharacterDocument;

namespace KamiyoMod
{
    public class B_KamiyoCounterDraw21431 : Buff, IP_Dodge
    {
        public void Dodge(BattleChar Char, SkillParticle SP)
        {
            if (Char != BChar || SP.UseStatus.Info.Ally == BChar.Info.Ally) return;
            foreach (var castingSkill in BattleSystem.instance.CastSkills.Where(castingSkill =>
                         castingSkill.Usestate == BChar))
            {
                SelfDestroy();
                Counter(SP.UseStatus, SP, castingSkill);
                return;
            }
        }

        public override void Init()
        {
            PlusStat.PerfectDodge = true;
        }

        public void Counter(BattleChar target, SkillParticle SP, CastingSkill CastingSkill)
        {
            BattleSystem.instance.AllyTeam.Draw(1);
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