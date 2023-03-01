
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
| Date            | 2023-03-01 16:45:04               |
# 数据对照
* ParameterCompare | 	`无参数 vs 有参数`

| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [:page_facing_up:](//Assets/CScripts/Examples/Example01.cs)       | void Payload();       | √       | ScriptCallCSharp       | 200000       | 0.0       | 87.0       | 50.5       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example10.cs)       | void Payload(int);       | √       | ScriptCallCSharp       | 200000       | 0.0       | 110.0       | 60.9       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example11.cs)       | void Payload(int);       | ×       | ScriptCallCSharp       | 200000       | 0.0       | 136.0       | 132.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example12.cs)       | void Payload(int, int, float);       | √       | ScriptCallCSharp       | 200000       | 0.0       | 181.0       | 121.7       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example13.cs)       | void Payload(int, int, float);       | ×       | ScriptCallCSharp       | 200000       | 0.0       | 193.0       | 185.0       | `null`           | `null`           | `null`          |
* Static vs Instance | 	`静态函数 vs 实例函数`

| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [:page_facing_up:](//Assets/CScripts/Examples/Example01.cs)       | void Payload();       | √       | ScriptCallCSharp       | 200000       | 0.0       | 87.0       | 50.5       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example02.cs)       | void Payload();       | ×       | ScriptCallCSharp       | 200000       | 0.0       | 111.0       | 118.3       | `null`           | `null`           | `null`          |
* xyz vs Vector3 | 	`xyz传参 vs Vector3传参`

| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [:page_facing_up:](//Assets/CScripts/Examples/Example32.cs)       | Quaternion Payload(Transform, float, float, float);       | √       | ScriptCallCSharp       | 200000       | 39.0       | 229.0       | 163.4       | (0.19029, 0.27796, 0.38369, 0.85983)           | (0.19029, 0.27796, 0.38369, 0.85983)           | (0.19029, 0.27796, 0.38369, 0.85983)          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example33.cs)       | Quaternion Payload(Transform, float, float, float);       | ×       | ScriptCallCSharp       | 200000       | 38.8       | 256.0       | 243.1       | (0.19029, 0.27796, 0.38369, 0.85983)           | (0.19029, 0.27796, 0.38369, 0.85983)           | (0.19029, 0.27796, 0.38369, 0.85983)          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example34.cs)       | Quaternion Payload(Transform, Vector3);       | √       | ScriptCallCSharp       | 200000       | 12.4       | 189.0       | 121.4       | (0.15357, 0.28786, 0.43503, -0.83923)           | (0.15357, 0.28786, 0.43503, -0.83923)           | (0.15357, 0.28786, 0.43503, -0.83923)          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example35.cs)       | Quaternion Payload(Transform, Vector3);       | ×       | ScriptCallCSharp       | 200000       | 14.2       | 211.0       | 192.0       | (0.15357, 0.28786, 0.43503, -0.83923)           | (0.15357, 0.28786, 0.43503, -0.83923)           | (0.15357, 0.28786, 0.43503, -0.83923)          |
# 所有数据
| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [:page_facing_up:](//Assets/CScripts/Examples/Example01.cs)       | void Payload();       | √       | ScriptCallCSharp       | 200000       | 0.0       | 87.0       | 50.5       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example02.cs)       | void Payload();       | ×       | ScriptCallCSharp       | 200000       | 0.0       | 111.0       | 118.3       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example10.cs)       | void Payload(int);       | √       | ScriptCallCSharp       | 200000       | 0.0       | 110.0       | 60.9       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example11.cs)       | void Payload(int);       | ×       | ScriptCallCSharp       | 200000       | 0.0       | 136.0       | 132.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example12.cs)       | void Payload(int, int, float);       | √       | ScriptCallCSharp       | 200000       | 0.0       | 181.0       | 121.7       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example13.cs)       | void Payload(int, int, float);       | ×       | ScriptCallCSharp       | 200000       | 0.0       | 193.0       | 185.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example20.cs)       | float Payload(int, int, float);       | √       | ScriptCallCSharp       | 200000       | 0.3       | 195.0       | 141.8       | 5.999976E+10           | 6.00003E+10           | 60000300000          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example21.cs)       | float Payload(int, int, float);       | ×       | ScriptCallCSharp       | 200000       | 0.3       | `fail`       | 210.3       | 5.999976E+10           | 6.00003E+10           | 60000300000          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example22.cs)       | float Payload();       | √       | ScriptCallCSharp       | 200000       | 0.3       | 112.0       | 69.8       | 1200000           | 1200000           | 1200000          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example23.cs)       | float Payload();       | ×       | ScriptCallCSharp       | 200000       | 0.3       | 126.0       | 141.7       | 1200000           | 1200000           | 1200000          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example30.cs)       | Quaternion Payload(Transform);       | √       | ScriptCallCSharp       | 200000       | 12.4       | 154.0       | 101.2       | (-0.57196, -0.56204, -0.56203, -0.20272)           | (-0.57196, -0.56204, -0.56203, -0.20272)           | (-0.57196, -0.56204, -0.56203, -0.20272)          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example31.cs)       | Quaternion Payload(Transform);       | ×       | ScriptCallCSharp       | 200000       | 12.3       | 171.0       | 162.5       | (-0.57196, -0.56204, -0.56203, -0.20272)           | (-0.57196, -0.56204, -0.56203, -0.20272)           | (-0.57196, -0.56204, -0.56203, -0.20272)          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example32.cs)       | Quaternion Payload(Transform, float, float, float);       | √       | ScriptCallCSharp       | 200000       | 39.0       | 229.0       | 163.4       | (0.19029, 0.27796, 0.38369, 0.85983)           | (0.19029, 0.27796, 0.38369, 0.85983)           | (0.19029, 0.27796, 0.38369, 0.85983)          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example33.cs)       | Quaternion Payload(Transform, float, float, float);       | ×       | ScriptCallCSharp       | 200000       | 38.8       | 256.0       | 243.1       | (0.19029, 0.27796, 0.38369, 0.85983)           | (0.19029, 0.27796, 0.38369, 0.85983)           | (0.19029, 0.27796, 0.38369, 0.85983)          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example34.cs)       | Quaternion Payload(Transform, Vector3);       | √       | ScriptCallCSharp       | 200000       | 12.4       | 189.0       | 121.4       | (0.15357, 0.28786, 0.43503, -0.83923)           | (0.15357, 0.28786, 0.43503, -0.83923)           | (0.15357, 0.28786, 0.43503, -0.83923)          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example35.cs)       | Quaternion Payload(Transform, Vector3);       | ×       | ScriptCallCSharp       | 200000       | 14.2       | 211.0       | 192.0       | (0.15357, 0.28786, 0.43503, -0.83923)           | (0.15357, 0.28786, 0.43503, -0.83923)           | (0.15357, 0.28786, 0.43503, -0.83923)          |