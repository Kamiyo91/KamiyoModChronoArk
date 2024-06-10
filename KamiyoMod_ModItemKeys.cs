using ChronoArkMod;

namespace KamiyoMod
{
    public static class ModItemKeys
    {
        public static string Buff_B_KamiyoCounterDraw21431 = "B_KamiyoCounterDraw21431";
        public static string Buff_B_KamiyoCounterMana21341 = "B_KamiyoCounterMana21341";

        /// <summary>
        ///     Mask of Perception
        ///     Gain 10% Lifesteal on attacks. Attacking enemies with 1 Action point will make you draw 1 Skill.
        /// </summary>
        public static string Buff_B_KamiyoMask21341 = "B_KamiyoMask21341";

        /// <summary>
        ///     Kamiyo
        ///     Passive:
        ///     High base evade rate (Active from Lv 1).
        ///     On Dodge overheal 2 HP.
        ///     On Death's Door lower all user's skills cost by 1 and add [Swiftness] effect on them.
        ///     At the start of the battle gain [Mask of Perception] buff.
        /// </summary>
        public static string Character_Kamiyo21341 = "Kamiyo21341";

        public static string SkillEffect_SE_T_S_Kamiyo21341_0 = "SE_T_S_Kamiyo21341_0";
        public static string SkillEffect_SE_T_S_Kamiyo21341_1 = "SE_T_S_Kamiyo21341_1";
        public static string SkillEffect_SE_T_S_Kamiyo21341_2 = "SE_T_S_Kamiyo21341_2";
        public static string SkillEffect_SE_T_S_Kamiyo21341_3 = "SE_T_S_Kamiyo21341_3";
        public static string SkillEffect_SE_T_S_Kamiyo21341_4 = "SE_T_S_Kamiyo21341_4";
        public static string SkillEffect_SE_T_S_Kamiyo21341_6 = "SE_T_S_Kamiyo21341_6";

        /// <summary>
        ///     Imminent Fight
        /// </summary>
        public static string Skill_S_Kamiyo21341_0 = "S_Kamiyo21341_0";

        /// <summary>
        ///     Lower Slash
        ///     If there is any skill from the user in the Cast List, the cost of this skill is reduced by 1
        /// </summary>
        public static string Skill_S_Kamiyo21341_1 = "S_Kamiyo21341_1";

        /// <summary>
        ///     Charged Horizontal Slash
        ///     Recover 1 Mana for each enemy killed. If this skill attack a single enemy, it deal 10 additional damage
        /// </summary>
        public static string Skill_S_Kamiyo21341_2 = "S_Kamiyo21341_2";

        /// <summary>
        ///     Upper Slash
        ///     If there is any skill from the user in the Cast List, the cost of this skill is reduced by 1
        /// </summary>
        public static string Skill_S_Kamiyo21341_3 = "S_Kamiyo21341_3";

        /// <summary>
        ///     Gathering Self
        ///     If attacked while this skill is in Cooldown, dodge the attack,cast the skill on the attacker and draw 1 skill.
        /// </summary>
        public static string Skill_S_Kamiyo21341_4 = "S_Kamiyo21341_4";

        /// <summary>
        ///     Mask of Perception
        ///     Increase Action Count of all enemies by 1, restore 3 Mana and draw 2 skills.
        /// </summary>
        public static string Skill_S_Kamiyo21341_5 = "S_Kamiyo21341_5";

        /// <summary>
        ///     Focus
        ///     If attacked while this skill is in Cooldown, dodge the attack,cast the skill on the attacker and restore 1 Mana.
        /// </summary>
        public static string Skill_S_Kamiyo21341_6 = "S_Kamiyo21341_6";
    }

    public static class ModLocalization
    {
        /// <summary>
        ///     Korean:
        ///     English:
        ///     If you want, I can still handle it!
        ///     Japanese:
        ///     Chinese:
        ///     Chinese-TW:
        /// </summary>
        public static string CharacterKamiyo21341Witch => ModManager.getModInfo("KamiyoMod").localizationInfo
            .SystemLocalizationUpdate("CharacterKamiyo21341Witch");

        /// <summary>
        ///     Korean:
        ///     English:
        ///     I don't know if I'll be able to handle it...
        ///     Japanese:
        ///     Chinese:
        ///     Chinese-TW:
        /// </summary>
        public static string CharacterKamiyo21341Witch_Low => ModManager.getModInfo("KamiyoMod").localizationInfo
            .SystemLocalizationUpdate("CharacterKamiyo21341Witch_Low");
    }
}