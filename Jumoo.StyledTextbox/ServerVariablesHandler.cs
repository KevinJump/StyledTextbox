using Jumoo.StyledTextbox.Localisation;

using System.Collections.Generic;

using Umbraco.Cms.Core.Events;

using Umbraco.Cms.Core.Notifications;

namespace Jumoo.StyledTextbox
{
    internal class ServerVariablesHandler
        : INotificationHandler<ServerVariablesParsingNotification>
    {
        public void Handle(ServerVariablesParsingNotification notification)
        {
            notification.ServerVariables.Add("styledText",
                LocalizedStrings.GetResourceStrings(this.GetType().Assembly));
        }
    }
}
