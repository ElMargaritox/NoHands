using System;
using Rocket.API;
using Rocket.Core.Plugins;
using Rocket.Unturned.Events;
using Logger = Rocket.Core.Logging.Logger;

namespace NoHands
{
    public class NoHandsPlugin : RocketPlugin<NoHandsConfiguration>
    {
        public NoHandsPlugin Instance { get; set; }
        protected override void Load()
        {
            Instance = this;
            Logger.Log("NoHands. Cargado Correctamente");
            UnturnedPlayerEvents.OnPlayerUpdateGesture += UnturnedPlayerEvents_OnPlayerUpdateGesture;
        }

        private void UnturnedPlayerEvents_OnPlayerUpdateGesture(Rocket.Unturned.Player.UnturnedPlayer player, UnturnedPlayerEvents.PlayerGesture gesture)
        {
          if(gesture == UnturnedPlayerEvents.PlayerGesture.InventoryOpen)
            {
                if (!player.HasPermission(Configuration.Instance.Permission_Ignore))
                {
                    player.Inventory.items[2].resize(0, 0);
                }
            }
        }

        protected override void Unload()
        {
            Logger.Log("NoHands. Deshabilitado Correctamente");
            UnturnedPlayerEvents.OnPlayerUpdateGesture -= UnturnedPlayerEvents_OnPlayerUpdateGesture;

        }
    }
}
