using Puerts;
using XLua;

/// <summary>
/// 实例方法调用
/// 逻辑:   无
/// 参数:   无
/// 返回值: 无
/// </summary>
[Test]
[TestGroup("Static vs Instance")]
public class Example02 : IExecute
{
    public bool Static => false;
    public string Method => "void Payload();";
    public CallTarget Target => CallTarget.ScriptCallCSharp;

    public object RunCS(int count, out double duration)
    {
        var Example = new Example02();
        Timer timer = new Timer();
        for (var i = 0; i < count; i++)
        {
            Example.Payload();
        }
        duration = timer.End();
        return null;
    }

    public object RunJS(JsEnv env, int count, out double duration)
    {
        duration = env.Eval<double>(string.Format(
@"(function() {{
    var Example = new (require('csharp').Example02)();
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
local Example = CS.Example02();
local start = os.clock();
for i = 1,{0} do
    Example:Payload();
end
return os.clock() - start;
", count))[0];
        return null;
    }

    public void Payload()
    {

    }
}