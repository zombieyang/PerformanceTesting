﻿#if EXPERIMENTAL_IL2CPP_PUERTS && ENABLE_IL2CPP
using System;
using System.Collections.Generic;
using System.Reflection;
namespace PuertsIl2cpp
{
public static class ExtensionMethodInfos_Gen
{
    [UnityEngine.Scripting.Preserve]
    public static IEnumerable<MethodInfo> TryLoadExtensionMethod(Type type)
    {
        if (false) {}
        else if (type == typeof(Calculator))
        {
            return ExtensionMethodInfo.GetExtensionMethods(typeof(Calculator), typeof(CalculatorExtension));
        }
        else if (type == typeof(System.Int32[]))
        {
            return ExtensionMethodInfo.GetExtensionMethods(typeof(System.Int32[]), typeof(PuertsIl2cpp.ArrayExtension));
        }
        else if (type == typeof(System.Single[]))
        {
            return ExtensionMethodInfo.GetExtensionMethods(typeof(System.Single[]), typeof(PuertsIl2cpp.ArrayExtension));
        }
        else if (type == typeof(System.Double[]))
        {
            return ExtensionMethodInfo.GetExtensionMethods(typeof(System.Double[]), typeof(PuertsIl2cpp.ArrayExtension));
        }
        else if (type == typeof(System.Boolean[]))
        {
            return ExtensionMethodInfo.GetExtensionMethods(typeof(System.Boolean[]), typeof(PuertsIl2cpp.ArrayExtension));
        }
        else if (type == typeof(System.Int64[]))
        {
            return ExtensionMethodInfo.GetExtensionMethods(typeof(System.Int64[]), typeof(PuertsIl2cpp.ArrayExtension));
        }
        else if (type == typeof(System.UInt64[]))
        {
            return ExtensionMethodInfo.GetExtensionMethods(typeof(System.UInt64[]), typeof(PuertsIl2cpp.ArrayExtension));
        }
        else if (type == typeof(System.SByte[]))
        {
            return ExtensionMethodInfo.GetExtensionMethods(typeof(System.SByte[]), typeof(PuertsIl2cpp.ArrayExtension));
        }
        else if (type == typeof(System.Byte[]))
        {
            return ExtensionMethodInfo.GetExtensionMethods(typeof(System.Byte[]), typeof(PuertsIl2cpp.ArrayExtension));
        }
        else if (type == typeof(System.UInt16[]))
        {
            return ExtensionMethodInfo.GetExtensionMethods(typeof(System.UInt16[]), typeof(PuertsIl2cpp.ArrayExtension));
        }
        else if (type == typeof(System.Int16[]))
        {
            return ExtensionMethodInfo.GetExtensionMethods(typeof(System.Int16[]), typeof(PuertsIl2cpp.ArrayExtension));
        }
        else if (type == typeof(System.Char[]))
        {
            return ExtensionMethodInfo.GetExtensionMethods(typeof(System.Char[]), typeof(PuertsIl2cpp.ArrayExtension));
        }
        else if (type == typeof(System.UInt32[]))
        {
            return ExtensionMethodInfo.GetExtensionMethods(typeof(System.UInt32[]), typeof(PuertsIl2cpp.ArrayExtension));
        }
        else if (type == typeof(System.String[]))
        {
            return ExtensionMethodInfo.GetExtensionMethods(typeof(System.String[]), typeof(PuertsIl2cpp.ArrayExtension));
        }
        else if (type == typeof(System.Array))
        {
            return ExtensionMethodInfo.GetExtensionMethods(typeof(System.Array), typeof(PuertsIl2cpp.ArrayExtension));
        }
        return null;
    }
}
}
#endif