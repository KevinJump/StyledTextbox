using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Umbraco.Cms.Core;
using Umbraco.Cms.Core.IO;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.PropertyEditors;

namespace Jumoo.StyledTextbox
{
    [DataEditor(
        alias: StyledText.Alias,
        name: StyledText.Name,
        view: StyledText.EditorPath,
        Group = Constants.PropertyEditors.Groups.Common,
        Icon = StyledText.Icon,
        ValueType = ValueTypes.Text)]
    public class StyledTextboxDataEditor : DataEditor
    {
        private readonly IIOHelper _ioHelper;

        public StyledTextboxDataEditor(
            IIOHelper iOHelper,
            IDataValueEditorFactory dataValueEditorFactory, 
            EditorType type = EditorType.PropertyValue) 
            : base(dataValueEditorFactory, type)
        { 
            _ioHelper = iOHelper; 
        }

        /// <inheritdoc />
        protected override IDataValueEditor CreateValueEditor() 
            => DataValueEditorFactory.Create<TextOnlyValueEditor>(Attribute);

        /// <inheritdoc />
        protected override IConfigurationEditor CreateConfigurationEditor() 
            => new StyledTextConfigurationEditor(_ioHelper);
    }

    public class StyledTextConfigurationEditor : ConfigurationEditor<StyledTextConfiguration>
    {
        public StyledTextConfigurationEditor(IIOHelper ioHelper) : base(ioHelper)
        {
        }
    }
}
