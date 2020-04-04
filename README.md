DavWebBrowser

Generate CEF Browser dynamic in RAGE-MP with C# on the server side

Feel free to contribute and share your ideas or feature requests.

Contributer (short) guide:
1. Clone project
2. Copy the content of the folder within the client project called "client_packages" into your "RageInstallationPath/server-files/client-packages/".
3. Make sure all libary references are present. If not restore nuget packages and/or add missing references from the "server-files/bridge/runtime/" folder.
4. Adjust project "DavWebCreator.Server" output path to point to your  "server-files/bridge/resources/DavWebBrowser". Now if the project was build, the .dll will be present in the resources folder.
5. Now add a file called "meta.xml" to your "server-files/bridge/resources/DavWebBrowser" folder.
6. Open the file in a text-editor and paste the following content in.
  
"<?xml version="1.0" encoding="utf-8"?>
<meta>
  <info name = "DavWebCreator" author="Davidowiz" type="gamemode"/>
  
  <!-- Gamemode library -->
  <script src = "netcoreapp2.2/DavWebCreator.Server.dll" />

  <settings> 
    <!-- Server Configuration Kind of useless right now but will be important for configurations later -->
    <setting name="PAGE_TITLE" value="DavWebCreator"/>
  
    <!-- Stylesheet Configuration-->
    <setting name = "THEME" value="default"/>
  </settings>
</meta>"

7. One thing you still have to do is, to make sure your client project is within the "..\ragemp\server-files\client_packages\cs_packages\" folder, in order to actually work.
8. This is hopefully everything in order to contribute. If you have improvements, it would be great if you could share them with us/me :-) 

Notes:
The main goal is to improve the development process and give the possibility to change every element of a browser in real time with almost 0 afford. (Compared to creating HTML,CSS,Javascript.... files, the logic behind and the actual connection to your backend, this is really simple if you got it one time. The good about it, you can pretty fast build up a ui to test several features, without having the issue of building a proper ui for hours or days...

- The contribution setup and documentation will be improved.
- The webside documentation will be improved to be way better. (I only had spend like 8 hours on the angular based website, im sorry :S) 

And as I already mentioned several times, if you would like to contribute in any way or have questions, you can contact me via email: support@davwebcreator.com or via discord Davidowiz#0450

*** MIT license ***

Best regards, David
