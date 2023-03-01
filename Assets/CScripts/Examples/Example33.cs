using Puerts;
using UnityEngine;
using XLua;

/// <summary>
/// 静态方法调用
/// 逻辑:   调用Transform.Rotate
/// 参数:   1引用类型, 3个值类型
/// 返回值: UnityEngine.Quaternion
/// </summary>
[Test]
[TestGroup("xyz vs Vector3", 1, Desc = "xyz传参 vs Vector3传参")]
public class Example33 : IExecute
{
    public bool Static => false;
    public string Method => "Quaternion Payload(Transform, float, float, float);";
    public CallTarget Target => CallTarget.ScriptCallCSharp;

    public object RunCS(int count, out double duration)
    {
        var obj = new GameObject().transform;
        var exp = new Example33();
        Timer timer = new Timer();
        for (var i = 0; i < count; i++)
        {
            exp.Payload(obj, i % 3f, i % 4f, i % 5f);
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
    var Example = new (require('csharp').Example33);

    var obj = new (require('csharp').UnityEngine.GameObject)().transform;
    const start = Date.now();
    for(let i = 0; i < {0}; i++){{
        Example.Payload(obj, i % 3, i % 4, i % 5);
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
local Example = CS.Example33();

local obj = CS.UnityEngine.GameObject().transform;
local start = os.clock();
for i = 0,{0} do
    Example:Payload(obj, i % 3, i % 4, i % 5);
end
local result = obj.rotation;
CS.UnityEngine.Object.DestroyImmediate(obj.gameObject);

return os.clock() - start, result;
", count - 1));

        duration = 1000 *(double)result[0];
        return result[1];
    }

    public void Payload(Transform transform, float x, float y, float z)
    {
        transform.Rotate(x, y, z);
    }
}
