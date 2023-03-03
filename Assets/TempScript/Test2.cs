using UnityEngine;
using System;
using System.Collections.Generic;
using Puerts;
using System.IO;
using XLua;

public class Test2 : MonoBehaviour
{
    public static int TestCount = 100;

    JsEnv jsEnv;

    private Action update;
    
    void Start()
    {
        jsEnv = new JsEnv();
        count = 0;
        var jsCode = @"
            function test0(count) {
                var cnt = count * 1000;

                var go = new CS.UnityEngine.GameObject('_');
                var transform = go.transform;

                for (var i = 1; i <= cnt; i++) {
                    transform.position = transform.position;
                }

                CS.UnityEngine.GameObject.Destroy(go);
            }

            function test1(count) {
                var cnt = count * 100;

                var go = new CS.UnityEngine.GameObject('_');
                var transform = go.transform;
                var Vector3 = CS.UnityEngine.Vector3;

                for (var i = 1; i <= cnt; i++) {
                    transform.Rotate(Vector3.up, 1);
                }

                CS.UnityEngine.GameObject.Destroy(go);
            }

            function test2(count) {
                var cnt = count * 1000;

                var go = new CS.UnityEngine.GameObject('_');
                var transform = go.transform;
                var Vector3 = CS.UnityEngine.Vector3

                for (var i = 1; i <= cnt; i++) {
                    var tmp = new Vector3(i, i, i);
                    var x = tmp.x;
                    var y = tmp.y;
                    var z = tmp.z;
                    var r = x + y * z;
                }
            }

            function test3(count) {
                var cnt = count * 10;
                var GameObject = CS.UnityEngine.GameObject
                for (var i = 1; i <= cnt; i++) {
                    var tmp = new GameObject('___');
                    GameObject.Destroy(tmp);
                }
            }

            function test4(count) {
                var cnt = count * 10;
                var typeofsmr = puer.$typeof(CS.UnityEngine.SkinnedMeshRenderer);
                var GameObject = CS.UnityEngine.GameObject
                for (var i = 1; i <= cnt; i++) {
                    var tmp = new GameObject('___');
                    tmp.AddComponent(typeofsmr);
                    var c = tmp.GetComponent(typeofsmr);
                    c.receiveShadows = false;
                    GameObject.Destroy(tmp);
                }
            }

            function test5(count) {
                var cnt = count * 1000;
                var Input = CS.UnityEngine.Input
                for (var i = 1; i <= cnt; i++) {
                    var tmp = Input.mousePosition;
                }
            }

            function test6(count) {
                var cnt = count * 1000;
                var Vector3 = CS.UnityEngine.Vector3
                for (var i = 1; i <= cnt; i++) {
                    var tmp = new Vector3(i, i, i);
                    Vector3.Normalize(tmp);
                }
            }

            function test7(count) {
                var cnt = count * 100;
                var Quaternion = CS.UnityEngine.Quaternion;
                var Random = CS.UnityEngine.Random;
                for (var i = 1; i <= cnt; i++) {
                    var t1 = Quaternion.Euler(i, i, i);
                    var t2 = Quaternion.Euler(i * 2, i * 2, i * 2);
                    Quaternion.Slerp(t1, t2, Random.Range(0.1, 0.9));
                }
            }
            function test8(count) {
                const cnt = count * 10000;
                let total = 0;
                for (let i = 1; i <= cnt; i++) {
                    total = total + i - (i / 2) * (i + 3) / (i + 5);
                }
            }

            function test9(count) {
                const cnt = count * 1000;
                var Vector3 = CS.UnityEngine.Vector3;
                for (let i = 1; i <= cnt; i++) {
                    const tmp0 = new Vector3(1, 2, 3);
                    const tmp1 = new Vector3(4, 5, 6);
                    const tmp2 = Vector3.op_Addition(tmp0, tmp1);
                }
            }
            test0(1);
            test1(1);
            test2(1);
            test3(1);
            test4(1);
            test5(1);
            test6(1);
            test7(1);
            test8(1);
            test9(1);

            let start;
            start = Date.now();
            test0(CS.Test2.TestCount);
            console.log('test 0 in js: ', (Date.now() - start) / 1000);
            start = Date.now();
            test1(CS.Test2.TestCount);
            console.log('test 1 in js: ', (Date.now() - start) / 1000);
            start = Date.now();
            test2(CS.Test2.TestCount);
            console.log('test 2 in js: ', (Date.now() - start) / 1000);
            start = Date.now();
            test3(CS.Test2.TestCount);
            console.log('test 3 in js: ', (Date.now() - start) / 1000);
            start = Date.now();
            test4(CS.Test2.TestCount);
            console.log('test 4 in js: ', (Date.now() - start) / 1000);
            start = Date.now();
            test5(CS.Test2.TestCount);
            console.log('test 5 in js: ', (Date.now() - start) / 1000);
            start = Date.now();
            test6(CS.Test2.TestCount);
            console.log('test 6 in js: ', (Date.now() - start) / 1000);
            start = Date.now();
            test7(CS.Test2.TestCount);
            console.log('test 7 in js: ', (Date.now() - start) / 1000);
            start = Date.now();
            test8(CS.Test2.TestCount);
            console.log('test 8 in js: ', (Date.now() - start) / 1000);
            start = Date.now();
            test9(CS.Test2.TestCount);
            console.log('test 9 in js: ', (Date.now() - start) / 1000);
        ";
        jsEnv.Eval(jsCode);
        jsEnv.Dispose();

        LuaEnv luaenv = new LuaEnv();
        var luaCode = @"
            local function test0(count)
                local cnt = count * 1000

                local go = CS.UnityEngine.GameObject('_')
                local transform = go.transform

                for i = 1, cnt do
                    transform.position = transform.position
                end

                CS.UnityEngine.GameObject.Destroy(go)
            end

            local function test1(count)
                local cnt = count * 100

                local go = CS.UnityEngine.GameObject('_')
                local transform = go.transform

                for i = 1, cnt do
                    transform:Rotate(CS.UnityEngine.Vector3.up, 1)
                end

                CS.UnityEngine.GameObject.Destroy(go)
            end

            local function test2(count)
                local cnt = count * 1000

                local go = CS.UnityEngine.GameObject('_')
                local transform = go.transform

                for i = 1, cnt do
                    local tmp = CS.UnityEngine.Vector3(i, i, i)
                    local x = tmp.x
                    local y = tmp.y
                    local z = tmp.z
                    local r = x + y * z
                end
            end

            local function test3(count)
                local cnt = count * 10
                for i = 1, cnt do
                    local tmp = CS.UnityEngine.GameObject('___')
                    CS.UnityEngine.GameObject.Destroy(tmp)
                end
            end

            local function test4(count)
                local cnt = count * 10
                for i = 1, cnt do
                    local tmp = CS.UnityEngine.GameObject('___')
                    tmp:AddComponent(typeof(CS.UnityEngine.SkinnedMeshRenderer))
                    local c = tmp:GetComponent(typeof(CS.UnityEngine.SkinnedMeshRenderer))
                    c.receiveShadows = false
                    CS.UnityEngine.GameObject.Destroy(tmp)
                end
            end

            local function test5(count)
                local cnt = count * 1000
                for i = 1, cnt do
                    local tmp = CS.UnityEngine.Input.mousePosition;
                end
            end

            local function test6(count)
                local cnt = count * 1000
                for i = 1, cnt do
                    local tmp = CS.UnityEngine.Vector3(i, i, i)
                    CS.UnityEngine.Vector3.Normalize(tmp)
                end
            end

            local function test7(count)
                local cnt = count * 100
                for i = 1, cnt do
                    local t1 = CS.UnityEngine.Quaternion.Euler(i, i, i)
                    local t2 = CS.UnityEngine.Quaternion.Euler(i * 2, i * 2, i * 2)
                    CS.UnityEngine.Quaternion.Slerp(t1, t2, CS.UnityEngine.Random.Range(0.1, 0.9))
                end
            end

            local function test8(count)
                local cnt = count * 10000
                local total = 0
                for i = 1, cnt do
                    total = total + i - (i / 2) * (i + 3) / (i + 5)
                end
            end

            local function test9(count)
                local cnt = count * 1000
                for i = 1, cnt do
                    local tmp0 = CS.UnityEngine.Vector3(1, 2, 3)
                    local tmp1 = CS.UnityEngine.Vector3(4, 5, 6)
                    local tmp2 = tmp0 + tmp1
                end
            end

            test0(1);
            test1(1);
            test2(1);
            test3(1);
            test4(1);
            test5(1);
            test6(1);
            test7(1);
            test8(1);
            test9(1);

            local start;
            start = os.clock();
            test0(CS.Test2.TestCount);
            print('test 0 in lua: ', os.clock() - start);
            start = os.clock();
            test1(CS.Test2.TestCount);
            print('test 1 in lua: ', os.clock() - start);
            start = os.clock();
            test2(CS.Test2.TestCount);
            print('test 2 in lua: ', os.clock() - start);
            start = os.clock();
            test3(CS.Test2.TestCount);
            print('test 3 in lua: ', os.clock() - start);
            start = os.clock();
            test4(CS.Test2.TestCount);
            print('test 4 in lua: ', os.clock() - start);
            start = os.clock();
            test5(CS.Test2.TestCount);
            print('test 5 in lua: ', os.clock() - start);
            start = os.clock();
            test6(CS.Test2.TestCount);
            print('test 6 in lua: ', os.clock() - start);
            start = os.clock();
            test7(CS.Test2.TestCount);
            print('test 7 in lua: ', os.clock() - start);
            start = os.clock();
            test8(CS.Test2.TestCount);
            print('test 8 in lua: ', os.clock() - start);
            start = os.clock();
            test9(CS.Test2.TestCount);
            print('test 9 in lua: ', os.clock() - start);
        ";
        luaenv.DoString(luaCode);
        luaenv.Dispose();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private int count;

    private void OnDestroy()
    {
    }
}
