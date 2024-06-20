using _1ChronoArkKamiyoUtil;
using ChronoArkMod.Plugin;
using System.Collections.Generic;

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