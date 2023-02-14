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

    public object RunCS(int count)
    {
        var Example = new Example02();
        for (var i = 0; i < count; i++)
        {
            Example.Payload();
        }
        return null;
    }

    public object RunJS(JsEnv env, int count)
    {
        env.Eval(string.Format(
@"
var Example = new (require('csharp').Example02)();
for(let i = 0; i < {0}; i++){{
    Example.Payload();
}}
", count));
        return null;
    }

    public object RunLua(LuaEnv env, int count)
    {
        env.DoString(string.Format(
@"
local Example = CS.Example02();
for i = 1,{0} do
    Example:Payload();
end
", count));
        return null;
    }

    public void Payload()
    {

    }
}