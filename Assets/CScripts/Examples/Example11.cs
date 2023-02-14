using Puerts;
using XLua;

/// <summary>
/// 静态方法调用
/// 逻辑:   无
/// 参数:   一个值类型参数
/// 返回值: 无
/// </summary>
[Test]
[TestGroup("ParameterCompare")]
public class Example11 : IExecute
{
    public bool Static => false;
    public string Method => "void Payload(int);";
    public CallTarget Target => CallTarget.ScriptCallCSharp;

    public object RunCS(int count)
    {
        var obj = new Example11();
        for (var i = 0; i < count; i++)
        {
            obj.Payload(i);
        }
        return null;
    }
    public object RunJS(JsEnv env, int count)
    {
        env.Eval(string.Format(
@"
var Example = new (require('csharp').Example11)();
for(let i = 0; i < {0}; i++){{
    Example.Payload(i);
}}
", count));
        return null;
    }
    public object RunLua(LuaEnv env, int count)
    {
        env.DoString(string.Format(
@"
local Example = CS.Example11();
for i = 1,{0} do
    Example:Payload(i);
end
", count));
        return null;
    }

    public void Payload(int param1)
    {

    }
}
