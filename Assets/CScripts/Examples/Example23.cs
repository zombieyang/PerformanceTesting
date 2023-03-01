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

    public object RunCS(int count, out double duration)
    {
        float result = 0f;
        var obj = new Example23();
        Timer timer = new Timer();
        for (var i = 0; i < count; i++)
        {
            result += obj.Payload();
        }
        duration = timer.End();
        return result;
    }
    public object RunJS(JsEnv env, int count, out double duration)
    {
        duration = env.Eval<double>(string.Format(
@"(function() {{
    var Example = new (require('csharp').Example23)();
    var result = 0;
    const start = Date.now();
    for(let i = 0; i < {0}; i++){{
        result += Example.Payload();
    }}

    global.result = result;
    return Date.now() - start;
}})()", count));
        return env.Eval<float>("result");
    }
    public object RunLua(LuaEnv env, int count, out double duration)
    {
        object[] result = env.DoString(string.Format(
@"
local Example = CS.Example23();
local result = 0;
local start = os.clock();
for i = 0,{0} do
    result = result + Example:Payload();
end

return os.clock() - start, result;
", count - 1));

        duration = 1000 *(double)result[0];
        return result[1];
    }

    public float Payload()
    {
        return 1 + 2 + 3f;
    }
}
