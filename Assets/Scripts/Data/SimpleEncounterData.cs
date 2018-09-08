using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

public class SimpleEncounterData
{
    public short[][] ChoiceCodes { get; set; }
    public short[][] ChoiceArgs { get; set; }
    public short[] ChoiceResultIndex { get; set; }
    public byte CanBackout { get; set; }
    public byte MaxTimes { get; set; }
    public short Unknown { get; set; }
    public short Prompt { get; set; }
    public string[] OptionTexts { get; set; }

    public SimpleEncounterData()
    {
        ChoiceCodes = new short[4][];
        ChoiceArgs = new short[4][];
        ChoiceResultIndex = new short[4];
        OptionTexts = new string[4];
    }

    public static List<SimpleEncounterData> Parse(string path)
    {
        var res = new List<SimpleEncounterData>();
        using (BinaryReader b = new BinaryReader(File.Open(path, FileMode.Open)))
        {
        while (b.BaseStream.Position != b.BaseStream.Length)
        {
            var m = new SimpleEncounterData();
            for (int i = 0; i < 4; ++i)
            {
                var codes = new short[8];
                for (int j = 0; j < 8; ++j)
                    {
                        codes[j] = Convert.ToInt16(b.ReadByte());
                    }
                m.ChoiceCodes[i] = codes;
            };

            for (int i = 0; i < 4; ++i)
                {
                    var args = new short[8];
                    for (int j = 0; j < 8; ++j)
                    {
                        args[j] = b.ReadInt16().SwapBytes();
                    }
                    m.ChoiceArgs[i] = args;
                }

            for (int i = 0; i < 4; ++i)
                m.ChoiceResultIndex[i] = Convert.ToInt16(b.ReadByte());

            m.CanBackout = b.ReadByte();
            m.MaxTimes = b.ReadByte();
            m.Unknown = b.ReadInt16().SwapBytes();
            m.Prompt = b.ReadInt16().SwapBytes();

            for (int i = 0; i < 4; ++i)
                m.OptionTexts[i] = RawText.Parse(b, 79).ToString();

            res.Add(m);
        }

        }



        return res;
    }
}
