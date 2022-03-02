using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;

namespace Jumoo.StyledTextbox.Localisation
{
    public static class LocalizedStrings
    {
        /// <summary>
        ///  loads all the resource strings from any .resource (.resx in dev) files,
        /// </summary>
        /// <remarks>
        ///  returns them as a nested dictionary. can be injected into server variables.
        /// </remarks>
        /// <param name="assembly"></param>
        /// <returns></returns>

        public static IDictionary<string, object> GetResourceStrings(Assembly assembly)
        {
            var keys = new Dictionary<string, object>();

            var names = assembly.GetManifestResourceNames()
                .Where(x => x.EndsWith(".resources", StringComparison.OrdinalIgnoreCase));

            foreach (var name in names)
            {
                // get name without .resources
                var strippedName = name.Substring(0, name.LastIndexOf('.'));

                // get just the name bit 
                var shortName = strippedName.Substring(strippedName.LastIndexOf('.') + 1);

                var nameKeys = new Dictionary<string, string>();

                using (Stream fileStream = assembly.GetManifestResourceStream(name))
                {
                    if (fileStream == null) continue; // loop to next resource in assembly

                    var resourceReader = new ResourceReader(fileStream);
                    var resourceManager = new ResourceManager(strippedName, assembly);

                    var enumerator = resourceReader.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        nameKeys.Add(
                            enumerator.Key.ToString(),
                            resourceManager.GetString(enumerator.Key.ToString(), CultureInfo.CurrentCulture));
                    }
                }

                if (nameKeys.Count > 0)
                    keys.Add(shortName, nameKeys);
            }

            return keys;
        }
    }
}
