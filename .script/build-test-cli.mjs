import fs from 'node:fs'
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
    if (['ios', 'android'].indexOf(options.platform) == -1) return console.error('invalid platform: ' + options.platform);
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

    rm("-rf", `${pwd}/Assets/Gen`);
    rm("-rf", `${pwd}/Assets/Gen.meta`);
    rm("-rf", `${pwd}/Assets/XLua/Gen`);
    rm("-rf", `${pwd}/Assets/XLua/Gen.meta`);
    rm("-rf", `${pwd}/STATES.md`);
    
    console.log("[Puer] Building PuertsPlugin");
    cd(`${pwd}/puerts/unity/native_src`)
    assert.equal(0, exec(`node ../cli make v${platform == 'ios' ? 'i' : 'a'}8`).code);
    assert.equal(0, exec(`node ../cli make --backend v8_9.4`).code);
    cd(pwd)

    // build
    console.log("[Puer] Building testplayer for reflection mode");
    execUnity(`-executeMethod Puerts.Editor.Generator.UnityMenu.GenerateMacroHeader`);
    mv(`${pwd}/Assets/Gen/unityenv_for_puerts.h`, `${pwd}/puerts/unity/Assets/core/upm/Plugins/puerts_il2cpp/`);
    if (platform == 'ios') mkdir("-p", `${pwd}/build/ib`)
    execUnity(`-executeMethod CommandLineTests.Build${platform == 'ios' ? 'iOS' : 'Android'}B`);

    // // 生成v1 static wrapper
    console.log("[Puer] Generating wrapper");
    // execUnity(`-executeMethod Puerts.Editor.Generator.UnityMenu.GenV1`);
    execUnity(`-executeMethod CommandLineTests.GenV1`);
    rm("-rf", `${pwd}/Library/ScriptAssemblies`);
    // build
    console.log("[Puer] Building testplayer for wrapper mode");
    if (platform == 'ios') mkdir("-p", `${pwd}/build/ic`)
    execUnity(`-executeMethod CommandLineTests.Build${platform == 'ios' ? 'iOS' : 'Android'}C`);
    
    console.log("[Puer] Generating FunctionBridge");
    // execUnity(`-executeMethod PuertsIl2cpp.Editor.Generator.UnityMenu.GenerateCppWrappers`);
    // execUnity(`-executeMethod PuertsIl2cpp.Editor.Generator.UnityMenu.GenerateExtensionMethodInfos`);
    // execUnity(`-executeMethod PuertsIl2cpp.Editor.Generator.UnityMenu.GenerateLinkXML`);
    execUnity(`-executeMethod PuertsIl2cpp.Editor.Generator.UnityMenu.GenV2`);
    mv(`${pwd}/Assets/Gen/link.xml`, `${pwd}/Assets/`);
    cp(`${pwd}/Assets/Gen/FunctionBridge.Gen.h`, `${pwd}/puerts/unity/native_src_il2cpp/Src/`);
    mv(`${pwd}/Assets/Gen/unityenv_for_puerts.h`, `${pwd}/puerts/unity/Assets/core/upm/Plugins/puerts_il2cpp/`);
    
    
    console.log("[Puer] Building PuertsPlugin Il2Cpp");
    cd(`${pwd}/puerts/unity/native_src_il2cpp`)
    assert.equal(0, exec(`node ../cli make v${platform == 'ios' ? 'i' : 'a'}8`).code);
    cd(pwd)
    //build
    console.log("[Puer] Building testplayer for il2cpp version wrapper mode");
    if (platform == 'ios') mkdir("-p", `${pwd}/build/iy`)
    execUnity(`-executeMethod CommandLineTests.Build${platform == 'ios' ? 'iOS' : 'Android'}Y`);
    if (platform == 'ios') cp('-r', join(dirname(unityPath), '../il2cpp/external/google'), `${pwd}/build/iy/Libraries/external/`);

    rm("-rf", `${pwd}/Assets/Gen`);
    rm("-rf", `${pwd}/Assets/Gen.meta`);
    rm("-rf", `${pwd}/Assets/XLua/Gen`);
    rm("-rf", `${pwd}/Assets/XLua/Gen.meta`);

    console.log("[Puer] Generating FunctionBridge");
    execUnity(`-executeMethod PuertsIl2cpp.Editor.Generator.UnityMenu.GenerateCppWrappersInConfigure`);
    cp(`${pwd}/Assets/Gen/FunctionBridge.Gen.h`, `${pwd}/puerts/unity/native_src_il2cpp/Src/`);

    console.log("[Puer] Building PuertsPlugin Il2Cpp");
    cd(`${pwd}/puerts/unity/native_src_il2cpp`)
    exec(`node ../cli make v${platform == 'ios' ? 'i' : 'a'}8`);
    cd(pwd)
    //build
    console.log("[Puer] Building testplayer for il2cpp version reflection mode");
    if (platform == 'ios') mkdir("-p", `${pwd}/build/ix`)
    execUnity(`-executeMethod CommandLineTests.Build${platform == 'ios' ? 'iOS' : 'Android'}X`);
    if (platform == 'ios') cp('-r', join(dirname(unityPath), '../il2cpp/external/google'), `${pwd}/build/iy/Libraries/external/`);

``}
