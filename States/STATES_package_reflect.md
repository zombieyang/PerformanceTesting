
# 软件版本
| Name            | Value             |
| :----           | :----:            |
| Unity           | 2021.3.3f1c1               |
| puerts          | 16               |
| xLua            | 105               |
# 系统环境
| Name            | Value             |
| :----           | :----:            |
| System          | Mac OS X 12.5.1               |
| Memory          | 16384MB             |
| CPU             | Intel(R) Core(TM) i7-8750H CPU @ 2.20GHz               |
| CPU-Core        | 12               |
| CPU-Frequency   | 2.2GHz            |
| Editor          | True               |
| Date            | 2023-01-29 13:02:05               |
# 数据对照
* Static vs Instance | 	`静态函数 vs 实例函数`

| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [:page_facing_up:](/Assets/CScripts/Examples/Example1.cs)       | void Payload();       | √       | ScriptCallCSharp       | 100000       | 0.7       | 184.5       | 250.9       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example2.cs)       | void Payload();       | ×       | ScriptCallCSharp       | 100000       | 0.7       | 214.1       | 337.8       | `null`           | `null`           | `null`          |
* ParameterCompare | 	`无参数 vs 有参数`

| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [:page_facing_up:](/Assets/CScripts/Examples/Example1.cs)       | void Payload();       | √       | ScriptCallCSharp       | 100000       | 0.7       | 184.5       | 250.9       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example3.cs)       | void Payload(int);       | √       | ScriptCallCSharp       | 100000       | 0.6       | 209.9       | 280.4       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example4.cs)       | void Payload(int, int, float);       | √       | ScriptCallCSharp       | 100000       | 0.7       | 304.4       | 367.5       | `null`           | `null`           | `null`          |
* xyz vs Vector3 | 	`xyz传参 vs Vector3传参`

| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [:page_facing_up:](/Assets/CScripts/Examples/Example8.cs)       | Quaternion Payload(Transform, float, float, float);       | √       | ScriptCallCSharp       | 100000       | 41.6       | 477.9       | 469.4       | (-0.09419, -0.14436, -0.19910, -0.96470)           | (-0.09419, -0.14436, -0.19910, -0.96470)           | (-0.09419, -0.14436, -0.19910, -0.96470)          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example9.cs)       | Quaternion Payload(Transform, Vector3);       | √       | ScriptCallCSharp       | 100000       | 30.2       | 417.4       | 383.7       | (-0.27067, -0.50771, -0.76719, -0.28352)           | (-0.27067, -0.50771, -0.76719, -0.28352)           | (-0.27067, -0.50771, -0.76719, -0.28352)          |
# 所有数据
| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [:page_facing_up:](/Assets/CScripts/Examples/Example1.cs)       | void Payload();       | √       | ScriptCallCSharp       | 10000       | 0.3       | 23.0       | 28.6       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example1.cs)       | void Payload();       | √       | ScriptCallCSharp       | 100000       | 0.7       | 184.5       | 250.9       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example2.cs)       | void Payload();       | ×       | ScriptCallCSharp       | 10000       | 0.2       | 22.9       | 34.8       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example2.cs)       | void Payload();       | ×       | ScriptCallCSharp       | 100000       | 0.7       | 214.1       | 337.8       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example3.cs)       | void Payload(int);       | √       | ScriptCallCSharp       | 10000       | 0.2       | 22.0       | 28.4       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example3.cs)       | void Payload(int);       | √       | ScriptCallCSharp       | 100000       | 0.6       | 209.9       | 280.4       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example4.cs)       | void Payload(int, int, float);       | √       | ScriptCallCSharp       | 10000       | 0.2       | 31.5       | 39.1       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example4.cs)       | void Payload(int, int, float);       | √       | ScriptCallCSharp       | 100000       | 0.7       | 304.4       | 367.5       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example5.cs)       | float Payload(int, int, float);       | √       | ScriptCallCSharp       | 10000       | 0.4       | 37.6       | 44.6       | 1.500183E+08           | 1.50015E+08           | 150015000          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example5.cs)       | float Payload(int, int, float);       | √       | ScriptCallCSharp       | 100000       | 2.1       | 337.2       | 416.9       | 1.500022E+10           | 1.500015E+10           | 15000150000          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example6.cs)       | float Payload();       | √       | ScriptCallCSharp       | 10000       | 0.3       | 19.0       | 31.9       | 60000           | 60000           | 60000          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example6.cs)       | float Payload();       | √       | ScriptCallCSharp       | 100000       | 0.9       | 179.3       | 299.4       | 600000           | 600000           | 600000          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example7.cs)       | Quaternion Payload(Transform);       | √       | ScriptCallCSharp       | 10000       | 6.8       | 58.7       | 48.6       | (-0.05177, -0.05087, -0.05087, 0.99606)           | (-0.05177, -0.05087, -0.05087, 0.99606)           | (-0.05177, -0.05087, -0.05087, 0.99606)          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example7.cs)       | Quaternion Payload(Transform);       | √       | ScriptCallCSharp       | 100000       | 31.8       | 332.6       | 335.7       | (-0.45293, -0.44509, -0.44509, 0.63138)           | (-0.45293, -0.44509, -0.44509, 0.63138)           | (-0.45293, -0.44509, -0.44509, 0.63138)          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example8.cs)       | Quaternion Payload(Transform, float, float, float);       | √       | ScriptCallCSharp       | 10000       | 4.4       | 57.8       | 48.7       | (0.38534, 0.54131, 0.74695, -0.02384)           | (0.38534, 0.54131, 0.74695, -0.02384)           | (0.38534, 0.54131, 0.74695, -0.02384)          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example8.cs)       | Quaternion Payload(Transform, float, float, float);       | √       | ScriptCallCSharp       | 100000       | 41.6       | 477.9       | 469.4       | (-0.09419, -0.14436, -0.19910, -0.96470)           | (-0.09419, -0.14436, -0.19910, -0.96470)           | (-0.09419, -0.14436, -0.19910, -0.96470)          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example9.cs)       | Quaternion Payload(Transform, Vector3);       | √       | ScriptCallCSharp       | 10000       | 3.4       | 52.0       | 41.0       | (-0.27992, -0.52505, -0.79347, 0.12798)           | (-0.27992, -0.52505, -0.79347, 0.12798)           | (-0.27992, -0.52505, -0.79347, 0.12798)          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example9.cs)       | Quaternion Payload(Transform, Vector3);       | √       | ScriptCallCSharp       | 100000       | 30.2       | 417.4       | 383.7       | (-0.27067, -0.50771, -0.76719, -0.28352)           | (-0.27067, -0.50771, -0.76719, -0.28352)           | (-0.27067, -0.50771, -0.76719, -0.28352)          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example101.cs)       | payload(): void;       | √       | CSharpCallScript       | 10000       | `fail`       | 15.3       | 22.7       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example101.cs)       | payload(): void;       | √       | CSharpCallScript       | 100000       | `fail`       | 39.6       | 112.2       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example103.cs)       | payload(number): void;       | √       | CSharpCallScript       | 10000       | `fail`       | `fail`       | `fail`       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example103.cs)       | payload(number): void;       | √       | CSharpCallScript       | 100000       | `fail`       | `fail`       | `fail`       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example104.cs)       | payload(number,number,number): void;       | √       | CSharpCallScript       | 10000       | `fail`       | `fail`       | `fail`       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example104.cs)       | payload(number,number,number): void;       | √       | CSharpCallScript       | 100000       | `fail`       | `fail`       | `fail`       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example105.cs)       | payload(number,number,number): number;       | √       | CSharpCallScript       | 10000       | `fail`       | `fail`       | `fail`       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example105.cs)       | payload(number,number,number): number;       | √       | CSharpCallScript       | 100000       | `fail`       | `fail`       | `fail`       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example106.cs)       | payload(): number;       | √       | CSharpCallScript       | 10000       | `fail`       | `fail`       | `fail`       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example106.cs)       | payload(): number;       | √       | CSharpCallScript       | 100000       | `fail`       | `fail`       | `fail`       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example107.cs)       | payload(Transform): void;       | √       | CSharpCallScript       | 10000       | `fail`       | 87.4       | 97.4       | `null`           | (-0.05177, -0.05087, -0.05087, 0.99606)           | (-0.05177, -0.05087, -0.05087, 0.99606)          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example107.cs)       | payload(Transform): void;       | √       | CSharpCallScript       | 100000       | `fail`       | 814.2       | 945.8       | `null`           | (-0.45293, -0.44509, -0.44509, 0.63138)           | (-0.45293, -0.44509, -0.44509, 0.63138)          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example108.cs)       | payload(Transform,float,float,float): void;       | √       | CSharpCallScript       | 10000       | `fail`       | `fail`       | `fail`       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example108.cs)       | payload(Transform,float,float,float): void;       | √       | CSharpCallScript       | 100000       | `fail`       | `fail`       | `fail`       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example109.cs)       | payload(Transform,Vector3): void;       | √       | CSharpCallScript       | 10000       | `fail`       | `fail`       | `fail`       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example109.cs)       | payload(Transform,Vector3): void;       | √       | CSharpCallScript       | 100000       | `fail`       | `fail`       | `fail`       | `null`           | `null`           | `null`          |