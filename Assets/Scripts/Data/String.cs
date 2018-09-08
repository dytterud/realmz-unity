using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

class String
{
    public static List<string> Parse(string path)
    {
        using (BinaryReader b = new BinaryReader(File.Open(path, FileMode.Open)))
        {
            var res = new List<string>();
            while (b.BaseStream.Position != b.BaseStream.Length)
            {
                res.Add(RawText.Parse(b, 255).ToString());
            }

            return res;
        }
    }
}
