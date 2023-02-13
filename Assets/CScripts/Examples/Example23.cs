using Puerts;
using XLua;

/// <summary>
/// 静态方法调用
/// 逻辑:   内部求和并返回
/// 参数:   无
/// 返回值: 值类型
/// </summary>
[Test]
public class Example23 : IExecute
{
    public bool Static => false;
    public string Method => "float Payload();";
    public CallTarget Target => CallTarget.ScriptCallCSharp;

    public object RunCS(int count)
    {
        float result = 0f;
        var obj = new Example23();
        for (var i = 0; i < count; i++)
        {
            result += obj.Payload();
        }
        return result;
    }
    public object RunJS(JsEnv env, int count)
    {
        float result = env.Eval<float>(string.Format(
@"
var Example = new (require('csharp').Example23)();
var result = 0;
for(let i = 0; i < {0}; i++){{
    result += Example.Payload();
}}

result;
", count));
        return result;
    }
    public object RunLua(LuaEnv env, int count)
    {
        object[] result = env.DoString(string.Format(
@"
local Example = CS.Example23();
local result = 0;
for i = 0,{0} do
    result = result + Example.Payload();
end

return result;
", count - 1));

        return result != null && result.Length > 0 ? result[0] : null;
    }

    public float Payload()
    {
        return 1 + 2 + 3f;
    }
}
