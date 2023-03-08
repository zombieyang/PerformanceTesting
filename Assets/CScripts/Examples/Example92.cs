using Puerts;
using XLua;

/// <summary>
/// 静态方法调用
/// 逻辑:   无
/// 参数:   无
/// 返回值: 无
/// </summary>
[Test]
public class Example92 : IExecute
{
    public bool Static => true;
    public string Method => "payload(): number";
    public CallTarget Target => CallTarget.ScriptCallScript;

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
    function Payload() {{ return 1 + 2 + 3; }}
    var result = 0;
    const start = Date.now();
    for(let i = 0; i < {0}; i++){{
        result += Payload();
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
local function Payload(n)
    return 1 + 2 + 3
end

local result = 0;
local start = os.clock();
for i = 0,{0} do
    result = result + Payload();
end

return os.clock() - start, result;
", count - 1));

        duration = 1000 * (double)result[0];
        return result[1];
    }

    public static float Payload()
    {
        return 1 + 2 + 3f;
    }
}
