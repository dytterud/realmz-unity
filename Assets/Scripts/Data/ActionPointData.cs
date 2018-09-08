using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

// Data DD
public class ActionPointData
{
    public int LocationCode { get; set; }
    public byte ToLevel { get; set; }
    public byte ToX { get; set; }
    public byte ToY { get; set; }
    public byte PercentChance { get; set; }
    public short[] CommandCodes { get; set; }
    public short[] ArgumentCodes { get; set; }

    public ActionPointData()
    {
        CommandCodes = new short[8];
        ArgumentCodes = new short[8];
    }

    public static List<ActionPointData> Parse(string path)
    {
        using (BinaryReader b = new BinaryReader(File.Open(path, FileMode.Open)))
        {
            var res = new List<ActionPointData>();
            while (b.BaseStream.Position != b.BaseStream.Length)
            {
                var m = new ActionPointData
                {
                    LocationCode = b.ReadInt32().SwapBytes(),
                    ToLevel = b.ReadByte(),
                    ToX = b.ReadByte(),
                    ToY = b.ReadByte(),
                    PercentChance = b.ReadByte()
                };
                for (int i = 0; i < 8; i++)
                    m.CommandCodes[i] = b.ReadInt16().SwapBytes();
                for (int i = 0; i < 8; i++)
                    m.ArgumentCodes[i] = b.ReadInt16().SwapBytes();

                res.Add(m);
            }

            return res;
        }
    }
}
