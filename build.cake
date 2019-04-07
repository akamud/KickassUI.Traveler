#addin "nuget:?package=Cake.AndroidAppManifest&version=1.1.1"
#addin "nuget:?package=Cake.Plist&version=0.5.0"
#addin "nuget:?package=Cake.Git&version=0.19.0"
#addin nuget:?package=Cake.SemVer&version=3.0.0
#addin nuget:?package=semver&version=2.0.4

#tool "nuget:?package=NUnit.Runners&version=2.6.4"

var target = Argument("Target", "Default");
Task("Default")
  .IsDependentOn("HotReload")
  .Does(() =>
  {

  });
Task("Clean")
    .Does(() =>
    {
        var objFolders = GetDirectories("./src/**/obj*");

        foreach (var objFolder in objFolders)
        {
            if (DirectoryExists(objFolder))
            {
                DeleteDirectory(objFolder, true);
            }
        }

        var binFolders = GetDirectories("./src/**/bin*");


        foreach (var binFolder in binFolders)
        {
            if (DirectoryExists(binFolder))
            {
                DeleteDirectory(binFolder, new DeleteDirectorySettings
                {
                    Recursive = true,
                    Force = true
                });
            }
        }
    });

Task("HotReload")
    .Does(() => {
        StartProcess("adb", "forward tcp:4290 tcp:4290");

        var processSettings = new ProcessSettings()
        {
            Arguments = $"./tools/Xamarin.Forms.HotReload.Observer.exe u=http://127.0.0.1:4290,http://127.0.0.1:4291",
        };

        using (var hotReloadProcess = StartAndReturnProcess("mono", processSettings))
        {
            hotReloadProcess.WaitForExit();
        }
    });

RunTarget(target);
