using System.Collections.Generic;
using ConVar;
using Oxide.Core;

namespace Oxide.Plugins
{
    [Info("Commands Only", "varygoode", "1.0.1")]
    [Description("Only allow chat messages that are commands")]
    class CommandsOnly : CovalencePlugin
    {
        #region Fields

        private const string PermBypass = "commandsonly.bypass";

        #endregion Fields

        #region Init

        private void Init()
        {
            permission.RegisterPermission(PermIgnore, this);
        }

        #endregion Init

        #region Hooks

        private object OnUserChat(IPlayer player, string message)
        {
            if (message[0] != '/' && !player.HasPermission(PermBypass))
            {
                player.Reply(lang.GetMessage("CommandsOnly", this, player.Id));
                return true;
            }

            return null;
        }

        #endregion Hooks

        #region Localization

        protected override void LoadDefaultMessages()
        {
            lang.RegisterMessages(new Dictionary<string, string>
            {
                ["CommandsOnly"] = "You may only use commands in the chat."
            }, this);
        }

        #endregion Localization
    }
}
