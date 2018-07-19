using System;
using System.IO;

public class ScenarioData
{
    public int RecommendedStartingLevels;
    public int Unknown1;
    public int StartLevel;
    public int StartX;
    public int StartY;

    public static ScenarioData Parse(string path)
    {
        using (BinaryReader b = new BinaryReader(File.Open(path, FileMode.Open)))
        {
            return new ScenarioData
            {
                RecommendedStartingLevels = b.ReadInt32().SwapBytes(),
                Unknown1 = b.ReadInt32().SwapBytes(),
                StartLevel = b.ReadInt32().SwapBytes(),
                StartX = b.ReadInt32().SwapBytes(),
                StartY = b.ReadInt32().SwapBytes()
            };
        }
    }
}