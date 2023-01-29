
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
| Date            | 2023-01-29 22:23:07               |
# 数据对照
* ParameterCompare | 	`无参数 vs 有参数`

| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [:page_facing_up:](//Assets/CScripts/Examples/Example1.cs)       | void Payload();       | √       | ScriptCallCSharp       | 100000       | 0.0       | 4.5       | 2.5       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example3.cs)       | void Payload(int);       | √       | ScriptCallCSharp       | 100000       | 0.0       | 8.3       | 3.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example4.cs)       | void Payload(int, int, float);       | √       | ScriptCallCSharp       | 100000       | 0.0       | 7.9       | 5.0       | `null`           | `null`           | `null`          |
* Static vs Instance | 	`静态函数 vs 实例函数`

| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [:page_facing_up:](//Assets/CScripts/Examples/Example1.cs)       | void Payload();       | √       | ScriptCallCSharp       | 100000       | 0.0       | 4.5       | 2.5       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example2.cs)       | void Payload();       | ×       | ScriptCallCSharp       | 100000       | 0.0       | 5.5       | 7.8       | `null`           | `null`           | `null`          |
* xyz vs Vector3 | 	`xyz传参 vs Vector3传参`

| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [:page_facing_up:](//Assets/CScripts/Examples/Example8.cs)       | Quaternion Payload(Transform, float, float, float);       | √       | ScriptCallCSharp       | 100000       | 11.5       | 23.3       | 21.1       | (-0.09418, -0.14435, -0.19911, -0.96470)           | (-0.09418, -0.14435, -0.19911, -0.96470)           | (-0.09418, -0.14435, -0.19911, -0.96470)          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example9.cs)       | Quaternion Payload(Transform, Vector3);       | √       | ScriptCallCSharp       | 100000       | 8.4       | 30.3       | 20.9       | (-0.27065, -0.50772, -0.76719, -0.28353)           | (-0.27065, -0.50772, -0.76719, -0.28353)           | (-0.27065, -0.50772, -0.76719, -0.28353)          |
# 所有数据
| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [:page_facing_up:](//Assets/CScripts/Examples/Example1.cs)       | void Payload();       | √       | ScriptCallCSharp       | 10000       | 0.0       | 1.7       | 0.5       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example1.cs)       | void Payload();       | √       | ScriptCallCSharp       | 100000       | 0.0       | 4.5       | 2.5       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example2.cs)       | void Payload();       | ×       | ScriptCallCSharp       | 10000       | 0.0       | 1.5       | 1.5       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example2.cs)       | void Payload();       | ×       | ScriptCallCSharp       | 100000       | 0.0       | 5.5       | 7.8       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example3.cs)       | void Payload(int);       | √       | ScriptCallCSharp       | 10000       | 0.0       | 1.6       | 1.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example3.cs)       | void Payload(int);       | √       | ScriptCallCSharp       | 100000       | 0.0       | 8.3       | 3.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example4.cs)       | void Payload(int, int, float);       | √       | ScriptCallCSharp       | 10000       | 0.0       | 1.5       | 0.5       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example4.cs)       | void Payload(int, int, float);       | √       | ScriptCallCSharp       | 100000       | 0.0       | 7.9       | 5.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example5.cs)       | float Payload(int, int, float);       | √       | ScriptCallCSharp       | 10000       | 0.0       | 1.4       | 0.4       | 1.500183E+08           | 1.50015E+08           | 150015000          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example5.cs)       | float Payload(int, int, float);       | √       | ScriptCallCSharp       | 100000       | 0.2       | 9.8       | 5.0       | 1.500022E+10           | 1.500015E+10           | 15000150000          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example6.cs)       | float Payload();       | √       | ScriptCallCSharp       | 10000       | 0.0       | 1.0       | 1.0       | 60000           | 60000           | 60000          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example6.cs)       | float Payload();       | √       | ScriptCallCSharp       | 100000       | 0.0       | 5.0       | 3.0       | 600000           | 600000           | 600000          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example7.cs)       | Quaternion Payload(Transform);       | √       | ScriptCallCSharp       | 10000       | 1.0       | 5.0       | 2.0       | (-0.05177, -0.05087, -0.05087, 0.99606)           | (-0.05177, -0.05087, -0.05087, 0.99606)           | (-0.05177, -0.05087, -0.05087, 0.99606)          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example7.cs)       | Quaternion Payload(Transform);       | √       | ScriptCallCSharp       | 100000       | 9.5       | 20.3       | 17.1       | (-0.45294, -0.44508, -0.44511, 0.63138)           | (-0.45294, -0.44508, -0.44511, 0.63138)           | (-0.45294, -0.44508, -0.44511, 0.63138)          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example8.cs)       | Quaternion Payload(Transform, float, float, float);       | √       | ScriptCallCSharp       | 10000       | 1.0       | 3.0       | 2.8       | (0.38534, 0.54131, 0.74695, -0.02384)           | (0.38534, 0.54131, 0.74695, -0.02384)           | (0.38534, 0.54131, 0.74695, -0.02384)          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example8.cs)       | Quaternion Payload(Transform, float, float, float);       | √       | ScriptCallCSharp       | 100000       | 11.5       | 23.3       | 21.1       | (-0.09418, -0.14435, -0.19911, -0.96470)           | (-0.09418, -0.14435, -0.19911, -0.96470)           | (-0.09418, -0.14435, -0.19911, -0.96470)          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example9.cs)       | Quaternion Payload(Transform, Vector3);       | √       | ScriptCallCSharp       | 10000       | 1.0       | 4.6       | 3.0       | (-0.27992, -0.52504, -0.79347, 0.12798)           | (-0.27992, -0.52504, -0.79347, 0.12798)           | (-0.27992, -0.52504, -0.79347, 0.12798)          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example9.cs)       | Quaternion Payload(Transform, Vector3);       | √       | ScriptCallCSharp       | 100000       | 8.4       | 30.3       | 20.9       | (-0.27065, -0.50772, -0.76719, -0.28353)           | (-0.27065, -0.50772, -0.76719, -0.28353)           | (-0.27065, -0.50772, -0.76719, -0.28353)          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example101.cs)       | payload(): void;       | √       | CSharpCallScript       | 10000       | `fail`       | 2.0       | 0.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example101.cs)       | payload(): void;       | √       | CSharpCallScript       | 100000       | `fail`       | 18.2       | 2.7       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example103.cs)       | payload(number): void;       | √       | CSharpCallScript       | 10000       | `fail`       | 2.0       | 0.6       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example103.cs)       | payload(number): void;       | √       | CSharpCallScript       | 100000       | `fail`       | 29.4       | 4.7       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example104.cs)       | payload(number,number,number): void;       | √       | CSharpCallScript       | 10000       | `fail`       | 3.7       | 1.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example104.cs)       | payload(number,number,number): void;       | √       | CSharpCallScript       | 100000       | `fail`       | 119.0       | 6.5       | `null`           | `null`           | `null`          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example105.cs)       | payload(number,number,number): number;       | √       | CSharpCallScript       | 10000       | `fail`       | 5.0       | 0.0       | `null`           | 1.500183E+08           | 1.500183E+08          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example105.cs)       | payload(number,number,number): number;       | √       | CSharpCallScript       | 100000       | `fail`       | 49.5       | 4.4       | `null`           | 1.500022E+10           | 1.500022E+10          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example106.cs)       | payload(): number;       | √       | CSharpCallScript       | 10000       | `fail`       | 3.6       | 1.0       | `null`           | 60000           | 60000          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example106.cs)       | payload(): number;       | √       | CSharpCallScript       | 100000       | `fail`       | 28.1       | 4.0       | `null`           | 600000           | 600000          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example107.cs)       | payload(Transform): void;       | √       | CSharpCallScript       | 10000       | `fail`       | 18.1       | 11.6       | `null`           | (-0.05177, -0.05087, -0.05087, 0.99606)           | (-0.05177, -0.05087, -0.05087, 0.99606)          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example107.cs)       | payload(Transform): void;       | √       | CSharpCallScript       | 100000       | `fail`       | 159.0       | 99.1       | `null`           | (-0.45294, -0.44508, -0.44511, 0.63138)           | (-0.45294, -0.44508, -0.44511, 0.63138)          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example108.cs)       | payload(Transform,float,float,float): void;       | √       | CSharpCallScript       | 10000       | `fail`       | 19.1       | 11.6       | `null`           | (0.38534, 0.54131, 0.74695, -0.02384)           | (0.38534, 0.54131, 0.74695, -0.02384)          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example108.cs)       | payload(Transform,float,float,float): void;       | √       | CSharpCallScript       | 100000       | `fail`       | 177.6       | 100.8       | `null`           | (-0.09418, -0.14435, -0.19911, -0.96470)           | (-0.09418, -0.14435, -0.19911, -0.96470)          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example109.cs)       | payload(Transform,Vector3): void;       | √       | CSharpCallScript       | 10000       | `fail`       | 26.3       | 15.4       | `null`           | (-0.27992, -0.52504, -0.79347, 0.12798)           | (-0.27992, -0.52504, -0.79347, 0.12798)          |
| [:page_facing_up:](//Assets/CScripts/Examples/Example109.cs)       | payload(Transform,Vector3): void;       | √       | CSharpCallScript       | 100000       | `fail`       | 258.3       | 147.6       | `null`           | (-0.27065, -0.50772, -0.76719, -0.28353)           | (-0.27065, -0.50772, -0.76719, -0.28353)          |