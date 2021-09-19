using System;
using Rocket.API;

namespace NoHands
{
    public class NoHandsConfiguration : IRocketPluginConfiguration
    {
        public string Permission_Ignore { get; set; }

        public void LoadDefaults()
        {
            Permission_Ignore = "NoHands.Ignore";
        }
    }
}
