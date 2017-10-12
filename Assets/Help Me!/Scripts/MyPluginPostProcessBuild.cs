using System.Collections;
using System.IO;
using UnityEditor.Callbacks;
using UnityEditor;
using UnityEditor.iOS.Xcode;

public class MyPluginPostProcessBuild
{
	[PostProcessBuild]
	public static void ChangeXcodePlist(BuildTarget buildTarget, string pathToBuiltProject)
	{
		if ( buildTarget == BuildTarget.iOS )
		{
			// Get plist
			string plistPath = pathToBuiltProject + "/Info.plist";

			
			PlistDocument plist = new PlistDocument();
			plist.ReadFromString(File.ReadAllText(plistPath));

			// Get root
			PlistElementDict rootDict = plist.root;

			// Add Permissions here
            rootDict.SetBoolean("NSAllowsArbitraryLoads",true);
            rootDict.SetString("NSCameraUsageDescription", "Camera Use");
            rootDict.SetString("NSCalendarsUsageDescription", "Calender Use");
            rootDict.SetBoolean("UIPrerenderedIcon", true);

            //rootDict.SetString("FacebookPlacementId","");
			

			// Write to file
			File.WriteAllText(plistPath, plist.WriteToString());
		}
	}
}

