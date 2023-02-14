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
public class Example31 : IExecute
{
    public bool Static => false;
    public string Method => "Quaternion Payload(Transform);";
    public CallTarget Target => CallTarget.ScriptCallCSharp;

    public object RunCS(int count)
    {
        var obj = new GameObject().transform;
        var exp = new Example31();
        for (var i = 0; i < count; i++)
        {
            exp.Payload(obj);
        }
        var result = obj.rotation;
        Object.DestroyImmediate(obj.gameObject);

        return result;
    }
    public object RunJS(JsEnv env, int count)
    {
        var result = env.Eval<Quaternion>(string.Format(
@"
var Example = new (require('csharp').Example31);

var obj = new (require('csharp').UnityEngine.GameObject)().transform;
for(let i = 0; i < {0}; i++){{
    Example.Payload(obj);
}}
var result = obj.rotation;
require('csharp').UnityEngine.Object.DestroyImmediate(obj.gameObject);

result;
", count));

        return result;
    }
    public object RunLua(LuaEnv env, int count)
    {
        object[] result = env.DoString(string.Format(
@"
local Example = CS.Example31();

local obj = CS.UnityEngine.GameObject().transform;
for i = 0,{0} do
    Example:Payload(obj);
end
local result = obj.rotation;
CS.UnityEngine.Object.DestroyImmediate(obj.gameObject);

return result;
", count - 1));

        return result != null && result.Length > 0 ? result[0] : null;
    }

    public void Payload(Transform transform)
    {
        transform.Rotate(1, 1, 1);
    }
}
