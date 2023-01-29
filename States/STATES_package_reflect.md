
# 软件版本
| Name            | Value             |
| :----           | :----:            |
| Unity           | 2021.3.11f1c2               |
| puerts          | 19               |
| xLua            | 105               |
# 系统环境
| Name            | Value             |
| :----           | :----:            |
| System          | Windows 11  (10.0.22000) 64bit               |
| Memory          | 16197MB             |
| CPU             | 12th Gen Intel(R) Core(TM) i5-12400F               |
| CPU-Core        | 12               |
| CPU-Frequency   | 2.496GHz            |
| Editor          | False               |
| Date            | 2023-01-29 22:22:05               |
# 数据对照
* ParameterCompare | 	`无参数 vs 有参数`

| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [:page_facing_up:](//Assets/CScripts/Examples/Example1.cs)       | void Payload();       | √       | ScriptCallCSharp       | 100000       | 0.0       | 35.6       | 18.6       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example3.cs)       | void Payload(int);       | √       | ScriptCallCSharp       | 100000       | 0.0       | 64.9       | 27.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example4.cs)       | void Payload(int, int, float);       | √       | ScriptCallCSharp       | 100000       | 0.0       | 83.5       | 43.2       | `null`           | `null`           | `null`          |
* Static vs Instance | 	`静态函数 vs 实例函数`

| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [:page_facing_up:](//Assets/CScripts/Examples/Example1.cs)       | void Payload();       | √       | ScriptCallCSharp       | 100000       | 0.0       | 35.6       | 18.6       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example2.cs)       | void Payload();       | ×       | ScriptCallCSharp       | 100000       | 0.0       | 45.7       | 39.3       | `null`           | `null`           | `null`          |
* xyz vs Vector3 | 	`xyz传参 vs Vector3传参`

| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [:page_facing_up:](//Assets/CScripts/Examples/Example8.cs)       | Quaternion Payload(Transform, float, float, float);       | √       | ScriptCallCSharp       | 100000       | 12.1       | 126.1       | 68.6       | (-0.09418, -0.14435, -0.19911, -0.96470)           | (-0.09418, -0.14435, -0.19911, -0.96470)           | (-0.09418, -0.14435, -0.19911, -0.96470)          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example9.cs)       | Quaternion Payload(Transform, Vector3);       | √       | ScriptCallCSharp       | 100000       | 8.8       | 126.9       | 56.9       | (-0.27065, -0.50772, -0.76719, -0.28353)           | (-0.27065, -0.50772, -0.76719, -0.28353)           | (-0.27065, -0.50772, -0.76719, -0.28353)          |
# 所有数据
| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [:page_facing_up:](//Assets/CScripts/Examples/Example1.cs)       | void Payload();       | √       | ScriptCallCSharp       | 10000       | 0.0       | 5.0       | 2.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example1.cs)       | void Payload();       | √       | ScriptCallCSharp       | 100000       | 0.0       | 35.6       | 18.6       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example2.cs)       | void Payload();       | ×       | ScriptCallCSharp       | 10000       | 0.0       | 6.0       | 4.5       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example2.cs)       | void Payload();       | ×       | ScriptCallCSharp       | 100000       | 0.0       | 45.7       | 39.3       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example3.cs)       | void Payload(int);       | √       | ScriptCallCSharp       | 10000       | 0.0       | 8.8       | 3.2       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example3.cs)       | void Payload(int);       | √       | ScriptCallCSharp       | 100000       | 0.0       | 64.9       | 27.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example4.cs)       | void Payload(int, int, float);       | √       | ScriptCallCSharp       | 10000       | 0.0       | 8.8       | 5.4       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example4.cs)       | void Payload(int, int, float);       | √       | ScriptCallCSharp       | 100000       | 0.0       | 83.5       | 43.2       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example5.cs)       | float Payload(int, int, float);       | √       | ScriptCallCSharp       | 10000       | 0.0       | 9.5       | 6.0       | 1.500183E+08           | 1.50015E+08           | 150015000          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example5.cs)       | float Payload(int, int, float);       | √       | ScriptCallCSharp       | 100000       | 0.0       | 87.9       | 56.1       | 1.500022E+10           | 1.500015E+10           | 15000150000          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example6.cs)       | float Payload();       | √       | ScriptCallCSharp       | 10000       | 0.0       | 5.2       | 3.0       | 60000           | 60000           | 60000          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example6.cs)       | float Payload();       | √       | ScriptCallCSharp       | 100000       | 0.0       | 45.1       | 29.5       | 600000           | 600000           | 600000          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example7.cs)       | Quaternion Payload(Transform);       | √       | ScriptCallCSharp       | 10000       | 0.3       | 12.4       | 4.0       | (-0.05177, -0.05087, -0.05087, 0.99606)           | (-0.05177, -0.05087, -0.05087, 0.99606)           | (-0.05177, -0.05087, -0.05087, 0.99606)          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example7.cs)       | Quaternion Payload(Transform);       | √       | ScriptCallCSharp       | 100000       | 9.4       | 96.4       | 36.4       | (-0.45294, -0.44508, -0.44511, 0.63138)           | (-0.45294, -0.44508, -0.44511, 0.63138)           | (-0.45294, -0.44508, -0.44511, 0.63138)          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example8.cs)       | Quaternion Payload(Transform, float, float, float);       | √       | ScriptCallCSharp       | 10000       | 1.0       | 14.2       | 7.1       | (0.38534, 0.54131, 0.74695, -0.02384)           | (0.38534, 0.54131, 0.74695, -0.02384)           | (0.38534, 0.54131, 0.74695, -0.02384)          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example8.cs)       | Quaternion Payload(Transform, float, float, float);       | √       | ScriptCallCSharp       | 100000       | 12.1       | 126.1       | 68.6       | (-0.09418, -0.14435, -0.19911, -0.96470)           | (-0.09418, -0.14435, -0.19911, -0.96470)           | (-0.09418, -0.14435, -0.19911, -0.96470)          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example9.cs)       | Quaternion Payload(Transform, Vector3);       | √       | ScriptCallCSharp       | 10000       | 1.7       | 17.1       | 5.9       | (-0.27992, -0.52504, -0.79347, 0.12798)           | (-0.27992, -0.52504, -0.79347, 0.12798)           | (-0.27992, -0.52504, -0.79347, 0.12798)          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example9.cs)       | Quaternion Payload(Transform, Vector3);       | √       | ScriptCallCSharp       | 100000       | 8.8       | 126.9       | 56.9       | (-0.27065, -0.50772, -0.76719, -0.28353)           | (-0.27065, -0.50772, -0.76719, -0.28353)           | (-0.27065, -0.50772, -0.76719, -0.28353)          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example101.cs)       | payload(): void;       | √       | CSharpCallScript       | 10000       | `fail`       | 2.0       | 1.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example101.cs)       | payload(): void;       | √       | CSharpCallScript       | 100000       | `fail`       | 16.7       | 3.4       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example103.cs)       | payload(number): void;       | √       | CSharpCallScript       | 10000       | `fail`       | `fail`       | `fail`       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example103.cs)       | payload(number): void;       | √       | CSharpCallScript       | 100000       | `fail`       | `fail`       | `fail`       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example104.cs)       | payload(number,number,number): void;       | √       | CSharpCallScript       | 10000       | `fail`       | `fail`       | `fail`       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example104.cs)       | payload(number,number,number): void;       | √       | CSharpCallScript       | 100000       | `fail`       | `fail`       | `fail`       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example105.cs)       | payload(number,number,number): number;       | √       | CSharpCallScript       | 10000       | `fail`       | `fail`       | `fail`       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example105.cs)       | payload(number,number,number): number;       | √       | CSharpCallScript       | 100000       | `fail`       | `fail`       | `fail`       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example106.cs)       | payload(): number;       | √       | CSharpCallScript       | 10000       | `fail`       | `fail`       | `fail`       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example106.cs)       | payload(): number;       | √       | CSharpCallScript       | 100000       | `fail`       | `fail`       | `fail`       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example107.cs)       | payload(Transform): void;       | √       | CSharpCallScript       | 10000       | `fail`       | 18.7       | 13.0       | `null`           | (-0.05177, -0.05087, -0.05087, 0.99606)           | (-0.05177, -0.05087, -0.05087, 0.99606)          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example107.cs)       | payload(Transform): void;       | √       | CSharpCallScript       | 100000       | `fail`       | 156.2       | 120.2       | `null`           | (-0.45294, -0.44508, -0.44511, 0.63138)           | (-0.45294, -0.44508, -0.44511, 0.63138)          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example108.cs)       | payload(Transform,float,float,float): void;       | √       | CSharpCallScript       | 10000       | `fail`       | `fail`       | `fail`       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example108.cs)       | payload(Transform,float,float,float): void;       | √       | CSharpCallScript       | 100000       | `fail`       | `fail`       | `fail`       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example109.cs)       | payload(Transform,Vector3): void;       | √       | CSharpCallScript       | 10000       | `fail`       | `fail`       | `fail`       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example109.cs)       | payload(Transform,Vector3): void;       | √       | CSharpCallScript       | 100000       | `fail`       | `fail`       | `fail`       | `null`           | `null`           | `null`          |