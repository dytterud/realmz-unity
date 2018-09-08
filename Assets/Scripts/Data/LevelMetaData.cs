using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

    public class LevelMetaData
    {
        public RandomRectCoords[] randomRectsCoords = new RandomRectCoords[20];
        public short[] TimesIn10k = new short[20];
        public RandomRectBattleRange[] BattleRange = new RandomRectBattleRange[20];
        public short[,] XapNum = new short[20, 3];
        public short[,] XapChance = new short[20, 3];
        public byte LandType;
        public byte[] unknown; // dark ? los ?
        public byte[] PercentOption = new byte[20];
        public byte unused;
        public short[] sound = new short[20];
        public short[] text = new short[20];

        public static List<LevelMetaData> Parse(string path)
        {
            using (BinaryReader b = new BinaryReader(File.Open(path, FileMode.Open)))
            {
            var res = new List<LevelMetaData>();
                while (b.BaseStream.Position != b.BaseStream.Length)
                {
                    var m = new LevelMetaData();
                    for (int i = 0; i < 20; i++)
                        m.randomRectsCoords[i] = RandomRectCoords.Parse(b);

                    for (int i = 0; i < 20; i++)
                        m.TimesIn10k[i] = b.ReadInt16().SwapBytes();

                    for (int i = 0; i < 20; i++)
                        m.BattleRange[i] = RandomRectBattleRange.Parse(b);

                    for (int i = 0; i < 20; i++)
                        for (int j = 0; j < 3; j++)
                            m.XapNum[i, j] = b.ReadInt16().SwapBytes();

                    for (int i = 0; i < 20; i++)
                        for (int j = 0; j < 3; j++)
                            m.XapChance[i, j] = b.ReadInt16().SwapBytes();

                    m.LandType = b.ReadByte();
                    m.unknown = b.ReadBytes(0x16);
                    m.PercentOption = b.ReadBytes(20);
                    m.unused = b.ReadByte();

                    for (int i = 0; i < 20; i++)
                        m.sound[i] = b.ReadInt16().SwapBytes();

                    for (int i = 0; i < 20; i++)
                        m.text[i] = b.ReadInt16().SwapBytes();
                res.Add(m);
                }
            return res;
            }
        }
    }

    public class RandomRectBattleRange
    {
        public short Low { get; set; }
        public short High { get; set; }


        internal static RandomRectBattleRange Parse(BinaryReader b)
        {
            var r = new RandomRectBattleRange
            {
                Low = b.ReadInt16().SwapBytes(),
                High = b.ReadInt16().SwapBytes()
            };
            return r;
        }
    }

    public class RandomRectCoords
    {
        public short Top { get; set; }
        public short Left { get; set; }
        public short Bottom { get; set; }
        public short Right { get; set; }


        internal static RandomRectCoords Parse(BinaryReader b)
        {
            var r = new RandomRectCoords
            {
                Top = b.ReadInt16().SwapBytes(),
                Left = b.ReadInt16().SwapBytes(),
                Bottom = b.ReadInt16().SwapBytes(),
                Right = b.ReadInt16().SwapBytes()
            };
            return r;
        }
    }

