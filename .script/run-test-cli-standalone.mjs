import fs from 'node:fs'
import path from 'node:path'
import { program } from 'commander';
import { rm, exec, cd, cp, mkdir, mv} from "@puerts/shell-util"
const pwd = process.cwd();

if (!fs.existsSync(`${pwd}/package.json`) || !fs.existsSync(`${pwd}/Packages`)) {
    console.error("[Puer] invalid directory, please run in the root of PerformanceTesting");
    process.exit(1);``
}
if (!fs.existsSync(`${pwd}/node_modules`)) {
    console.log("[Puer] installing node_modules");
    require('child_process').execSync('npm i')
}

////////////////////////////////////////////////////

program.option("--unity <profileOrPath>", "The Unity binary", "lastUse")
program.parse()
const options = program.opts();

///////////////////////////////////////////////////
(async function () {
    console.log("[Puer] finding unity");
    let unityPath = "";
    if (path.isAbsolute(options.unity)) {
        unityPath = options.unity
    
    } else {
        console.error("invalid unity path: " + options.unity);
        process.exit(1);
    }

    rm("-rf", `${pwd}/Assets/Gen`);
    rm("-rf", `${pwd}/Assets/Gen.meta`);
    rm("-rf", `${pwd}/Assets/XLua/Gen`);
    rm("-rf", `${pwd}/Assets/XLua/Gen.meta`);
    rm("-rf", `${pwd}/STATES.md`);
    
    cd(`${pwd}/puerts/unity/native_src`)
    exec(`node ../cli make vw6d`);
    cd(pwd)

    
    // rm("-rf", `${pwd}/Library/ScriptAssemblies`);
    // // build
    // console.log("[Puer] Building testplayer for reflect mode");
    // mkdir("-p", `${pwd}/build/b`)
    // await exec(`${unityPath} -batchmode -quit -projectPath "${pwd}" -executeMethod CommandLineTests.BuildB -logFile "log.txt"`);
    // // 运行反射测试
    // console.log("[Puer] Running test in reflect mode");
    // await exec(`${pwd}/build/b/PerformanceTest.exe`);
    // // postbuild
    // rm("-rf", `${pwd}/States/STATES_${options.pkg}_reflect.md`);
    // mv(`${pwd}/build/b/STATES.md`, `${pwd}/States/STATES_${options.pkg}_reflect.md`);

    // 生成v1 static wrapper
    console.log("[Puer] Generating wrapper");
    exec(`${unityPath} -batchmode -quit -projectPath "${pwd}" -executeMethod CommandLineTests.GenCode -logFile "log.txt"`);
    rm("-rf", `${pwd}/Library/ScriptAssemblies`);
    //build
    console.log("[Puer] Building testplayer for wrapper mode");
    mkdir("-p", `${pwd}/build/c`)
    await exec(`${unityPath} -batchmode -quit -projectPath "${pwd}" -executeMethod CommandLineTests.BuildC -logFile "log.txt"`);
    // 运行静态测试
    console.log("[Puer] Running test in wrapper mode");
    await exec(`${pwd}/build/c/PerformanceTest.exe`);
    // postbuild
    rm("-rf", `${pwd}/States/STATES_wrapper.md`);
    mv(`${pwd}/build/c/STATES.md`, `${pwd}/States/STATES_wrapper.md`);

    console.log("[Puer] Generating FunctionBridge");
    exec(`${unityPath} -batchmode -quit -projectPath "${pwd}" -executeMethod PuertsIl2cpp.Editor.Generator.UnityMenu.GenerateCppWrappers -logFile "log.txt"`);
    cp(`${pwd}/Assets/Gen/FunctionBridge.Gen.h`, `${pwd}/puerts/unity/native_src_il2cpp/Src/`);

    cd(`${pwd}/puerts/unity/native_src_il2cpp`)
    exec(`node ../cli make vw6d`);
    cd(pwd)
    //build
    console.log("[Puer] Building testplayer for il2cpp version wrapper mode");
    mkdir("-p", `${pwd}/build/z`)
    exec(`${unityPath} -batchmode -quit -projectPath "${pwd}" -executeMethod CommandLineTests.BuildZ -logFile "log.txt"`);
    // 运行静态测试
    console.log("[Puer] Running test in wrapper mode");
    exec(`${pwd}/build/z/PerformanceTest.exe`);
    // postbuild
    rm("-rf", `${pwd}/States/STATES_v2_wrapper.md`);
    mv(`${pwd}/build/z/STATES.md`, `${pwd}/States/STATES_v2_wrapper.md`);


    // console.log(`[Puer] done. result outputed to "${pwd}/States/STATES_${options.pkg}_static.md" and "${pwd}/States/STATES_${options.pkg}_reflect.md`);
})().catch(err => {
    console.log(`error occured! code: ${err.message}. please view log.txt`);
});