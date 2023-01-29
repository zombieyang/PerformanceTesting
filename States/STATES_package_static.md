
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
| Date            | 2023-01-29 13:02:47               |
# 数据对照
* Static vs Instance | 	`静态函数 vs 实例函数`

| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [:page_facing_up:](/Assets/CScripts/Examples/Example1.cs)       | void Payload();       | √       | ScriptCallCSharp       | 100000       | 0.8       | 7.5       | 6.6       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example2.cs)       | void Payload();       | ×       | ScriptCallCSharp       | 100000       | 0.9       | 10.7       | 22.6       | `null`           | `null`           | `null`          |
* ParameterCompare | 	`无参数 vs 有参数`

| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [:page_facing_up:](/Assets/CScripts/Examples/Example1.cs)       | void Payload();       | √       | ScriptCallCSharp       | 100000       | 0.8       | 7.5       | 6.6       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example3.cs)       | void Payload(int);       | √       | ScriptCallCSharp       | 100000       | 0.9       | 14.3       | 9.1       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example4.cs)       | void Payload(int, int, float);       | √       | ScriptCallCSharp       | 100000       | 0.8       | 26.5       | 15.1       | `null`           | `null`           | `null`          |
* xyz vs Vector3 | 	`xyz传参 vs Vector3传参`

| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [:page_facing_up:](/Assets/CScripts/Examples/Example8.cs)       | Quaternion Payload(Transform, float, float, float);       | √       | ScriptCallCSharp       | 100000       | 48.6       | 154.4       | 60.2       | (-0.09419, -0.14436, -0.19910, -0.96470)           | (-0.09419, -0.14436, -0.19910, -0.96470)           | (-0.09419, -0.14436, -0.19910, -0.96470)          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example9.cs)       | Quaternion Payload(Transform, Vector3);       | √       | ScriptCallCSharp       | 100000       | 30.6       | 170.2       | 59.3       | (-0.27067, -0.50771, -0.76719, -0.28352)           | (-0.27067, -0.50771, -0.76719, -0.28352)           | (-0.27067, -0.50771, -0.76719, -0.28352)          |
# 所有数据
| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [:page_facing_up:](/Assets/CScripts/Examples/Example1.cs)       | void Payload();       | √       | ScriptCallCSharp       | 10000       | 0.3       | 8.6       | 2.8       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example1.cs)       | void Payload();       | √       | ScriptCallCSharp       | 100000       | 0.8       | 7.5       | 6.6       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example2.cs)       | void Payload();       | ×       | ScriptCallCSharp       | 10000       | 0.3       | 4.3       | 4.6       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example2.cs)       | void Payload();       | ×       | ScriptCallCSharp       | 100000       | 0.9       | 10.7       | 22.6       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example3.cs)       | void Payload(int);       | √       | ScriptCallCSharp       | 10000       | 0.3       | 4.4       | 3.1       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example3.cs)       | void Payload(int);       | √       | ScriptCallCSharp       | 100000       | 0.9       | 14.3       | 9.1       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example4.cs)       | void Payload(int, int, float);       | √       | ScriptCallCSharp       | 10000       | 0.3       | 5.5       | 3.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example4.cs)       | void Payload(int, int, float);       | √       | ScriptCallCSharp       | 100000       | 0.8       | 26.5       | 15.1       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example5.cs)       | float Payload(int, int, float);       | √       | ScriptCallCSharp       | 10000       | 0.5       | 8.2       | 3.7       | 1.500183E+08           | 1.50015E+08           | 150015000          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example5.cs)       | float Payload(int, int, float);       | √       | ScriptCallCSharp       | 100000       | 2.5       | 35.7       | 18.4       | 1.500022E+10           | 1.500015E+10           | 15000150000          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example6.cs)       | float Payload();       | √       | ScriptCallCSharp       | 10000       | 0.3       | 3.6       | 2.3       | 60000           | 60000           | 60000          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example6.cs)       | float Payload();       | √       | ScriptCallCSharp       | 100000       | 1.1       | 10.4       | 9.3       | 600000           | 600000           | 600000          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example7.cs)       | Quaternion Payload(Transform);       | √       | ScriptCallCSharp       | 10000       | 5.1       | 43.2       | 32.4       | (-0.05177, -0.05087, -0.05087, 0.99606)           | (-0.05177, -0.05087, -0.05087, 0.99606)           | (-0.05177, -0.05087, -0.05087, 0.99606)          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example7.cs)       | Quaternion Payload(Transform);       | √       | ScriptCallCSharp       | 100000       | 36.0       | 121.2       | 56.7       | (-0.45293, -0.44509, -0.44509, 0.63138)           | (-0.45293, -0.44509, -0.44509, 0.63138)           | (-0.45293, -0.44509, -0.44509, 0.63138)          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example8.cs)       | Quaternion Payload(Transform, float, float, float);       | √       | ScriptCallCSharp       | 10000       | 5.1       | 21.6       | 9.0       | (0.38534, 0.54131, 0.74695, -0.02384)           | (0.38534, 0.54131, 0.74695, -0.02384)           | (0.38534, 0.54131, 0.74695, -0.02384)          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example8.cs)       | Quaternion Payload(Transform, float, float, float);       | √       | ScriptCallCSharp       | 100000       | 48.6       | 154.4       | 60.2       | (-0.09419, -0.14436, -0.19910, -0.96470)           | (-0.09419, -0.14436, -0.19910, -0.96470)           | (-0.09419, -0.14436, -0.19910, -0.96470)          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example9.cs)       | Quaternion Payload(Transform, Vector3);       | √       | ScriptCallCSharp       | 10000       | 3.5       | 23.1       | 9.9       | (-0.27992, -0.52505, -0.79347, 0.12798)           | (-0.27992, -0.52505, -0.79347, 0.12798)           | (-0.27992, -0.52505, -0.79347, 0.12798)          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example9.cs)       | Quaternion Payload(Transform, Vector3);       | √       | ScriptCallCSharp       | 100000       | 30.6       | 170.2       | 59.3       | (-0.27067, -0.50771, -0.76719, -0.28352)           | (-0.27067, -0.50771, -0.76719, -0.28352)           | (-0.27067, -0.50771, -0.76719, -0.28352)          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example101.cs)       | payload(): void;       | √       | CSharpCallScript       | 10000       | `fail`       | 13.3       | 16.1       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example101.cs)       | payload(): void;       | √       | CSharpCallScript       | 100000       | `fail`       | 37.9       | 113.2       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example103.cs)       | payload(number): void;       | √       | CSharpCallScript       | 10000       | `fail`       | 9.8       | 13.1       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example103.cs)       | payload(number): void;       | √       | CSharpCallScript       | 100000       | `fail`       | 93.2       | 113.1       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example104.cs)       | payload(number,number,number): void;       | √       | CSharpCallScript       | 10000       | `fail`       | 14.4       | 13.4       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example104.cs)       | payload(number,number,number): void;       | √       | CSharpCallScript       | 100000       | `fail`       | 116.9       | 146.3       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example105.cs)       | payload(number,number,number): number;       | √       | CSharpCallScript       | 10000       | `fail`       | 15.1       | 12.5       | `null`           | 1.500183E+08           | 1.500183E+08          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example105.cs)       | payload(number,number,number): number;       | √       | CSharpCallScript       | 100000       | `fail`       | 149.9       | 176.9       | `null`           | 1.500022E+10           | 1.500022E+10          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example106.cs)       | payload(): number;       | √       | CSharpCallScript       | 10000       | `fail`       | 7.3       | 11.5       | `null`           | 60000           | 60000          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example106.cs)       | payload(): number;       | √       | CSharpCallScript       | 100000       | `fail`       | 60.8       | 112.9       | `null`           | 600000           | 600000          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example107.cs)       | payload(Transform): void;       | √       | CSharpCallScript       | 10000       | `fail`       | 91.6       | 88.1       | `null`           | (-0.05177, -0.05087, -0.05087, 0.99606)           | (-0.05177, -0.05087, -0.05087, 0.99606)          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example107.cs)       | payload(Transform): void;       | √       | CSharpCallScript       | 100000       | `fail`       | 881.8       | 873.5       | `null`           | (-0.45293, -0.44509, -0.44509, 0.63138)           | (-0.45293, -0.44509, -0.44509, 0.63138)          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example108.cs)       | payload(Transform,float,float,float): void;       | √       | CSharpCallScript       | 10000       | `fail`       | 96.6       | 90.0       | `null`           | (0.38534, 0.54131, 0.74695, -0.02384)           | (0.38534, 0.54131, 0.74695, -0.02384)          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example108.cs)       | payload(Transform,float,float,float): void;       | √       | CSharpCallScript       | 100000       | `fail`       | 904.4       | 894.2       | `null`           | (-0.09419, -0.14436, -0.19910, -0.96470)           | (-0.09419, -0.14436, -0.19910, -0.96470)          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example109.cs)       | payload(Transform,Vector3): void;       | √       | CSharpCallScript       | 10000       | `fail`       | 123.9       | 115.6       | `null`           | (-0.27992, -0.52505, -0.79347, 0.12798)           | (-0.27992, -0.52505, -0.79347, 0.12798)          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example109.cs)       | payload(Transform,Vector3): void;       | √       | CSharpCallScript       | 100000       | `fail`       | 1246.6       | 1136.7       | `null`           | (-0.27067, -0.50771, -0.76719, -0.28352)           | (-0.27067, -0.50771, -0.76719, -0.28352)          |