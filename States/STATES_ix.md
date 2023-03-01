
# 软件版本
| Name            | Value             |
| :----           | :----:            |
| Unity           | 2021.3.18f1c1               |
| puerts          | 0               |
| xLua            | 105               |
# 系统环境
| Name            | Value             |
| :----           | :----:            |
| System          | iOS 16.0               |
| Memory          | 3758MB             |
| CPU             | arm64e               |
| CPU-Core        | 6               |
| CPU-Frequency   | 0GHz            |
| Editor          | False               |
| Date            | 2023-03-01 17:25:50               |
# 数据对照
* ParameterCompare | 	`无参数 vs 有参数`

| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [:page_facing_up:](//Assets/CScripts/Examples/Example01.cs)       | void Payload();       | √       | ScriptCallCSharp       | 200000       | 0.0       | 16.0       | 5.9       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example10.cs)       | void Payload(int);       | √       | ScriptCallCSharp       | 200000       | 0.0       | 23.0       | 0.2       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example11.cs)       | void Payload(int);       | ×       | ScriptCallCSharp       | 200000       | 0.0       | 27.0       | 10.2       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example12.cs)       | void Payload(int, int, float);       | √       | ScriptCallCSharp       | 200000       | 0.0       | 36.0       | 10.1       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example13.cs)       | void Payload(int, int, float);       | ×       | ScriptCallCSharp       | 200000       | 0.0       | 41.0       | 20.6       | `null`           | `null`           | `null`          |
* Static vs Instance | 	`静态函数 vs 实例函数`

| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [:page_facing_up:](//Assets/CScripts/Examples/Example01.cs)       | void Payload();       | √       | ScriptCallCSharp       | 200000       | 0.0       | 16.0       | 5.9       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example02.cs)       | void Payload();       | ×       | ScriptCallCSharp       | 200000       | 0.0       | 21.0       | 10.1       | `null`           | `null`           | `null`          |
* xyz vs Vector3 | 	`xyz传参 vs Vector3传参`

| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [:page_facing_up:](//Assets/CScripts/Examples/Example32.cs)       | Quaternion Payload(Transform, float, float, float);       | √       | ScriptCallCSharp       | 200000       | 38.8       | 60.0       | 50.7       | (0.19029, 0.27796, 0.38369, 0.85983)           | (0.19029, 0.27796, 0.38369, 0.85983)           | (0.19029, 0.27796, 0.38369, 0.85983)          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example33.cs)       | Quaternion Payload(Transform, float, float, float);       | ×       | ScriptCallCSharp       | 200000       | 38.8       | 62.0       | 51.3       | (0.19029, 0.27796, 0.38369, 0.85983)           | (0.19029, 0.27796, 0.38369, 0.85983)           | (0.19029, 0.27796, 0.38369, 0.85983)          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example34.cs)       | Quaternion Payload(Transform, Vector3);       | √       | ScriptCallCSharp       | 200000       | 12.3       | 45.0       | 40.4       | (0.15357, 0.28786, 0.43503, -0.83923)           | (0.00000, 0.00000, 0.00000, 1.00000)           | (0.15357, 0.28786, 0.43503, -0.83923)          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example35.cs)       | Quaternion Payload(Transform, Vector3);       | ×       | ScriptCallCSharp       | 200000       | 12.4       | 48.0       | 54.8       | (0.15357, 0.28786, 0.43503, -0.83923)           | (0.00000, 0.00000, 0.00000, 1.00000)           | (0.15357, 0.28786, 0.43503, -0.83923)          |
# 所有数据
| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [:page_facing_up:](//Assets/CScripts/Examples/Example01.cs)       | void Payload();       | √       | ScriptCallCSharp       | 200000       | 0.0       | 16.0       | 5.9       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example02.cs)       | void Payload();       | ×       | ScriptCallCSharp       | 200000       | 0.0       | 21.0       | 10.1       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example10.cs)       | void Payload(int);       | √       | ScriptCallCSharp       | 200000       | 0.0       | 23.0       | 0.2       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example11.cs)       | void Payload(int);       | ×       | ScriptCallCSharp       | 200000       | 0.0       | 27.0       | 10.2       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example12.cs)       | void Payload(int, int, float);       | √       | ScriptCallCSharp       | 200000       | 0.0       | 36.0       | 10.1       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example13.cs)       | void Payload(int, int, float);       | ×       | ScriptCallCSharp       | 200000       | 0.0       | 41.0       | 20.6       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example20.cs)       | float Payload(int, int, float);       | √       | ScriptCallCSharp       | 200000       | 0.3       | 54.0       | 10.5       | 5.999976E+10           | 6.00003E+10           | 60000300000          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example21.cs)       | float Payload(int, int, float);       | ×       | ScriptCallCSharp       | 200000       | 0.3       | `fail`       | 11.0       | 5.999976E+10           | 6.00003E+10           | 60000300000          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example22.cs)       | float Payload();       | √       | ScriptCallCSharp       | 200000       | 0.2       | 30.0       | 0.2       | 1200000           | 1200000           | 1200000          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example23.cs)       | float Payload();       | ×       | ScriptCallCSharp       | 200000       | 0.3       | 36.0       | 10.6       | 1200000           | 1200000           | 1200000          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example30.cs)       | Quaternion Payload(Transform);       | √       | ScriptCallCSharp       | 200000       | 12.4       | 39.0       | 40.6       | (-0.57196, -0.56204, -0.56203, -0.20272)           | (-0.57196, -0.56204, -0.56203, -0.20272)           | (-0.57196, -0.56204, -0.56203, -0.20272)          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example31.cs)       | Quaternion Payload(Transform);       | ×       | ScriptCallCSharp       | 200000       | 12.4       | 40.0       | 40.7       | (-0.57196, -0.56204, -0.56203, -0.20272)           | (-0.57196, -0.56204, -0.56203, -0.20272)           | (-0.57196, -0.56204, -0.56203, -0.20272)          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example32.cs)       | Quaternion Payload(Transform, float, float, float);       | √       | ScriptCallCSharp       | 200000       | 38.8       | 60.0       | 50.7       | (0.19029, 0.27796, 0.38369, 0.85983)           | (0.19029, 0.27796, 0.38369, 0.85983)           | (0.19029, 0.27796, 0.38369, 0.85983)          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example33.cs)       | Quaternion Payload(Transform, float, float, float);       | ×       | ScriptCallCSharp       | 200000       | 38.8       | 62.0       | 51.3       | (0.19029, 0.27796, 0.38369, 0.85983)           | (0.19029, 0.27796, 0.38369, 0.85983)           | (0.19029, 0.27796, 0.38369, 0.85983)          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example34.cs)       | Quaternion Payload(Transform, Vector3);       | √       | ScriptCallCSharp       | 200000       | 12.3       | 45.0       | 40.4       | (0.15357, 0.28786, 0.43503, -0.83923)           | (0.00000, 0.00000, 0.00000, 1.00000)           | (0.15357, 0.28786, 0.43503, -0.83923)          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example35.cs)       | Quaternion Payload(Transform, Vector3);       | ×       | ScriptCallCSharp       | 200000       | 12.4       | 48.0       | 54.8       | (0.15357, 0.28786, 0.43503, -0.83923)           | (0.00000, 0.00000, 0.00000, 1.00000)           | (0.15357, 0.28786, 0.43503, -0.83923)          |