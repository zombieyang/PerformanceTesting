using Puerts;
using XLua;

/// <summary>
/// 静态方法调用
/// 逻辑:   参数求和并返回
/// 参数:   三个值类型参数
/// 返回值: 值类型
/// </summary>
[Test]
public class Example21 : IExecute
{
    public bool Static => false;
    public string Method => "float Payload(int, int, float);";
    public CallTarget Target => CallTarget.ScriptCallCSharp;

    public object RunCS(int count, out double duration)
    {
        float result = 0f;
        var obj = new Example21();
        Timer timer = new Timer();
        for (var i = 0; i < count; i++)
        {
            result += obj.Payload(i, i + 1, i + 2f);
        }
        duration = timer.End();
        return result;
    }
    public object RunJS(JsEnv env, int count, out double duration)
    {
        duration = env.Eval<double>(string.Format(
@"(function() {{
    var Example = new (require('csharp').Example21)();
    var result = 0;
    const start = Date.now();
    for(let i = 0; i < {0}; i++){{
        result += Example.Payload(i, i + 1, i + 2);
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
local Example = CS.Example21();
local result = 0;
local start = os.clock();
for i = 0,{0} do
    result = result + Example:Payload(i, i + 1, i + 2);
end

return os.clock() - start, result;
", count - 1));

        duration = 1000 *(double)result[0];
        return result[1];
    }

    public float Payload(int param1, int param2, float param3)
    {
        return param1 + param2 + param3;
    }
}
