// Decompiled with JetBrains decompiler
// Type: PROJECT_HAZE_V1.Functions
// Assembly: PROJECT HAZE V1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 58A6D0C5-3AC7-4F25-B61E-D3ED4F0A6A19
// Assembly location: C:\Users\Julian Seipp\Documents\Desktop\aufnahmen - Kopie\dex\Bo2\tools\Purple Haze V1 By Zylum Modz\PROJECT HAZE V1.exe

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace main

{
  public static class Functions
  {
    public static void SetMem(uint Offset, byte[] value)
    {
      Form1.PS3.SetMemory(Offset, value);
    }

    public static void WriteUInt16(uint offset, ushort Value)
    {
      Form1.PS3.SetMemory(offset, ((IEnumerable<byte>) BitConverter.GetBytes(Value)).Reverse<byte>().ToArray<byte>());
    }

    public static void WriteFlo(uint Offset, float Input)
    {
      Form1.PS3.Extension.WriteFloat(Offset, Input);
    }

    public static void WriteStr(uint Offset, string Input)
    {
      Form1.PS3.Extension.WriteString(Offset, Input);
    }

    public static string ReadStr(uint Offset)
    {
      return Form1.PS3.Extension.ReadString(Offset);
    }

    public static void WriteByte(uint Offset, byte Input)
    {
      Form1.PS3.Extension.WriteByte(Offset, Input);
    }

    public static byte[] ReverseBytes(byte[] inArray)
    {
      Array.Reverse((Array) inArray);
      return inArray;
    }

    public static void WriteSingle(uint address, float[] input)
    {
      int length = input.Length;
      byte[] buffer = new byte[length * 4];
      for (int index = 0; index < length; ++index)
        Functions.ReverseBytes(BitConverter.GetBytes(input[index])).CopyTo((Array) buffer, index * 4);
      Form1.PS3.SetMemory(address, buffer);
    }

    public static void WriteSingle(uint address, float input)
    {
      byte[] buffer = new byte[4];
      BitConverter.GetBytes(input).CopyTo((Array) buffer, 0);
      Array.Reverse((Array) buffer, 0, 4);
      Form1.PS3.SetMemory(address, buffer);
    }

    public static float ReadSingle(uint address)
    {
      byte[] bytes = Form1.PS3.GetBytes(address, 4);
      Array.Reverse((Array) bytes, 0, 4);
      return BitConverter.ToSingle(bytes, 0);
    }

    public static float[] ReadSingle(uint address, int length)
    {
      byte[] bytes = Form1.PS3.GetBytes(address, length * 4);
      Functions.ReverseBytes(bytes);
      float[] numArray = new float[length - 1 + 1];
      for (int index = 0; index <= length - 1; ++index)
        numArray[index] = Convert.ToSingle(BitConverter.ToSingle(bytes, (length - 1 - index) * 4));
      return numArray;
    }

    public static byte[] HexStringToByteArray(string hex)
    {
      return Enumerable.Range(0, hex.Length).Where<int>((Func<int, bool>) (x => x % 2 == 0)).Select<int, byte>((Func<int, byte>) (x => Convert.ToByte(hex.Substring(x, 2), 16))).ToArray<byte>();
    }

    public static string ByteArrayToString(byte[] bytes)
    {
      return new ASCIIEncoding().GetString(bytes);
    }

    public static void SetClass(uint offset, string input)
    {
      Form1.PS3.SetMemory(offset, new byte[16]);
      byte[] B = new byte[1]{ (byte) 4 };
      byte[] bytes = Encoding.ASCII.GetBytes(input);
      Form1.PS3.SetMemory(offset, bytes.Multiply(B));
    }

    public static byte[] Multiply(this byte[] A)
    {
      List<byte> A1 = new List<byte>();
      int idx = 0;
      for (int index1 = 0; index1 < A.Length; ++index1)
      {
        byte b1 = 0;
        for (int index2 = 0; index2 < A.Length; ++index2)
        {
          short num = (short) ((int) A[index1] * (int) A[index2] + (int) b1);
          b1 = (byte) ((uint) num >> 8);
          byte b2 = (byte) num;
          idx = index1 + index2;
          if (idx < A1.Count)
            A1 = Functions._add_(A1, b2, idx, (byte) 0);
          else
            A1.Add(b2);
        }
        if ((int) b1 > 0)
        {
          if (idx + 1 < A1.Count)
            A1 = Functions._add_(A1, b1, idx + 1, (byte) 0);
          else
            A1.Add(b1);
        }
      }
      return A1.ToArray();
    }

    private static List<byte> _add_(List<byte> A, byte b, int idx = 0, byte rem = 0)
    {
      if (idx < A.Count)
      {
        short num = (short) ((int) A[idx] + (int) b);
        A[idx] = (byte) ((uint) num % 256U);
        rem = (byte) (((int) num - (int) A[idx]) % (int) byte.MaxValue);
        if ((int) rem > 0)
          return Functions._add_(A, rem, idx + 1, (byte) 0);
      }
      else
        A.Add(b);
      return A;
    }

    public static void SetName(uint Offset, string Text)
    {
      byte[] bytes = Encoding.ASCII.GetBytes(Text);
      Array.Resize<byte>(ref bytes, bytes.Length + 1);
      Functions.SetMem(Offset, bytes);
    }
  }
}
