using System.Collections.Generic;
using ChronoArkMod.Plugin;
using HarmonyLib;

namespace KamiyoMod
{
    [PluginConfig("Kamiyo_CharacterMod", "Kamiyo_CharacterMod", "1.0.0")]
    public class KamiyoMod_Plugin : ChronoArkPlugin
    {
        private Harmony _harmony;

        public override void Dispose()
        {
            _harmony.UnpatchSelf();
        }

        public override void Initialize()
        {
            _harmony = new Harmony(GetGuid());
            _harmony.PatchAll();
        }

        public override void OnModLoaded()
        {
            base.OnModLoaded();
            OnModSettingUpdate();
        }

        [HarmonyPatch(typeof(Extended_Witch_P_0))]
        private class Extended_Witch_P_0_Plugin
        {
            [HarmonyPatch("Special_PointerEnter")]
            [HarmonyPrefix]
            public static void Extended_Witch_P_0_Special_PointerEnter_Patch(Skill_Extended __instance, BattleChar Char)
            {
                if (Char.Info.KeyData != "Kamiyo21341") return;
                Char.Info.GetData.Text_Witch = new List<string>
                {
                    ModLocalization.CharacterKamiyo21341Witch,
                    ModLocalization.CharacterKamiyo21341Witch_Low
                };
            }
        }
    }
}