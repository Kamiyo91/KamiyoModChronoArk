using System.Collections.Generic;
using System.Linq;

namespace KamiyoMod
{
    /// <summary>
    ///     Kamiyo
    ///     Passive:
    ///     50% Evade chance.On Dodge overheal 2 HP.
    ///     On Death's Door lower all user's skills cost by 1 and add [Swiftness] effect on them.
    ///     At the start of the battle gain[Mask of Perception] buff.
    /// </summary>
    public class P_Kamiyo21341 : Passive_Char, IP_Dodge, IP_BattleStart_Ones
    {
        private readonly List<Skill> _changedSwiftness = new List<Skill>();
        private readonly List<Skill> _changedAp = new List<Skill>();
        public void BattleStart(BattleSystem Ins)
        {
            if (!BChar.BuffFind("B_KamiyoMask21341")) BChar.BuffAdd("B_KamiyoMask21341", BChar);
        }

        public void Dodge(BattleChar Char, SkillParticle SP)
        {
            if (Char != BChar) return;
            BChar.Heal(BChar, 2, false, true);
        }

        public override void Init()
        {
            base.Init();
            OnePassive = true;
        }

        public override void FixedUpdate()
        {
            if (BChar.HP <= 0)
                foreach (var skill in BattleSystem.instance.AllyTeam.Skills.Where(skill => skill.Master == BChar))
                {
                    skill.APChange = -1;
                    _changedAp.Add(skill);
                    if (skill.NotCount) continue;
                    skill.NotCount = true;
                    _changedSwiftness.Add(skill);
                }
            else
            {
                foreach (var skill in _changedSwiftness.ToList())
                {
                    skill.NotCount = false;
                    _changedSwiftness.Remove(skill);
                }
                foreach (var skill in _changedAp.ToList())
                {
                    skill.APChange = 0;
                    _changedAp.Remove(skill);
                }
            }
        }
    }
}