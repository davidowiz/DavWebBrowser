DavWebBrowser

Generate CEF Browser dynamic in RAGE-MP with C# on the server side

Feel free to contribute and share your ideas or feature requests.

Wiki and further instructions will follow, as soon as a first showable version is present.


Starter Guide:
1. Clone project
2. Copy the folder which beginngs with "statics" into your "%RageInstallation%/server-files/client-packages/"
3. Make sure all libary references are present. If not restore nuget packages and/or add missing references from the "server-files/bridge/runtime/" folder.
4. Adjust project "DavWebCreate.Server" output path to point to your  "server-files/bridge/resources/DavWebBrowser". Now if the project was build, the .dll will be present in the resources folder.
5. Now add a file called "meta.xml" to your "server-files/bridge/resources/DavWebBrowser" folder.
6. Open the file in a text-editor and paste the following content in.

<?xml version="1.0" encoding="utf-8"?>
<meta>
  <info name = "DavWebCreator" author="Davidowiz" type="gamemode"/>
  
  <!-- Gamemode library -->
  <script src = "netcoreapp2.2/DavWebCreator.Server.dll" />

  <settings>
    <!-- Server Configuration -->
    <setting name="PAGE_TITLE" value="DavWebCreator"/>
  
    <!-- Stylesheet Configuration-->
    <setting name = "THEME" value="default"/>
  </settings>
</meta>

7. This is hopefully everything in order to contribute.

Notes:
Html template is splitted in a 3x3 Grid to set the content elements to the desired positions.
Width and height of the html is too adjustable.
Themes will be implemented later for the browser and for the browser elements. (elements will overwrite browser or container style rules)

The main goal is to improve the development process and give the possibility to change every element of a browser in real time with almost 0 afford. (Compared to creating HTML,CSS,Javascript.... files, the logic behind and the actual connection to your backend).

*** MIT license ***

Best regards, David
