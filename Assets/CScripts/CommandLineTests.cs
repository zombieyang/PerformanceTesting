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
    [MenuItem(("PerformanceTest/Gen Code"))]
    public static void GenCode()
    {
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
    public static void BuildB() { Build("b"); }
    public static void BuildC() { Build("c"); }
    public static void BuildD() { Build("d"); }

    public static void BuildZ() { Build("z", true); }
    public static void BuildY() { Build("y", true); }
    public static void BuildX() { Build("x", true); }

    [MenuItem("PerformanceTest/Build")] 
    public static void Build(string exedir = "a", bool withExperimental = false)
    {
        PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone, "");
        PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone, withExperimental ? "EXPERIMENTAL_IL2CPP_PUERTS" : "");
        PlayerSettings.SetScriptingBackend(BuildTargetGroup.Standalone, ScriptingImplementation.IL2CPP);

        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[] { "Assets/Scenes/SampleScene.unity"};
        buildPlayerOptions.locationPathName = "build/" + exedir + "/PerformanceTest.exe";
        buildPlayerOptions.target = BuildTarget.StandaloneWindows64;
        buildPlayerOptions.options = BuildOptions.None;

        BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
        BuildSummary summary = report.summary;

        if (summary.result == BuildResult.Succeeded)
        {
            Debug.Log("Build succeeded: " + summary.outputPath + " with " + summary.totalSize + " bytes");
        }

        if (summary.result == BuildResult.Failed)
        {
            Debug.Log("Build failed: " + summary.outputPath);
        }
    }
}
#endif