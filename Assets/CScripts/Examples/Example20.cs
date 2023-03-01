using Puerts;
using XLua;

/// <summary>
/// 静态方法调用
/// 逻辑:   参数求和并返回
/// 参数:   三个值类型参数
/// 返回值: 值类型
/// </summary>
[Test]
public class Example20 : IExecute
{
    public bool Static => true;
    public string Method => "float Payload(int, int, float);";
    public CallTarget Target => CallTarget.ScriptCallCSharp;

    public object RunCS(int count, out double duration)
    {
        float result = 0f;
        Timer timer = new Timer();
        for (var i = 0; i < count; i++)
        {
            result += Example20.Payload(i, i + 1, i + 2f);
        }
        duration = timer.End();
        return result;
    }
    public object RunJS(JsEnv env, int count, out double duration)
    {
        duration = env.Eval<double>(string.Format(
@"(function() {{
    var Example = require('csharp').Example20;
    const start = Date.now();
    var result = 0;
    for(let i = 0; i < {0}; i++){{
        result += Example.Payload(i, i + 1, i + 2);
    }}

    global.result = result;
    return Date.now() - start;
}})()", count));
        return env.Eval<float>("result;");
    }
    public object RunLua(LuaEnv env, int count, out double duration)
    {
        object[] result = env.DoString(string.Format(
@"
local Example = CS.Example20;
local result = 0;
local start = os.clock();
for i = 0,{0} do
    result = result + Example.Payload(i, i + 1, i + 2);
end

return os.clock() - start, result;
", count - 1));

        duration = 1000 *(double)result[0];
        return result[1];
    }

    public static float Payload(int param1, int param2, float param3)
    {
        return param1 + param2 + param3;
    }
}
