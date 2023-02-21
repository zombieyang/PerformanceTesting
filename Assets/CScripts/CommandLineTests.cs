#if UNITY_EDITOR
using System;
using System.IO;
using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEditor;
using UnityEditor.Build.Reporting;

public class CommandLineTests
{
    [MenuItem(("PerformanceTest/Gen Code V1"))]
    public static void GenV1()
    {
        PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone, "");
        {
            const string typeName = "CSObjectWrapEditor.Generator";
            var type = (from _assembly in AppDomain.CurrentDomain.GetAssemblies()
                let _type = _assembly.GetType(typeName, false)
                where _type != null
                select _type).FirstOrDefault();
            if (type != null)
            {
                type.GetMethod("GenAll").Invoke(null, new object[] {});
            }
        }
        { // old puerts
            const string typeName = "Puerts.Editor.Generator.Menu";
            var type = (from _assembly in AppDomain.CurrentDomain.GetAssemblies()
                let _type = _assembly.GetType(typeName, false)
                where _type != null
                select _type).FirstOrDefault();
            if (type != null)
            {
                type.GetMethod("GenerateCode").Invoke(null, new object[] {});
            }
        }
        { // new puerts
            const string typeName = "Puerts.Editor.Generator.UnityMenu";
            var type = (from _assembly in AppDomain.CurrentDomain.GetAssemblies()
                let _type = _assembly.GetType(typeName, false)
                where _type != null
                select _type).FirstOrDefault();
            if (type != null)
            {
                type.GetMethod("GenerateCode").Invoke(null, new object[] {});
            }
        }
        {
            const string typeName = "Puerts.Editor.GeneratorUsing";
            var type = (from _assembly in AppDomain.CurrentDomain.GetAssemblies()
                let _type = _assembly.GetType(typeName, false)
                where _type != null
                select _type).FirstOrDefault();
            if (type != null)
            {
                type.GetMethod("GenerateUsingCode").Invoke(null, new object[] {});
            }
        }
        // Puerts.Editor.Generator.UnityMenu.GenerateMacroHeader(false);
    }
    [MenuItem(("PerformanceTest/Gen Code V2"))]
    public static void GenV2() 
    {
        PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone, "EXPERIMENTAL_IL2CPP_PUERTS");
        PuertsIl2cpp.Editor.Generator.UnityMenu.GenerateCppWrappers();
        PuertsIl2cpp.Editor.Generator.UnityMenu.GenerateExtensionMethodInfos();
        PuertsIl2cpp.Editor.Generator.UnityMenu.GenerateLinkXML();
        // Puerts.Editor.Generator.UnityMenu.GenerateMacroHeader(true);
    }

    [MenuItem("PerformanceTest/Run Test")]
    public static void RunTest()
    {
        Tester tester = new Tester(
            new int[] { 10000, 100000 },
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
            Path.Combine(Application.dataPath, "../STATES.md")
#else
            Path.Combine(Application.persistentDataPath, "./STATES.md")
#endif
        );
        tester.OnInfoUpdate += (string info) => UnityEngine.Debug.Log(info);

        IEnumerator enumerator = tester.StartTest();

        while (enumerator.MoveNext()) { }
    }
    
    [MenuItem("PerformanceTest/BuildForWindows")] 
    public static void BuildA() { Build("a"); }
    public static void BuildC() { Build("c"); }
    public static void BuildD() { Build("d"); }

    public static void BuildZ() { Build("z", true); }
    public static void BuildY() { Build("y", true); }
    public static void BuildX() { Build("x", true); }

    
    public static void Build(string exedir = "a", bool withExperimental = false)
    {
        PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone, "");
        PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone, withExperimental ? "EXPERIMENTAL_IL2CPP_PUERTS" : "");
        PlayerSettings.SetScriptingBackend(BuildTargetGroup.Standalone, ScriptingImplementation.IL2CPP);

        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[] { "Assets/TempScript/TempScene.unity"};
        buildPlayerOptions.locationPathName = "build/" + exedir + "/PerformanceTest.exe";
        buildPlayerOptions.target = BuildTarget.StandaloneWindows64;
        buildPlayerOptions.options = BuildOptions.None;

        BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
        BuildSummary summary = report.summary;

        if (summary.result == BuildResult.Succeeded)
        {
            Debug.Log("Build succeeded: " + summary.outputPath + " with " + summary.totalSize + " bytes");
            if (Application.isBatchMode) Application.Quit(0);
        }

        if (summary.result == BuildResult.Failed)
        {
            Debug.Log("Build failed: " + summary.outputPath);
            if (Application.isBatchMode) Application.Quit(1);
        }
    }
    
    [MenuItem("PerformanceTest/Build For iOS")] 
    public static void BuildiOSA() { BuildIOS("ia"); }
    public static void BuildiOSB() { BuildIOS("ib"); }
    public static void BuildiOSC() { BuildIOS("ic"); }
    public static void BuildiOSD() { BuildIOS("id"); }
    public static void BuildiOSX() { BuildIOS("ix", true); }
    public static void BuildiOSY() { BuildIOS("iy", true); }
    public static void BuildiOSZ() { BuildIOS("iz", true); }


    public static void BuildIOS(string exedir = "a", bool withExperimental = false)
    {
        PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.iOS, "");
        PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.iOS, withExperimental ? "EXPERIMENTAL_IL2CPP_PUERTS" : "");
        PlayerSettings.SetScriptingBackend(BuildTargetGroup.iOS, ScriptingImplementation.IL2CPP);

        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[] { "Assets/TempScript/TempScene.unity"};
        buildPlayerOptions.locationPathName = "build/" + exedir;
        buildPlayerOptions.target = BuildTarget.iOS;
        buildPlayerOptions.options = BuildOptions.None;

        BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
        BuildSummary summary = report.summary;

        if (summary.result == BuildResult.Succeeded)
        {
            Debug.Log("Build succeeded: " + summary.outputPath + " with " + summary.totalSize + " bytes");
            if (Application.isBatchMode) Application.Quit(0);
        }

        if (summary.result == BuildResult.Failed)
        {
            Debug.Log("Build failed: " + summary.outputPath);
            if (Application.isBatchMode) Application.Quit(1);
        }
    }
    
    [MenuItem("PerformanceTest/Build For Android")] 
    public static void BuildAndroidA() { BuildAndroid("aa"); }
    public static void BuildAndroidB() { BuildAndroid("ab"); }
    public static void BuildAndroidC() { BuildAndroid("ac"); }
    public static void BuildAndroidD() { BuildAndroid("ad"); }
    public static void BuildAndroidX() { BuildAndroid("ax", true); }
    public static void BuildAndroidY() { BuildAndroid("ay", true); }
    public static void BuildAndroidZ() { BuildAndroid("az", true); }


    public static void BuildAndroid(string exedir = "a", bool withExperimental = false)
    {
        PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android, "");
        PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android, withExperimental ? "EXPERIMENTAL_IL2CPP_PUERTS" : "");
        PlayerSettings.SetScriptingBackend(BuildTargetGroup.Android, ScriptingImplementation.IL2CPP);
        PlayerSettings.Android.targetArchitectures = AndroidArchitecture.ARM64;

        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[] { "Assets/TempScript/TempScene.unity"};
        buildPlayerOptions.locationPathName = "build/" + exedir + ".apk";
        buildPlayerOptions.target = BuildTarget.Android;
        buildPlayerOptions.options = BuildOptions.None;

        BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
        BuildSummary summary = report.summary;

        if (summary.result == BuildResult.Succeeded)
        {
            Debug.Log("Build succeeded: " + summary.outputPath + " with " + summary.totalSize + " bytes");
            if (Application.isBatchMode) Application.Quit(0);
        }

        if (summary.result == BuildResult.Failed)
        {
            Debug.Log("Build failed: " + summary.outputPath);
            if (Application.isBatchMode) Application.Quit(1);
        }
    }
}
#endif