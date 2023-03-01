using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using XLua;

[Puerts.Configure]
public static class XLuaConfig
{
    [Puerts.Binding]
    [XLua.LuaCallCSharp]
    [XLua.CSharpCallLua]
    static IEnumerable<Type> DynamicBindings
    {
        get
        {
            var exampleTypes = from assembly in AppDomain.CurrentDomain.GetAssemblies()
                               where !(assembly.ManifestModule is System.Reflection.Emit.ModuleBuilder)
                               from type in assembly.GetExportedTypes()
                               where typeof(IExecute).IsAssignableFrom(type) && type.IsDefined(typeof(TestAttribute), false)
                               orderby (type.GetCustomAttributes(typeof(TestAttribute), false).FirstOrDefault() as TestAttribute).priority descending
                               select type;

            string[] customAssemblys = new string[] {
                "Assembly-CSharp",
            };
            var delegateTypes = (from assembly in customAssemblys.Select(s => Assembly.Load(s))
                                 where !(assembly.ManifestModule is System.Reflection.Emit.ModuleBuilder)
                                 from type in assembly.GetExportedTypes()
                                 where typeof(Delegate).IsAssignableFrom(type) &&
                                    type != typeof(Puerts.JsEnv.JsEnvCreateCallback) &&
                                    type != typeof(Puerts.JsEnv.JsEnvDisposeCallback)
                                 select type);

            return exampleTypes
                .Concat(delegateTypes)
                .Concat(new Type[] {
                    typeof(UnityEngine.Application),
                    typeof(Debug),
                    typeof(Vector3),
                    typeof(Bounds),
                    typeof(Time),
                    typeof(Transform),
                    typeof(Component),
                    typeof(GameObject),
                    typeof(UnityEngine.Object),
                    typeof(Delegate),
                    typeof(System.Object),
                    typeof(ParticleSystem),
                    typeof(Canvas),
                    typeof(RenderMode),
                    typeof(Behaviour),

                    typeof(UnityEngine.Networking.UnityWebRequest),
                    typeof(UnityEngine.Networking.DownloadHandler),
                    typeof(UnityEngine.EventSystems.UIBehaviour),
                    typeof(UnityEngine.UI.Selectable),
                    typeof(UnityEngine.UI.Button),
                    typeof(UnityEngine.UI.Button.ButtonClickedEvent),
                    typeof(UnityEngine.Events.UnityEvent),
                    typeof(UnityEngine.UI.InputField),
                    typeof(UnityEngine.UI.Toggle),
                    typeof(UnityEngine.UI.Toggle.ToggleEvent),
                    typeof(UnityEngine.Events.UnityEvent<bool>),
                    typeof(Calculator),
                    typeof(CalculatorExtension)
                })
                .Distinct();
        }
    }
    [Puerts.Binding]
    static IEnumerable<Type> DynamicBindings2
    {
        get
        {
            return new List<Type>() {
                typeof(System.DateTime)
            };
        }
    }
}