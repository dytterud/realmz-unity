using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

public class LevelData
{
    private List<short[,]> tiles = new List<short[,]>();

    private LevelData()
    {

    }

    // Data LD
    public static LevelData Parse(string path)
    {
        var res = new LevelData();
        using (BinaryReader b = new BinaryReader(File.Open(path, FileMode.Open)))
        {
            while (b.BaseStream.Position != b.BaseStream.Length)
            {
                var m = new short[90, 90];
                for (int i = 0; i < 90; ++i)
                {
                    for (int j = 0; j < 90; ++j)
                    {
                        m[j, i] = b.ReadInt16().SwapBytes();
                    }
                }
                res.tiles.Add(m);
            }
        }
        return res;
    }

    public short[,] GetTiles(int level)
    {
        return tiles.ElementAt(level);
    }

    public int TileId(int x, int y, int level)
    {
        return GetTiles(level)[y, x];
    }

    public int TileIdNormalized(int x, int y, int level)
    {
        return TileId(x, y ,level) % 1000;
    }
}

