using System.Collections.Generic;
using System.Linq;
using _1ChronoArkKamiyoUtil;
using GameDataEditor;

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
        private readonly List<Skill> _changedAp = new List<Skill>();
        private readonly List<Skill> _changedSwiftness = new List<Skill>();

        public void BattleStart(BattleSystem Ins)
        {
            BChar.Info.GetData.Text_MasterTarget = ModLocalization.ProgramMasterFinalKamiyo;
            BChar.GetBuff<B_KamiyoMask21341>(nameof(B_KamiyoMask21341));
        }

        public void Dodge(BattleChar Char, SkillParticle SP)
        {
            if (Char != BChar) return;
            if (BChar.HP == BChar.GetStat.maxhp) BChar.AddShieldValue(nameof(B_KamiyoShield_21341), 2);
            else BChar.Heal(BChar, 2, false, true);
        }

        public override void Init()
        {
            base.Init();
            OnePassive = true;
        }

        public override void FixedUpdate()
        {
            foreach (var skill in BattleSystem.instance.AllyTeam.Skills.Where(skill =>
                         skill != null && skill.Master == BChar &&
                         !skill.AllExtendeds.Any(y => y is Extended_Kamiyo_1)))
                skill.ExtendedAdd(new Extended_Kamiyo_1());
            var battleCard = BattleSystem.instance.AllyList.FirstOrDefault(x => x == BChar)?.MyBasicSkill.buttonData;
            if (battleCard != null && !battleCard.AllExtendeds.Any(x => x is Extended_Kamiyo_1))
                battleCard.ExtendedAdd(new Extended_Kamiyo_1());
            if (BChar.BuffFind(GDEItemKeys.Buff_B_Neardeath))
            {
                foreach (var skill in BattleSystem.instance.AllyTeam.Skills.Where(skill => skill.Master == BChar))
                {
                    skill.APChange = -1;
                    if (!_changedAp.Contains(skill)) _changedAp.Add(skill);
                    if (skill.NotCount) continue;
                    skill.NotCount = true;
                    if (!_changedSwiftness.Contains(skill)) _changedSwiftness.Add(skill);
                }
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

        public bool CanAct()
        {
            return BattleSystem.instance.SaveSkill.Any(x =>
                       x.Usestate == BChar && x.skill.AllExtendeds.Any(y => y is S_Kamiyo21341_9)) ||
                   BattleSystem.instance.CastSkills.Any(x =>
                       x.Usestate == BChar && x.skill.AllExtendeds.Any(y => y is S_Kamiyo21341_9));
        }
    }
}