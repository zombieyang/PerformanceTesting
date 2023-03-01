using Puerts;
using XLua;

/// <summary>
/// 静态方法调用
/// 逻辑:   无
/// 参数:   三个值类型参数
/// 返回值: 无
/// </summary>
[Test]
[TestGroup("ParameterCompare")]
public class Example13 : IExecute
{
    public bool Static => false;
    public string Method => "void Payload(int, int, float);";
    public CallTarget Target => CallTarget.ScriptCallCSharp;

    public object RunCS(int count, out double duration)
    {
        var obj = new Example13();
        Timer timer = new Timer();
        for (var i = 0; i < count; i++)
        {
            obj.Payload(i, i + 1, i + 2f);
        }
        duration = timer.End();
        return null;
    }
    public object RunJS(JsEnv env, int count, out double duration)
    {
        duration = env.Eval<double>(string.Format(
@"(function() {{
    var Example = new (require('csharp').Example13)();
    const start = Date.now();
    for(let i = 0; i < {0}; i++){{
        Example.Payload(1, i + 1, i + 2);
    }}
    return Date.now() - start;
}})()", count));
        return null;
    }
    public object RunLua(LuaEnv env, int count, out double duration)
    {
        duration = 1000 *(double)env.DoString(string.Format(
@"
local Example = CS.Example13();
local start = os.clock();
for i = 1,{0} do
    Example:Payload(1, i + 1, i + 2);
end
return os.clock() - start;
", count))[0];
        return null;
    }

    public void Payload(int param1, int param2, float param3)
    {

    }
}
