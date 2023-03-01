using Puerts;
using UnityEngine;
using XLua;

/// <summary>
/// 静态方法调用
/// 逻辑:   调用Transform.Rotate
/// 参数:   1引用类型, 1个值类型(Vector3)
/// 返回值: UnityEngine.Quaternion
/// </summary>
[Test]
[TestGroup("xyz vs Vector3")]
public class Example34 : IExecute
{
    public bool Static => true;
    public string Method => "Quaternion Payload(Transform, Vector3);";
    public CallTarget Target => CallTarget.ScriptCallCSharp;

    public object RunCS(int count, out double duration)
    {
        var obj = new GameObject().transform;
        var eulers = new Vector3(1f, 2f, 3f);
        Timer timer = new Timer();
        for (var i = 0; i < count; i++)
        {
            Example34.Payload(obj, eulers);
        }
        var result = obj.rotation;
        Object.DestroyImmediate(obj.gameObject);

        duration = timer.End();
        return result;
    }
    public object RunJS(JsEnv env, int count, out double duration)
    {
        duration = env.Eval<double>(string.Format(
 @"(function() {{
    var Example = require('csharp').Example34;

    var obj = new (require('csharp').UnityEngine.GameObject)().transform;
    var eulers = new (require('csharp').UnityEngine.Vector3)(1, 2, 3);
    const start = Date.now();
    for(let i = 0; i < {0}; i++){{
        Example.Payload(obj, eulers);
    }}
    var result = obj.rotation;
    require('csharp').UnityEngine.Object.DestroyImmediate(obj.gameObject);

    global.result = result;
    return Date.now() - start;
}})()", count));
        return env.Eval<Quaternion>("result");
    }
    public object RunLua(LuaEnv env, int count, out double duration)
    {
        object[] result = env.DoString(string.Format(
@"
local Example = CS.Example34;

local obj = CS.UnityEngine.GameObject().transform;
local eulers = CS.UnityEngine.Vector3(1, 2, 3);
local start = os.clock();
for i = 0,{0} do
    Example.Payload(obj, eulers);
end
local result = obj.rotation;
CS.UnityEngine.Object.DestroyImmediate(obj.gameObject);

return os.clock() - start, result;
", count - 1));

        duration = 1000 *(double)result[0];
        return result[1];
    }

    public static void Payload(Transform transform, Vector3 eulers)
    {
        transform.Rotate(eulers);
    }
}
