// Instagram: @sprx.sh
// Type: Functions
// Assembly: ViralModding BO2 Tool, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34DA57E2-E297-42DB-B3B8-5EB97D9E839E
// Assembly location: C:\Users\xCreations\Desktop\CCAPI 2.70 + tmapi\ViralModding BO2 Tool.exe

using main;
using main;
using System.Collections.Generic;

public static class Functions
{
    public static byte[] Multiply(this byte[] A, byte[] B)
    {
        List<byte> A1 = new List<byte>();
        int idx = 0;
        for (int index1 = 0; index1 < A.Length; ++index1)
        {
            byte b1 = 0;
            for (int index2 = 0; index2 < B.Length; ++index2)
            {
                short num = (short)((int)A[index1] * (int)B[index2] + (int)b1);
                b1 = (byte)((uint)num >> 8);
                byte b2 = (byte)num;
                idx = index1 + index2;
                if (idx < A1.Count)
                    A1 = Functions._add_(A1, b2, idx, (byte)0);
                else
                    A1.Add(b2);
            }
            if ((int)b1 > 0)
            {
                if (idx + 1 < A1.Count)
                    A1 = Functions._add_(A1, b1, idx + 1, (byte)0);
                else
                    A1.Add(b1);
            }
        }
        return A1.ToArray();
    }
    public static void SetMem(uint Offset, byte[] value)
    {
        Form1.PS3.SetMemory(Offset, value);
    }

    private static List<byte> _add_(List<byte> A, byte b, int idx = 0, byte rem = 0)
    {
        if (idx < A.Count)
        {
            short num = (short)((int)A[idx] + (int)b);
            A[idx] = (byte)((uint)num % 256U);
            rem = (byte)(((int)num - (int)A[idx]) % (int)byte.MaxValue);
            if ((int)rem > 0)
                return Functions._add_(A, rem, idx + 1, (byte)0);
        }
        else
            A.Add(b);
        return A;
    }
}
