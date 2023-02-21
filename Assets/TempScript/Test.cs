using UnityEngine;
using System;
using System.Collections.Generic;
using Puerts;
using System.IO;
using XLua;

[CSharpCallLua]
public delegate int SimpleDelegate(int a, int v);

[CSharpCallLua]
public delegate void ObjectArgDelegate(Calculator calculator);

[CSharpCallLua]
public delegate Calculator ObjectRetDelegate();

[CSharpCallLua]
public delegate void VectorArgDelegate(Vector3 v);

[CSharpCallLua]
public delegate void VarParamDelegate1(string p, params int[] ps);

[CSharpCallLua]
public delegate void VarParamDelegate2(string p1, float p2, params string[] ps);

[CSharpCallLua]
public delegate void VarParamDelegate3(string p1, float p2, params Vector3[] ps);

struct TestStruct : IDisposable
{
    public void Dispose()
    {
        Debug.Log("TestStruct.Dispose");
    }
}

public class AnthorClass
{
    public void Foo()
    {
        Debug.Log("AnthorClass.Foo,a=" + a);
    }

    int a = 988432;
}

public enum EIII
{
    I,
    J,
    K
}

public enum ESSS : short
{
    L,
    M,
    N
}

[LuaCallCSharp]
public class Calculator
{
    public int x;
    public int y;

    public Vector3 v3 = new Vector3(8, 8, 8);


    public Calculator()
    {
        Debug.Log("Calculator()");
        x = 82;
        y = 2;
    }

    public Calculator(int a, int b = 100)
    {
        Debug.Log("Calculator("+ a + "," + b + ")");
        x = a;
        y = b;
    }

    public static int Add(int a, int b)
    {
        //Debug.Log("Calculator.Add invoked a =" + a + ", b=" + b);
        return a + b;
    }

    public int Id(int a)
    {
        //Debug.Log("Calculator.Id invoked a =" + a + ", x=" + x + ",y=" + y);
        return a;
    }

    public static void VecTest(Vector3 vector)
    {
        //Debug.Log(string.Format("Calculator.VecTest invoked vector ={0}, {1}, {2}", vector.x, vector.y, vector.z));
    }

    public static void PrintVec(Vector3 vector)
    {
        Debug.Log(string.Format("Calculator.PrintVec invoked vector ={0}, {1}, {2}", vector.x, vector.y, vector.z));
    }

    public Func<int, int, int> simpleDelegate;

    public void SetSimpleDelegate(Func<int, int, int> simpleDelegate)
    {
        this.simpleDelegate = simpleDelegate;
    }

    public int MAdd(int a, int b)
    {
        return a + b;
    }

    public void SetSetSimpleDelegateToMAdd()
    {
        simpleDelegate = MAdd;
    }

    public void SetSetSimpleDelegateToAdd()
    {
        simpleDelegate = Add;
    }

    public void InterfaceArgumnent(IDisposable obj)
    {
        obj.Dispose();
    }

    public static AnthorClass TestLazyLoad()
    {
        return new AnthorClass();
    }

    public void CallInterfaceArgumnentByStruct()
    {
        var s = new TestStruct();
        InterfaceArgumnent(s);
    }

    public void CallSimpleDelegate(int loop)
    {
        //Debug.Log("CallSimpleDelegate loop =" + loop);
        for (int i = 0; i < loop; i++)
        {
            var ret = simpleDelegate == null ? -1 : simpleDelegate(99, i);
            //Debug.Log(string.Format("loop {0}: {1}", i, ret));
        }
    }

    public static int ThrowTest(int a, int b)
    {
        throw new Exception("aabbcc");
    }

    static Calculator calc = new Calculator(87, 65);

    public static Calculator ObjRet()
    {
        return calc;
    }

    public void PrintState()
    {
        Debug.Log("PrintState x=" + x + ",y=" + y + ",v3=" + v3);
    }

    public static Vector3 VecRet()
    {
        return new Vector3(9, 9, 9);
    }

    public static Bounds BoundsRet()
    {
        return new Bounds(new Vector3(7, 6, 5), new Vector3(5, 7, 9));
    }

    public static Vector4 V4Ret()
    {
        return new Vector4(9, 9, 9, 9);
    }

    public EIII EnumRet()
    {
        return EIII.J;
    }

    public int Overload(int a)
    {
        Debug.Log("Overload(int) a=" + a);
        return a + 1;
    }

    public Vector3 Overload(Vector3 a)
    {
        Debug.Log("Overload(Vector3) a=" + a );
        return a + new Vector3(1, 1, 1);
    }

    public JSObject PassJsObject(JSObject o)
    {
        return o;
    }

    int mPP;

    public int PP
    {
        get
        {
            Debug.Log("Get PP");
            return mPP;
        }
        set
        {
            Debug.Log("Set PP:val=" + value);
            mPP = value;
        }
    }

    static float gVV;

    public static float VV
    {
        get
        {
            Debug.Log("Get VV");
            return gVV;
        }
        set
        {
            Debug.Log("Set VV:val=" + value);
            gVV = value;
        }
    }

    public static Vector3 FFV = new Vector3(8, 8, 8);

    public static float FFF = 998;

    public AnthorClass FFAC = new AnthorClass();

    public void IntRef(ref int p1)
    {
        Debug.Log("IntRef:" + p1);
        p1 = 100;
    }

    public void ObjRef(ref object p1)
    {
        Debug.Log("ObjRef:" + p1);
        if (p1 is double)
        {
            p1 = 8899;
        }
        else if (p1 is string)
        {
            p1 = "hehe";
        }
        else
        {
            p1 = this;
        }
    }

    public unsafe void IntPtr(int * p1)
    {
        Debug.Log("IntPtr:" + *p1);
        *p1 = 101;
    }

    public override string ToString()
    {
        return "Calculator..........";
    }

    public void TestEnumInt(EIII p)
    {
        Debug.Log("TestEnumInt:" + p);
    }
    
    public void TestEnumShort(ESSS p)
    {
        Debug.Log("TestEnumShort:" + p);
    }
    
    public void CheckEnumGen(ESSS p1, EIII p2, ESSS p3, EIII p4, ESSS p5, EIII p6 )
    {
    }

    public void TestDateTime1234(System.DateTime d)
    {
        
    }

    public Dictionary<string, string> GetDictionary()
    {
        return new Dictionary<string, string>() {{"k1", "v1"}};
    }

    public void TestParams1(int p, params string[] ps)
    {
        Debug.Log("TestParams1:" + p + "," + ps.Length);
        foreach (var str in ps)
        {
            Debug.Log("TestParams1 string:" + str);
        }
    }
    public void TestParams2(int p, params int[] ps)
    {
        Debug.Log("TestParams2:" + p + "," + ps.Length);
        foreach (var i in ps)
        {
            Debug.Log("TestParams2 int:" + i);
        }
    }
    
    public void TestParams3(params Vector3[] ps)
    {
        Debug.Log("TestParams3:" + ps.Length);
        foreach (var i in ps)
        {
            Debug.Log("TestParams3 vector:" + i);
        }
    }
    
    
    public void TestParams4(params object[] ps)
    {
        Debug.Log("TestParams4:" + ps.Length);
        foreach (var i in ps)
        {
            Debug.Log("TestParams4 object:" + i);
        }
    }

    public void TestObject(object o)
    {
        Debug.Log("TestObject type: " + (o == null ? "null" : o.GetType().ToString()));
    }

    public void DefaultTest(int p1, double p2 = 99.98)
    {
        
    }

    public void TestDateTime(DateTime dt)
    {
        Debug.Log("dt=" + dt);
    }

    public void OptionalTest1(int a = 10)
    {
        Debug.Log("OptionalTest1=" + a);
    }

    public void OptionalTest2(UnityEngine.Vector3 a = default(Vector3))
    {
        var d = default(Vector3);
        Debug.Log("OptionalTest2=" + a + ",default=" + d);
        
    }

    public void OptionalTest3(string a = "aabbcc")
    {
        Debug.Log("OptionalTest3=" + a);
    }
}

public static class CalculatorExtension
{
    public static void M4(this Calculator Self, int a)
    {
        Debug.Log("M4 x=" + Self.x + ",y=" + Self.y + ",a=" + a);
        //Array.Find()
    }
}

public class Test : MonoBehaviour
{
    JsEnv jsEnv;

    private Action update;
    
    void Start()
    {
        /*BindingFlags flag = BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public;
        HashSet<string> allSignature = new HashSet<string>();
        int AllMethodCount = 0;
        foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            //Debug.Log(assembly);
            foreach (Type type in assembly.GetExportedTypes())
            {
                foreach (var mi in type.GetMethods(flag))
                {
                    allSignature.Add(PuertsIl2cpp.NativeAPI.GetMethodSignature(mi));
                    ++AllMethodCount;
                }
                foreach (var ctor in type.GetConstructors(flag))
                {
                    allSignature.Add(PuertsIl2cpp.NativeAPI.GetMethodSignature(ctor));
                    ++AllMethodCount;
                }
            }
        }
        Debug.Log("Assemblies.Count=" + AppDomain.CurrentDomain.GetAssemblies().Length);
        Debug.Log("AllMethodCount=" + AllMethodCount);
        Debug.Log("allSignature.Count=" + allSignature.Count);*/
        
        //JsEnv jsEnv = new JsEnv();
        jsEnv = new JsEnv();
        count = 0;
        var jsCode = @"
            const CalculatorV8 = loadType(jsEnv.GetTypeByString('Calculator'));
            const Vector3 =  loadType(jsEnv.GetTypeByString('UnityEngine.Vector3'));
            const Debug = loadType(jsEnv.GetTypeByString('UnityEngine.Debug'));
            
            const LOOP = 1000000
            Debug.Log(`puerts loop=${LOOP}`)

            const ret = CalculatorV8.Add(88, 99);
            Debug.Log(`88 + 99 = ${ret}`);

            new CalculatorV8(123, 456);

            try {
                new CalculatorV8('123', '456');
            } catch(e){
                Debug.Log(`constructor overload ok:${e}`)
            }

            var obj = new CalculatorV8();
            const r2 = CalculatorV8.Add(89, 99);
            Debug.Log(`89 + 99 = ${r2}`);

            const vvv = CalculatorV8.VecRet();
            CalculatorV8.PrintVec(vvv);
            vvv.Set(9, 8, 7.65)
            CalculatorV8.PrintVec(vvv);
            

            const v3 = new Vector3(9.8, 5.6, 2.3);
            CalculatorV8.PrintVec(v3);

            v3.Set(7, 8, 9)
            CalculatorV8.PrintVec(v3);

            Debug.Log(`v3.x = ${v3.x} v3.y = ${v3.y}, v3.z = ${v3.z}`);
            v3.x = 1
            v3.y = 2
            v3.z = 3
            CalculatorV8.PrintVec(v3);
            Debug.Log(`v3.x = ${v3.x} v3.y = ${v3.y}, v3.z = ${v3.z}`);

            var so = CalculatorV8.ObjRet();
            so.PrintState();
            so.M4(777);

            obj.Id(9999);

            Debug.Log(`obj.PP:${obj.PP}`);
            obj.PP = 100;
            Debug.Log(`obj.PP:${obj.PP}`);

            Debug.Log(`CalculatorV8.VV:${CalculatorV8.VV}`);
            CalculatorV8.VV = 500
            Debug.Log(`CalculatorV8.VV:${CalculatorV8.VV}`);

            Debug.Log(`Vector3.kEpsilon:${Vector3.kEpsilon}`);
            Debug.Log(`CalculatorV8.FFF:${CalculatorV8.FFF}`);
            CalculatorV8.FFF = 9009;
            Debug.Log(`CalculatorV8.FFF:${CalculatorV8.FFF}`);
            CalculatorV8.PrintVec(CalculatorV8.FFV);
            CalculatorV8.FFV = new Vector3(10, 10, 10);
            CalculatorV8.PrintVec(CalculatorV8.FFV);
            obj.FFAC.Foo();

            Debug.Log(`obj.x = ${obj.x} obj.y = ${obj.y}`);

            CalculatorV8.PrintVec(obj.v3);
            obj.v3.Set(1.01, 55, 66);
            CalculatorV8.PrintVec(obj.v3);

            var r = [18];
            obj.IntRef(r);
            Debug.Log(`ref return = ${r[0]}`);
            obj.IntPtr(r);
            Debug.Log(`ptr return = ${r[0]}`);

            obj.ObjRef(r);
            Debug.Log(`objref return = ${r[0]},type=${typeof r[0]}`);
            r[0] = 'abcd';
            obj.ObjRef(r);
            Debug.Log(`objref return = ${r[0]},type=${typeof r[0]}`);
            r[0] = undefined;
            obj.ObjRef(r);
            Debug.Log(`objref return type=${typeof r[0]}`);

            var ao = CalculatorV8.TestLazyLoad();
            ao.Foo();

            Debug.Log(`Calculator.ToString=${obj.ToString()}`); // Calculator.ToString
            Debug.Log(`Vector3.ToString=${v3.ToString()}`); // Vector3.ToString 1.01, 55, 66
            Debug.Log(`System.Object.ToString=${ao.ToString()}`); 

            const jsobj1 = {}
            const jsobj2 = obj.PassJsObject(jsobj1);
            Debug.Log(`t=${typeof jsobj2}, eq=${jsobj1 === jsobj2}`);

            obj.TestParams1(1, '?', '#');
            obj.TestParams1(3);
            obj.TestParams1(7, '!');
            obj.TestParams2(1, 2, 3, 4);
            obj.TestParams2(2);
            obj.TestParams2(2, 8);
            obj.TestParams3(new Vector3(9.8, 5.6, 2.3), new Vector3(77, 88, 99));
            obj.TestParams3(null, new Vector3(77, 88, 99));
            obj.TestParams4(1);
            obj.TestParams4(obj, 1, null, new Vector3(77, 88, 99));

            const dic = obj.GetDictionary();
            Debug.Log(`dic.Count = ${dic.Count}`);

            var start = Date.now();
            for(var i = 0; i < LOOP; i++) {
                CalculatorV8.Add(1, 2);
            }
            Debug.Log(`puerts Add using ${Date.now() - start}`);

            start = Date.now();
            for(var i = 0; i < LOOP; i++) {
                obj.Id(88);
            }
            Debug.Log(`puerts obj.Id(88) using ${Date.now() - start}`);

            start = Date.now();
            for(var i = 0; i < LOOP; i++) {
                CalculatorV8.VecTest(v3);
            }
            Debug.Log(`puerts VecTest using ${Date.now() - start}`);

            obj.SetSimpleDelegate((a, b) => {
                //Debug.Log(`jscallback: a=${a},b=${b}`);
                return a + b;
            });

            start = Date.now();
            obj.CallSimpleDelegate(LOOP);
            Debug.Log(`puerts SimpleDelegate using ${Date.now() - start}`);

            obj.SetSimpleDelegate(null);

            obj.simpleDelegate = (a, b) => {
                Debug.Log(`set delegate field: a=${a},b=${b}`);
                return a + b;
            };
            obj.CallSimpleDelegate(1);

            obj.TestEnumInt(0);
            obj.TestEnumInt(1);
            obj.TestEnumInt(2);
            obj.TestEnumShort(0);
            obj.TestEnumShort(1);
            obj.TestEnumShort(2);
            const EIII = loadType(jsEnv.GetTypeByString('EIII'));
            const ESSS = loadType(jsEnv.GetTypeByString('ESSS'));
            console.log(`EIII.I=${EIII.I},${typeof EIII.I}`);
            console.log(`EIII.J=${EIII.J}`);
            console.log(`EIII.K=${EIII.K}`);
            console.log(`ESSS.L=${ESSS.L},${typeof ESSS.L}`);
            console.log(`ESSS.M=${ESSS.M}`);
            console.log(`ESSS.N=${ESSS.N}`);

            start = Date.now();
            for(var i = 0; i < LOOP; i++) {
                CalculatorV8.ObjRet();
            }
            Debug.Log(`puerts ObjRet using ${Date.now() - start}`);

            start = Date.now();
            for(var i = 0; i < LOOP; i++) {
                v3.Set(7, 8, 9)
            }
            Debug.Log(`puerts Vector.Set using ${Date.now() - start}`);

            start = Date.now();
            for(var i = 0; i < LOOP; i++) {
                const a = obj.x;
            }
            Debug.Log(`puerts obj.x using ${Date.now() - start}`);

            start = Date.now();
            for(var i = 0; i < LOOP; i++) {
                const a = obj.v3;
            }
            Debug.Log(`puerts obj.v3 using ${Date.now() - start}`);

            start = Date.now();
            for(var i = 0; i < LOOP; i++) {
                CalculatorV8.VecRet();
            }
            Debug.Log(`puerts VecRet using ${Date.now() - start}`);

            function NewJsVector(x, y, z) {
                return {x:x, y:y, z:z};
            }

            start = Date.now();
            for(var i = 0; i < LOOP; i++) {
                NewJsVector(i, i, i);
            }
            Debug.Log(`puerts NewJsVector using ${Date.now() - start}`);

            start = Date.now();
            for(var i = 0; i < LOOP; i++) {
                CalculatorV8.V4Ret();;
            }
            Debug.Log(`puerts V4Ret using ${Date.now() - start}`);

            try {
                CalculatorV8.ThrowTest(3, 4);
            } catch(e) {
                Debug.Log(`catch exception:${e}`)
            }

            Debug.Log(`obj.Overload(124) = ${obj.Overload(124)}`);
            CalculatorV8.PrintVec(v3);
            const rrr = obj.Overload(v3);
            CalculatorV8.PrintVec(rrr);

            try {
                obj.Overload('111');
            } catch(e){
                Debug.Log(`method overload ok:${e}`)
            }

            obj.TestObject(null);
            obj.TestObject(1);
            const Int32Value =  loadType(jsEnv.GetTypeByString('Puerts.Int32Value'));
            obj.TestObject(new Int32Value(1));

            const DateTime =  loadType(jsEnv.GetTypeByString('System.DateTime'));
            const jsdate = new Date()
            let csdate = new DateTime(jsdate.getFullYear(), jsdate.getMonth() + 1, jsdate.getDay() + 1, jsdate.getHours(), jsdate.getMinutes(), jsdate.getSeconds(), jsdate.getMilliseconds());
            Debug.Log(`date:${csdate.ToString()}, js date:${jsdate}`)
            obj.TestDateTime(csdate);
            obj.OptionalTest1();
            obj.OptionalTest1(9);
            obj.OptionalTest2();
            obj.OptionalTest2(new Vector3(6, 6, 6));
            obj.OptionalTest3();
            obj.OptionalTest3('john');

            const bounds1 = CalculatorV8.BoundsRet();
            Debug.Log(`center1:${bounds1.center.ToString()}`);
            Debug.Log(`size1:${bounds1.size.ToString()}`);

            const Bounds =  loadType(jsEnv.GetTypeByString('UnityEngine.Bounds'));
            const bounds2 = new Bounds(new Vector3(1, 2, 3), new Vector3(4, 5, 6));
            Debug.Log(`center2:${bounds2.center.ToString()}`);
            Debug.Log(`size2:${bounds2.size.ToString()}`);

            delegate = undefined;
            obj = undefined;
            so = undefined;
            ao = undefined;
            
            gc();
            
        ";
        if (File.Exists("pt.js"))
        {
            Debug.Log("load js code from file");
            jsCode = File.ReadAllText("pt.js");
        }
        jsEnv.Eval(jsCode);
        //GC.Collect();//delegate not expire test
        //GC.WaitForPendingFinalizers();

        Debug.Log("12 = " + jsEnv.Eval<int>("12"));
        Debug.Log("12 = " + jsEnv.Eval<float>("12.12"));
        Debug.Log("42 = " + jsEnv.Eval<byte>("42"));
        Debug.Log("42 = " + jsEnv.Eval<double>("42.42"));
        Debug.Log("info = " + jsEnv.Eval<string>("'hello world'"));
        Debug.Log("==================================");
        Debug.Log("info = " + jsEnv.Eval<string>("'中文'"));

        var sd = jsEnv.Eval<SimpleDelegate>("(x, y) => {log(`lambda x=${x},y=${y}`); return x + y;}");
        Debug.Log("sd(1024, 4096)=" + sd(1024, 4096));

        // var willThrow = jsEnv.Eval<SimpleDelegate>("(x, y) => { throw new Error('Required'); }");
        // try
        // {
        //     willThrow(1, 1);
        // }
        // catch (Exception e)
        // {
        //     Debug.Log("test callback throw ok:" + e);
        // }

        jsEnv.Eval("gc()");

        var vad = jsEnv.Eval<VectorArgDelegate>("x => Debug.Log(`x = ${x.ToString()}`)");
        vad(new Vector3(77, 88, 99));
        
        var d1 = jsEnv.Eval<VarParamDelegate1>("(p1, p2, p3) => Debug.Log(`${p1}, ${p2}, ${p3}`)");
        d1("hello1");
        d1("hello1", 1);
        d1("hello1", 1, 2);
        d1("hello1", 1, 2, 3);
        
        var d2 = jsEnv.Eval<VarParamDelegate2>("(p1, p2, p3, p4) => Debug.Log(`${p1}, ${p2}, ${p3}, ${p4}`)");
        d2("hello2", 1);
        d2("hello2", 1, "x");
        d2("hello2", 1, "y", "z");
        
        var d3 = jsEnv.Eval<VarParamDelegate3>("(p1, p2, p3, p4) => Debug.Log(`${p1}, ${p2}, ${p3 ? p3.ToString() : 'null'}, ${p4 ? p4.ToString() : 'null'}`)");
        d3("hello3", 1);
        d3("hello3", 2, new Vector3(2, 4, 5));
        d3("hello3", 3, new Vector3(7, 8, 9), new Vector3(2, 4, 5));

        update = jsEnv.Eval<Action>(@"
() => {
    for(var i = 0; i < 1000; i++) {
        CalculatorV8.VecRet();
        new Vector3(9.8, 5.6, 2.3)
    }
}
");

        //jsEnv.ExecuteModule("abcdef");
        //jsEnv.Dispose();
        //GC.Collect();//delegate expire test
        //GC.WaitForPendingFinalizers();
        
        LuaEnv luaenv = new LuaEnv();
        var luaCode = @"
            local Add = CS.Calculator.Add
            local LOOP = 1000000
            print('xlua LOOP = ' .. LOOP)

            local start = os.clock();
            for i = 1, LOOP do
                Add(1, 2)
            end
            print('xlua Add using ', os.clock() - start)

            local obj = CS.Calculator()
            start = os.clock();
            for i = 1, LOOP do
                obj:Id(88)
            end
            print('xlua obj:Id(88) using ', os.clock() - start)

            local v3 = CS.UnityEngine.Vector3(9.8, 5.6, 2.3)
            start = os.clock();
            for i = 1, LOOP do
                CS.Calculator.VecTest(v3)
            end
            print('xlua VecTest using ', os.clock() - start)
        
            obj:SetSimpleDelegate(function(a, b) return a + b end);
            
            start = os.clock();
            obj:CallSimpleDelegate(LOOP);
            print('xlua SimpleDelegate using ', os.clock() - start)

            start = os.clock();
            for i = 1, LOOP do
                CS.Calculator.ObjRet()
            end
            print('xlua ObjRet using ', os.clock() - start)

            start = os.clock();
            for i = 1, LOOP do
                v3:Set(7, 8, 9);
            end
            print('xlua Vector.Set using ', os.clock() - start);

            start = os.clock();
            for i = 1, LOOP do
                local a = obj.x
            end
            print('xlua obj.x using ', os.clock() - start);

            start = os.clock();
            for i = 1, LOOP do
                local a = obj.v3
            end
            print('xlua obj.v3 using ', os.clock() - start);

            start = os.clock();
            for i = 1, LOOP do
                CS.Calculator.VecRet()
            end
            print('xlua VecRet using ', os.clock() - start);

   
        ";
        if (File.Exists("pt.lua"))
        {
            Debug.Log("load lua code from file");
            luaCode = File.ReadAllText("pt.lua");
        }
        luaenv.DoString(luaCode);
        luaenv.Dispose();
    }

    // Update is called once per frame
    void Update()
    {
        update();
        if (count++ % 10 == 0)
        {
            Debug.Log("update called:" + count);
        }
    }

    private int count;

    private void OnDestroy()
    {
        jsEnv.Dispose();
    }
}
