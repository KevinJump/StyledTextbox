using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Umbraco.Cms.Core.Manifest;
using Umbraco.Cms.Core.PropertyEditors;

namespace Jumoo.StyledTextbox
{
    internal class StyledTextManifestFilter : IManifestFilter
    {
        public void Filter(List<PackageManifest> manifests)
        {
            manifests.Add(new PackageManifest
            {
                PackageName = "Jumoo.StyledTextbox",
                Scripts = new []
                {
                    StyledText.PluginPath + "/styledtext.controller.js"
                },
                Stylesheets = new []
                {
                    StyledText.PluginPath + "/styledtext.css"
                }
            });
        }
    }
}
