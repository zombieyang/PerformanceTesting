
# 软件版本
| Name            | Value             |
| :----           | :----:            |
| Unity           | 2021.3.18f1c1               |
| puerts          | 0               |
| xLua            | 105               |
# 系统环境
| Name            | Value             |
| :----           | :----:            |
| System          | Android OS 12 / API-31 (SP1A.210812.003/compiler01121810)               |
| Memory          | 7601MB             |
| CPU             | ARM64 FP ASIMD AES               |
| CPU-Core        | 8               |
| CPU-Frequency   | 6.374GHz            |
| Editor          | False               |
| Date            | 2023-03-01 17:02:20               |
# 数据对照
* ParameterCompare | 	`无参数 vs 有参数`

| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [:page_facing_up:](//Assets/CScripts/Examples/Example01.cs)       | void Payload();       | √       | ScriptCallCSharp       | 200000       | 0.0       | 25.0       | 23.9       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example10.cs)       | void Payload(int);       | √       | ScriptCallCSharp       | 200000       | 0.0       | 12.0       | 48.2       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example11.cs)       | void Payload(int);       | ×       | ScriptCallCSharp       | 200000       | 0.0       | 15.0       | 88.5       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example12.cs)       | void Payload(int, int, float);       | √       | ScriptCallCSharp       | 200000       | 0.0       | 41.0       | 45.5       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example13.cs)       | void Payload(int, int, float);       | ×       | ScriptCallCSharp       | 200000       | 0.0       | 18.0       | 88.3       | `null`           | `null`           | `null`          |
* Static vs Instance | 	`静态函数 vs 实例函数`

| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [:page_facing_up:](//Assets/CScripts/Examples/Example01.cs)       | void Payload();       | √       | ScriptCallCSharp       | 200000       | 0.0       | 25.0       | 23.9       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example02.cs)       | void Payload();       | ×       | ScriptCallCSharp       | 200000       | 0.0       | 31.0       | 65.7       | `null`           | `null`           | `null`          |
* xyz vs Vector3 | 	`xyz传参 vs Vector3传参`

| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [:page_facing_up:](//Assets/CScripts/Examples/Example32.cs)       | Quaternion Payload(Transform, float, float, float);       | √       | ScriptCallCSharp       | 200000       | 32.9       | 77.0       | 133.9       | (0.19029, 0.27796, 0.38369, 0.85983)           | (0.19029, 0.27796, 0.38369, 0.85983)           | (0.19029, 0.27796, 0.38369, 0.85983)          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example33.cs)       | Quaternion Payload(Transform, float, float, float);       | ×       | ScriptCallCSharp       | 200000       | 33.0       | 76.0       | 176.8       | (0.19029, 0.27796, 0.38369, 0.85983)           | (0.19029, 0.27796, 0.38369, 0.85983)           | (0.19029, 0.27796, 0.38369, 0.85983)          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example34.cs)       | Quaternion Payload(Transform, Vector3);       | √       | ScriptCallCSharp       | 200000       | 18.7       | 115.0       | 135.0       | (0.15357, 0.28786, 0.43503, -0.83923)           | (0.15357, 0.28786, 0.43503, -0.83923)           | (0.15357, 0.28786, 0.43503, -0.83923)          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example35.cs)       | Quaternion Payload(Transform, Vector3);       | ×       | ScriptCallCSharp       | 200000       | 18.7       | 113.0       | 174.6       | (0.15357, 0.28786, 0.43503, -0.83923)           | (0.15357, 0.28786, 0.43503, -0.83923)           | (0.15357, 0.28786, 0.43503, -0.83923)          |
# 所有数据
| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [:page_facing_up:](//Assets/CScripts/Examples/Example01.cs)       | void Payload();       | √       | ScriptCallCSharp       | 200000       | 0.0       | 25.0       | 23.9       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example02.cs)       | void Payload();       | ×       | ScriptCallCSharp       | 200000       | 0.0       | 31.0       | 65.7       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example10.cs)       | void Payload(int);       | √       | ScriptCallCSharp       | 200000       | 0.0       | 12.0       | 48.2       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example11.cs)       | void Payload(int);       | ×       | ScriptCallCSharp       | 200000       | 0.0       | 15.0       | 88.5       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example12.cs)       | void Payload(int, int, float);       | √       | ScriptCallCSharp       | 200000       | 0.0       | 41.0       | 45.5       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example13.cs)       | void Payload(int, int, float);       | ×       | ScriptCallCSharp       | 200000       | 0.0       | 18.0       | 88.3       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example20.cs)       | float Payload(int, int, float);       | √       | ScriptCallCSharp       | 200000       | 0.2       | 23.0       | 47.7       | 5.999976E+10           | 6.00003E+10           | 60000300000          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example21.cs)       | float Payload(int, int, float);       | ×       | ScriptCallCSharp       | 200000       | 0.2       | `fail`       | 90.4       | 5.999976E+10           | 6.00003E+10           | 60000300000          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example22.cs)       | float Payload();       | √       | ScriptCallCSharp       | 200000       | 0.1       | 26.0       | 30.9       | 1200000           | 1200000           | 1200000          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example23.cs)       | float Payload();       | ×       | ScriptCallCSharp       | 200000       | 0.1       | 19.0       | 71.6       | 1200000           | 1200000           | 1200000          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example30.cs)       | Quaternion Payload(Transform);       | √       | ScriptCallCSharp       | 200000       | 18.8       | 77.0       | 103.4       | (-0.57196, -0.56204, -0.56203, -0.20272)           | (-0.57196, -0.56204, -0.56203, -0.20272)           | (-0.57196, -0.56204, -0.56203, -0.20272)          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example31.cs)       | Quaternion Payload(Transform);       | ×       | ScriptCallCSharp       | 200000       | 18.8       | 70.0       | 146.0       | (-0.57196, -0.56204, -0.56203, -0.20272)           | (-0.57196, -0.56204, -0.56203, -0.20272)           | (-0.57196, -0.56204, -0.56203, -0.20272)          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example32.cs)       | Quaternion Payload(Transform, float, float, float);       | √       | ScriptCallCSharp       | 200000       | 32.9       | 77.0       | 133.9       | (0.19029, 0.27796, 0.38369, 0.85983)           | (0.19029, 0.27796, 0.38369, 0.85983)           | (0.19029, 0.27796, 0.38369, 0.85983)          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example33.cs)       | Quaternion Payload(Transform, float, float, float);       | ×       | ScriptCallCSharp       | 200000       | 33.0       | 76.0       | 176.8       | (0.19029, 0.27796, 0.38369, 0.85983)           | (0.19029, 0.27796, 0.38369, 0.85983)           | (0.19029, 0.27796, 0.38369, 0.85983)          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example34.cs)       | Quaternion Payload(Transform, Vector3);       | √       | ScriptCallCSharp       | 200000       | 18.7       | 115.0       | 135.0       | (0.15357, 0.28786, 0.43503, -0.83923)           | (0.15357, 0.28786, 0.43503, -0.83923)           | (0.15357, 0.28786, 0.43503, -0.83923)          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example35.cs)       | Quaternion Payload(Transform, Vector3);       | ×       | ScriptCallCSharp       | 200000       | 18.7       | 113.0       | 174.6       | (0.15357, 0.28786, 0.43503, -0.83923)           | (0.15357, 0.28786, 0.43503, -0.83923)           | (0.15357, 0.28786, 0.43503, -0.83923)          |