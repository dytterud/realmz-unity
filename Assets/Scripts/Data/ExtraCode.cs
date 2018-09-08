using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

class ExtraCode
{
    // Data EDCD
    public static short[][] Parse(string path)
    {
        using (BinaryReader b = new BinaryReader(File.Open(path, FileMode.Open)))
        {
            var len = b.BaseStream.Length / 10;
            var m = new short[len][];

            for (int i = 0; i < len; i++)
            {
                var codes = new short[5];
                for (int j = 0; j < 5; j++)
                    codes[j] = b.ReadInt16().SwapBytes();
                m[i] = codes;
            }

            return m;
        }
    }
}
