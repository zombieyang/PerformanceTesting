using Puerts;
using XLua;

/// <summary>
/// 静态方法调用
/// 逻辑:   内部求和并返回
/// 参数:   无
/// 返回值: 值类型
/// </summary>
[Test]
public class Example22 : IExecute
{
    public bool Static => true;
    public string Method => "float Payload();";
    public CallTarget Target => CallTarget.ScriptCallCSharp;

    public object RunCS(int count, out double duration)
    {
        float result = 0f;
        Timer timer = new Timer();
        for (var i = 0; i < count; i++)
        {
            result += Example22.Payload();
        }
        duration = timer.End();
        return result;
    }
    public object RunJS(JsEnv env, int count, out double duration)
    {
        duration = env.Eval<double>(string.Format(
@"(function() {{
    var Example = require('csharp').Example22;
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
local Example = CS.Example22;
local result = 0;
local start = os.clock();
for i = 0,{0} do
    result = result + Example.Payload();
end

return os.clock() - start, result;
", count - 1));

        duration = 1000 *(double)result[0];
        return result[1];
    }

    public static float Payload()
    {
        return 1 + 2 + 3f;
    }
}
