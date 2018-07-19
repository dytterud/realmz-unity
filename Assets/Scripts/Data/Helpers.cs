using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Helpers
{
    public static ushort SwapBytes(this ushort value)
    {
        byte[] bytes = BitConverter.GetBytes(value);
        Array.Reverse(bytes);
        return BitConverter.ToUInt16(bytes, 0);
    }

    public static short SwapBytes(this short value)
    {
        byte[] bytes = BitConverter.GetBytes(value);
        Array.Reverse(bytes);
        return BitConverter.ToInt16(bytes, 0);
    }

    public static int SwapBytes(this int value)
    {
        byte[] bytes = BitConverter.GetBytes(value);
        Array.Reverse(bytes);
        return BitConverter.ToInt32(bytes, 0);
    }

    public static uint SwapBytes(this uint value)
    {
        byte[] bytes = BitConverter.GetBytes(value);
        Array.Reverse(bytes);
        return BitConverter.ToUInt32(bytes, 0);
    }

    public static byte[] SwapBytes(this byte[] value)
    {
        Array.Reverse(value);
        return value;
    }
}
