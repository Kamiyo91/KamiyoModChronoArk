using System.Collections.Generic;
using _1ChronoArkKamiyoUtil;
using ChronoArkMod.Plugin;

namespace KamiyoMod
{
    public class KamiyoMod_Plugin : ChronoArkPlugin
    {
        public override void Dispose()
        {
        }

        public override void Initialize()
        {
            KamiyoGlobalModParameters.DialogueTrees.TryAdd("Kamiyo21341", new List<DialogueFinder>());
        }
    }
}