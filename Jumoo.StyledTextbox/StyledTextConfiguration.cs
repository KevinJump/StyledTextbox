using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Umbraco.Cms.Core.PropertyEditors;

namespace Jumoo.StyledTextbox
{
    public class StyledTextConfiguration : TextboxConfiguration
    {
     
        [ConfigurationField("multiLine", "Multi-Line", "boolean",
            Description = "Redner as a multi-line textarea")]
        public bool Multiline { get; set; }

        [ConfigurationField("style", "Style", "textarea",
            Description = "Styles to apply to text")]
        public string Style { get; set; }

        [ConfigurationField("cssClass", "Css classes", "textarea",
            Description = "Css classes to apply to the input")]
        public string CssClass { get; set; }

        [ConfigurationField("containerCssClass", "Container Css", "textarea",
            Description = "Css classes to apply to the fields container item")]
        public string ContainerCssClass { get; set; }

        [ConfigurationField("placeholder", "Placeholder", "textstring",
            Description = "Placeholder text to use")]
        public string Placeholder { get; set; }

        [ConfigurationField("enforceLimit", "Enforce Limit", "boolean",
            Description = "Enforce the charecter limit (don't let editor go beyond)")]
        public bool EnforceLimit { get; set; }

        [ConfigurationField("hideLabel", "Hide Label", "boolean", 
            Description = "Hide the property label (full width)")]
        public bool HideLabel { get; set; }
    }
}
