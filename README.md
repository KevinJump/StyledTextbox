# StyledTextbox
Textbox for Umbraco with CSS styles and character limits

## Razor class library package.
The really intresting bit of this package is that it delivers the html and js files via a Razor class library and static assets ! 

it also does some hackery to load in the strings from compiled resource files (.resx) into the javascript server variables so you 
can localized the package and not need a Lang folder hanging around in app_plugins.


