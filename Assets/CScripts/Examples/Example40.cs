using Puerts;
using UnityEngine;
using XLua;
using System.Collections.Generic;

/// <summary>
/// 数组操作
/// 逻辑:   调用SetValue
/// </summary>
[Test]
[TestGroup("Array.SetValue")]
public class Example40 : IExecute
{
    public bool Static => false;
    public string Method => "void Array.SetValue(value, index);";
    public CallTarget Target => CallTarget.ScriptCallCSharp;

    public object RunCS(int count, out double duration)
    {
        List<double[]> list2D = new List<double[]>();
        for (int i = 0; i < 1000; i++) {
            list2D.Add((double[])System.Array.CreateInstance(typeof(double), 1000));
        }
        double[][] array2D = list2D.ToArray();

        Timer timer = new Timer();
        for (var i = 0; i < 1000; i++)
        {
            for (var j = 0; j < 1000; j++)
            {
                array2D[i].SetValue(1, j);
            }
        }
        duration = timer.End();
        return 1;
    }
    public object RunJS(JsEnv env, int count, out double duration)
    {
        duration = env.Eval<double>(string.Format(
 @"(function() {{
    const count = 1000;
    const arrArr = [];
    for(var i = 0; i < count; i++) {{
        arrArr.push(CS.System.Array.CreateInstance(puer.$typeof(CS.System.Double), count));
    }}

    const start = Date.now();
    for(var i = 0; i < count; i++) {{
        for(var j = 0 ;  j < count; j++) {{
            arrArr[i].SetValue(1, j);
        }}
    }}
    return Date.now() - start;
}})()", count));
        return 1;
    }
    public object RunLua(LuaEnv env, int count, out double duration)
    {
        object[] result = env.DoString(string.Format(
@"
local Example = CS.Example35();
local arrArr = {{}}
local count = 1000
for i = 1, count do
    table.insert(arrArr, CS.System.Array.CreateInstance(typeof(CS.System.Double), 1000))
end

local start = os.clock();
for i = 1, count do
    for j = 0, count - 1 do
        arrArr[i]:SetValue(1, j);
    end
end

return os.clock() - start, 1;
", count - 1));

        duration = 1000 *(double)result[0];
        return result[1];
    }

    public void Payload(Transform transform, Vector3 eulers)
    {
        transform.Rotate(eulers);
    }
}
