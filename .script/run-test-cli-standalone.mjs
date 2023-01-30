import fs from 'node:fs'
import path, { dirname } from 'node:path'
import { program, Option } from 'commander';
import { rm, mv, exec, mkdir} from "@puerts/shell-util"
import { fileURLToPath } from 'node:url';
const pwd = process.cwd();
const __dirname = dirname(fileURLToPath(import.meta.url));

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
program.requiredOption("--pkg <pkg>", "The path of puerts package")
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
    
    const upmSetting = JSON.parse(fs.readFileSync(`${__dirname}/../Packages/manifest.json`))
    let use = `file:../${options.pkg}`
    console.log("[Puer] changing puerts to: " + use);
    upmSetting.dependencies['com.tencent.puerts.core'] = use;
    fs.writeFileSync(`${__dirname}/../Packages/manifest.json`, JSON.stringify(upmSetting));
    
    rm("-rf", `${pwd}/Assets/Gen`);
    rm("-rf", `${pwd}/Assets/Gen.meta`);
    rm("-rf", `${pwd}/Assets/XLua/Gen`);
    rm("-rf", `${pwd}/Assets/XLua/Gen.meta`);
    rm("-rf", `${pwd}/STATES.md`);
    
    
    // 运行测试
    mkdir("-p", `${pwd}/build/b`)
    rm("-rf", `${pwd}/Library/ScriptAssemblies`);
    console.log("[Puer] Building testplayer for reflect mode");
    await exec(`${unityPath} -batchmode -quit -projectPath "${pwd}" -executeMethod CommandLineTests.BuildB -logFile "log.txt"`);
    console.log("[Puer] Running test in reflect mode");
    await exec(`${pwd}/build/b/PerformanceTest.exe`);
    
    rm("-rf", `${pwd}/States/STATES_${options.pkg}_reflect.md`);
    mv(`${pwd}/build/b/STATES.md`, `${pwd}/States/STATES_${options.pkg}_reflect.md`);

    // 生成v1 static wrapper
    console.log("[Puer] Generating wrapper");
    await exec(`${unityPath} -batchmode -quit -projectPath "${pwd}" -executeMethod CommandLineTests.GenCode -logFile "log.txt"`);
    rm("-rf", `${pwd}/Library/ScriptAssemblies`);
    console.log("[Puer] Building testplayer for wrapper mode");
    // 运行测试
    await exec(`${unityPath} -batchmode -quit -projectPath "${pwd}" -executeMethod CommandLineTests.BuildC -logFile "log.txt"`);
    console.log("[Puer] Running test in wrapper mode");
    await exec(`${pwd}/build/c/PerformanceTest.exe`);
    
    rm("-rf", `${pwd}/States/STATES_${options.pkg}_wrapper.md`);
    mv(`${pwd}/build/c/STATES.md`, `${pwd}/States/STATES_${options.pkg}_static.md`);

    console.log(`[Puer] done. result outputed to "${pwd}/States/STATES_${options.pkg}_static.md" and "${pwd}/States/STATES_${options.pkg}_reflect.md`);
})().catch(err => {
    console.log(`error occured! code: ${err.message}. please view log.txt`);
});