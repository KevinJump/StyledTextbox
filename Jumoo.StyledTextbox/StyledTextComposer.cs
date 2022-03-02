
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Notifications;

namespace Jumoo.StyledTextbox
{
    public class StyledTextComposer : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            builder.AddStyledTextBox();
        }
    }

    public static class StyledTextComposerExtensions
    {
        public static IUmbracoBuilder AddStyledTextBox(this IUmbracoBuilder builder)
        {
            // don't add if the filter is already there .
            if (builder.ManifestFilters().Has<StyledTextManifestFilter>())
                return builder;

            // add the package manifest programatically. 
            builder.ManifestFilters().Append<StyledTextManifestFilter>();

            // handler to add our localisations to the variables. 
            builder.AddNotificationHandler<ServerVariablesParsingNotification, ServerVariablesHandler>();

            return builder;
        }
    }
}
