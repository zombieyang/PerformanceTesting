using Puerts;
using UnityEngine;
using XLua;

/// <summary>
/// 静态方法调用
/// 逻辑:   调用Transform.Rotate
/// 参数:   1引用类型
/// 返回值: UnityEngine.Quaternion
/// </summary>
[Test]
public class Example30 : IExecute
{
    public bool Static => true;
    public string Method => "Quaternion Payload(Transform);";
    public CallTarget Target => CallTarget.ScriptCallCSharp;

    public object RunCS(int count, out double duration)
    {
        var obj = new GameObject().transform;
        Timer timer = new Timer();
        for (var i = 0; i < count; i++)
        {
            Example30.Payload(obj);
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
    var Example = require('csharp').Example30;

    var obj = new (require('csharp').UnityEngine.GameObject)().transform;
    const start = Date.now();
    for(let i = 0; i < {0}; i++){{
        Example.Payload(obj);
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
local Example = CS.Example30;

local obj = CS.UnityEngine.GameObject().transform;
local start = os.clock();
for i = 0,{0} do
    Example.Payload(obj);
end
local result = obj.rotation;
CS.UnityEngine.Object.DestroyImmediate(obj.gameObject);

return os.clock() - start, result;
", count - 1));

        duration = 1000 *(double)result[0];
        return result[1];
    }

    public static void Payload(Transform transform)
    {
        transform.Rotate(1, 1, 1);
    }
}
