using Puerts;
using XLua;

public interface IExecute
{
    bool Static { get; }
    string Method { get; }
    CallTarget Target { get; }
    object RunCS(int count, out double time);
    object RunJS(JsEnv env, int count, out double time);
    object RunLua(LuaEnv env, int count, out double time);
}