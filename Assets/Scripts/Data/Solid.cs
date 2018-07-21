using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

class Solid
{
    public static bool[] Parse(string path)
    {
        using (BinaryReader b = new BinaryReader(File.Open(path, FileMode.Open)))
        {
            var res = new bool[b.BaseStream.Length];
            for (int i = 0; i < b.BaseStream.Length; i++)
            {
                res[i] = b.ReadBoolean();
            }


            return res;
        }
    }
}

