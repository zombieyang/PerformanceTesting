
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
| Date            | 2023-03-01 17:09:07               |
# 数据对照
* ParameterCompare | 	`无参数 vs 有参数`

| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [:page_facing_up:](//Assets/CScripts/Examples/Example01.cs)       | void Payload();       | √       | ScriptCallCSharp       | 200000       | 0.0       | 10.0       | 50.6       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example10.cs)       | void Payload(int);       | √       | ScriptCallCSharp       | 200000       | 0.0       | 8.0       | 49.9       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example11.cs)       | void Payload(int);       | ×       | ScriptCallCSharp       | 200000       | 0.0       | 9.0       | 90.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example12.cs)       | void Payload(int, int, float);       | √       | ScriptCallCSharp       | 200000       | 0.0       | 8.0       | 68.6       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example13.cs)       | void Payload(int, int, float);       | ×       | ScriptCallCSharp       | 200000       | 0.0       | 28.0       | 96.7       | `null`           | `null`           | `null`          |
* Static vs Instance | 	`静态函数 vs 实例函数`

| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [:page_facing_up:](//Assets/CScripts/Examples/Example01.cs)       | void Payload();       | √       | ScriptCallCSharp       | 200000       | 0.0       | 10.0       | 50.6       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example02.cs)       | void Payload();       | ×       | ScriptCallCSharp       | 200000       | 0.0       | 11.0       | 92.5       | `null`           | `null`           | `null`          |
* xyz vs Vector3 | 	`xyz传参 vs Vector3传参`

| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [:page_facing_up:](//Assets/CScripts/Examples/Example32.cs)       | Quaternion Payload(Transform, float, float, float);       | √       | ScriptCallCSharp       | 200000       | 32.9       | 37.0       | 132.0       | (0.19029, 0.27796, 0.38369, 0.85983)           | (0.19029, 0.27796, 0.38369, 0.85983)           | (0.19029, 0.27796, 0.38369, 0.85983)          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example33.cs)       | Quaternion Payload(Transform, float, float, float);       | ×       | ScriptCallCSharp       | 200000       | 33.0       | 38.0       | 173.0       | (0.19029, 0.27796, 0.38369, 0.85983)           | (0.19029, 0.27796, 0.38369, 0.85983)           | (0.19029, 0.27796, 0.38369, 0.85983)          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example34.cs)       | Quaternion Payload(Transform, Vector3);       | √       | ScriptCallCSharp       | 200000       | 18.7       | 36.0       | 141.4       | (0.15357, 0.28786, 0.43503, -0.83923)           | (0.15357, 0.28786, 0.43503, -0.83923)           | (0.15357, 0.28786, 0.43503, -0.83923)          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example35.cs)       | Quaternion Payload(Transform, Vector3);       | ×       | ScriptCallCSharp       | 200000       | 18.7       | 38.0       | 178.6       | (0.15357, 0.28786, 0.43503, -0.83923)           | (0.15357, 0.28786, 0.43503, -0.83923)           | (0.15357, 0.28786, 0.43503, -0.83923)          |
# 所有数据
| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [:page_facing_up:](//Assets/CScripts/Examples/Example01.cs)       | void Payload();       | √       | ScriptCallCSharp       | 200000       | 0.0       | 10.0       | 50.6       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example02.cs)       | void Payload();       | ×       | ScriptCallCSharp       | 200000       | 0.0       | 11.0       | 92.5       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example10.cs)       | void Payload(int);       | √       | ScriptCallCSharp       | 200000       | 0.0       | 8.0       | 49.9       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example11.cs)       | void Payload(int);       | ×       | ScriptCallCSharp       | 200000       | 0.0       | 9.0       | 90.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example12.cs)       | void Payload(int, int, float);       | √       | ScriptCallCSharp       | 200000       | 0.0       | 8.0       | 68.6       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example13.cs)       | void Payload(int, int, float);       | ×       | ScriptCallCSharp       | 200000       | 0.0       | 28.0       | 96.7       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example20.cs)       | float Payload(int, int, float);       | √       | ScriptCallCSharp       | 200000       | 0.2       | 31.0       | 52.4       | 5.999976E+10           | 6.00003E+10           | 60000300000          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example21.cs)       | float Payload(int, int, float);       | ×       | ScriptCallCSharp       | 200000       | 0.2       | `fail`       | 95.6       | 5.999976E+10           | 6.00003E+10           | 60000300000          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example22.cs)       | float Payload();       | √       | ScriptCallCSharp       | 200000       | 0.1       | 8.0       | 49.0       | 1200000           | 1200000           | 1200000          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example23.cs)       | float Payload();       | ×       | ScriptCallCSharp       | 200000       | 0.1       | 10.0       | 87.2       | 1200000           | 1200000           | 1200000          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example30.cs)       | Quaternion Payload(Transform);       | √       | ScriptCallCSharp       | 200000       | 18.6       | 35.0       | 104.4       | (-0.57196, -0.56204, -0.56203, -0.20272)           | (-0.57196, -0.56204, -0.56203, -0.20272)           | (-0.57196, -0.56204, -0.56203, -0.20272)          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example31.cs)       | Quaternion Payload(Transform);       | ×       | ScriptCallCSharp       | 200000       | 18.7       | 36.0       | 141.5       | (-0.57196, -0.56204, -0.56203, -0.20272)           | (-0.57196, -0.56204, -0.56203, -0.20272)           | (-0.57196, -0.56204, -0.56203, -0.20272)          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example32.cs)       | Quaternion Payload(Transform, float, float, float);       | √       | ScriptCallCSharp       | 200000       | 32.9       | 37.0       | 132.0       | (0.19029, 0.27796, 0.38369, 0.85983)           | (0.19029, 0.27796, 0.38369, 0.85983)           | (0.19029, 0.27796, 0.38369, 0.85983)          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example33.cs)       | Quaternion Payload(Transform, float, float, float);       | ×       | ScriptCallCSharp       | 200000       | 33.0       | 38.0       | 173.0       | (0.19029, 0.27796, 0.38369, 0.85983)           | (0.19029, 0.27796, 0.38369, 0.85983)           | (0.19029, 0.27796, 0.38369, 0.85983)          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example34.cs)       | Quaternion Payload(Transform, Vector3);       | √       | ScriptCallCSharp       | 200000       | 18.7       | 36.0       | 141.4       | (0.15357, 0.28786, 0.43503, -0.83923)           | (0.15357, 0.28786, 0.43503, -0.83923)           | (0.15357, 0.28786, 0.43503, -0.83923)          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example35.cs)       | Quaternion Payload(Transform, Vector3);       | ×       | ScriptCallCSharp       | 200000       | 18.7       | 38.0       | 178.6       | (0.15357, 0.28786, 0.43503, -0.83923)           | (0.15357, 0.28786, 0.43503, -0.83923)           | (0.15357, 0.28786, 0.43503, -0.83923)          |