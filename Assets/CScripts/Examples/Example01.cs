using Puerts;
using XLua;

/// <summary>
/// 静态方法调用
/// 逻辑:   无
/// 参数:   无
/// 返回值: 无
/// </summary>
[Test]
[TestGroup("Static vs Instance", 1, Desc = "静态函数 vs 实例函数")]
[TestGroup("ParameterCompare", 1, Desc = "无参数 vs 有参数")]
public class Example01 : IExecute
{
    public bool Static => true;
    public string Method => "void Payload();";
    public CallTarget Target => CallTarget.ScriptCallCSharp;

    public object RunCS(int count, out double duration)
    {
        Timer timer = new Timer();
        for (var i = 0; i < count; i++)
        {
            Example01.Payload();
        }
        duration = timer.End();
        return null;
    }

    public object RunJS(JsEnv env, int count, out double duration)
    {
        duration = env.Eval<double>(string.Format(
@"(function() {{
    var Example = require('csharp').Example01;
    let start = Date.now();
    for(let i = 0; i < {0}; i++){{
        Example.Payload();
    }}
    return Date.now() - start;
}})()", count));
        return null;
    }
    public object RunLua(LuaEnv env, int count, out double duration)
    {
        duration = 1000 *(double)env.DoString(string.Format(
@"
local Example = CS.Example01;
local start = os.clock();
for i = 1,{0} do
    Example.Payload();
end
return os.clock() - start;
", count))[0];
        return null;
    }

    public static void Payload()
    {

    }
}
