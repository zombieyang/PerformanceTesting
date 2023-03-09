import fs, { readFileSync, writeFileSync } from 'node:fs'
import path, { dirname, join } from 'node:path'
import { program } from 'commander';
import { rm, exec, cd, cp, mkdir, mv} from "@puerts/shell-util"
import assert from 'node:assert';
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

program.option("--unity <profileOrPath>", "The Unity binary")
program.option("--platform <platform>", "platform")
program.parse()
const options = program.opts();

///////////////////////////////////////////////////
(async function () {
    if (['ios', 'android', 'osx', 'win'].indexOf(options.platform) == -1) return console.error('invalid platform: ' + options.platform);
    runBuild(options.platform);
})().catch(err => {
    console.log(`error occured! code: ${err.message}. please view log.txt`);
});


async function runBuild(platform) 
{
    console.log("[Puer] finding unity");
    let unityPath = "";
    if (path.isAbsolute(options.unity)) {
        unityPath = options.unity
        
    } else {
        console.error("invalid unity path: " + options.unity);
        process.exit(1);
    }
    let execIndex = 0;
    function execUnity(args) {
        const ret = exec(`${unityPath} -batchmode -quit -projectPath "${pwd}" -logFile "buildlog-${platform}/log${execIndex++}.txt" ${args}`);
        assert.equal(ret.code, 0);

        return ret;
    }
    function restoreMeta() {
        cd(`${pwd}/puerts`)
        rm('-rf', `${pwd}/puerts/unity/Assets/core/upm/Plugins/Android`);
        rm('-rf', `${pwd}/puerts/unity/Assets/core/upm/Plugins/iOS`);
        exec(`git restore ${pwd}/puerts/unity/Assets/core/upm/Plugins/Android`);
        exec(`git restore ${pwd}/puerts/unity/Assets/core/upm/Plugins/iOS`);
        exec(`git restore ${pwd}/puerts/unity/Assets/core/upm/Plugins/macOS`);
        exec(`git restore ${pwd}/puerts/unity/Assets/core/upm/Plugins/x86_64`);
        cd(pwd);
    }
    let platformChar = {'win': 'w', 'osx': 'o', 'ios': 'i', 'android': 'a'}[platform];

    rm("-rf", `${pwd}/Assets/Gen`);
    rm("-rf", `${pwd}/Assets/Gen.meta`);
    rm("-rf", `${pwd}/Assets/XLua/Gen`);
    rm("-rf", `${pwd}/Assets/XLua/Gen.meta`);
    rm("-rf", `${pwd}/STATES.md`);
    cd(`${pwd}/puerts`)
    exec(`git restore .`);
    exec(`git clean -fd`);
    cd(pwd)
    
    console.log("[Puer] Building PuertsPlugin");
    cd(`${pwd}/puerts/unity/native_src`)
    assert.equal(0, exec(`node ../cli make --backend v8_9.4`).code);
    cd(pwd)

    // build v1 plugin
    console.log("[Puer] v1 start");
    cd(`${pwd}/puerts/unity/native_src`)
    assert.equal(0, exec(`node ../cli make v${platformChar}8`).code);
    cd(pwd)

    // build
    console.log("[Puer] Building testplayer for reflection mode");
    writeFileSync(`${pwd}/Assets/csc.rsp`, '-define:PUERTS_CPP_OUTPUT_TO_NATIVE_SRC_UPM;')
    execUnity(`-executeMethod Puerts.Editor.Generator.UnityMenu.GenerateMacroHeader`);
    if (platform == 'ios') mkdir("-p", `${pwd}/build/ir1`)
    execUnity(`-executeMethod CommandLineTests.BuildInBatchMode --platform ${platform} --dist ${platformChar}r1`);

    // // 生成v1 static wrapper
    console.log("[Puer] Generating wrapper");
    execUnity(`-executeMethod CommandLineTests.GenV1`);
    rm("-rf", `${pwd}/Library/ScriptAssemblies/Assembly-CSharp.dll`);
    // build
    console.log("[Puer] Building testplayer for wrapper mode");
    if (platform == 'ios') mkdir("-p", `${pwd}/build/iw1`)
    execUnity(`-executeMethod CommandLineTests.BuildInBatchMode --platform ${platform} --dist ${platformChar}w1`);
    
    console.log("[Puer] v2 start");
    writeFileSync(`${pwd}/Assets/csc.rsp`, `
-define:PUERTS_CPP_OUTPUT_TO_NATIVE_SRC_UPM
-define:EXPERIMENTAL_IL2CPP_PUERTS
    `)
    
    console.log("[Puer] Generating FunctionBridge");
    execUnity(`-executeMethod PuertsIl2cpp.Editor.Generator.UnityMenu.GenV2`);
    mv(`${pwd}/Assets/Gen/link.xml`, `${pwd}/Assets/`);
    
    console.log("[Puer] Building PuertsPlugin Il2Cpp");
    restoreMeta();
    cd(`${pwd}/puerts/unity/native_src_il2cpp`)
    assert.equal(0, exec(`node ../cli make v${platformChar}8`).code);
    cd(pwd)

    //build
    console.log("[Puer] Building testplayer for il2cpp version wrapper mode");
    if (platform == 'ios') mkdir("-p", `${pwd}/build/iw2`)
    execUnity(`-executeMethod CommandLineTests.BuildInBatchMode --platform ${platform} --dist ${platformChar}w2`);
    if (platform == 'ios') cp('-r', join(dirname(unityPath), '../il2cpp/external/google'), `${pwd}/build/iw2/Libraries/external/`);
    
    rm("-rf", `${pwd}/puerts/unity/native_src_il2cpp/Src/FunctionBridge.Gen.h`);
    rm("-rf", `${pwd}/Assets/Gen`);
    rm("-rf", `${pwd}/Assets/Gen.meta`);
    rm("-rf", `${pwd}/Assets/XLua/Gen`);
    rm("-rf", `${pwd}/Assets/XLua/Gen.meta`);

    console.log("[Puer] Generating FunctionBridge");
    execUnity(`-executeMethod PuertsIl2cpp.Editor.Generator.UnityMenu.GenV2`);
    execUnity(`-executeMethod PuertsIl2cpp.Editor.Generator.UnityMenu.GenerateCppWrappersInConfigure`);
    mv(`${pwd}/Assets/Gen/link.xml`, `${pwd}/Assets/`);
    
    console.log("[Puer] Building PuertsPlugin Il2Cpp");
    restoreMeta();
    cd(`${pwd}/puerts/unity/native_src_il2cpp`)
    exec(`node ../cli make v${platformChar}8`);
    cd(pwd)
    
    //build
    console.log("[Puer] Building testplayer for il2cpp version reflection mode");
    if (platform == 'ios') mkdir("-p", `${pwd}/build/ir2`)
    execUnity(`-executeMethod CommandLineTests.BuildInBatchMode --platform ${platform} --dist ${platformChar}r2`);
    if (platform == 'ios') cp('-r', join(dirname(unityPath), '../il2cpp/external/google'), `${pwd}/build/ir2/Libraries/external/`);

}
