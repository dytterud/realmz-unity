using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameData {

    public static Tileset[] Tilesets = new Tileset[11];
    public static Sprite[][] TileSprites = new Sprite[11][];
    public static ScenarioData ScenarioData;
    public static LevelData LevelData;
    public static bool[] SolidSpecial;
    public static List<ActionPointData> ActionPoints;
    public static List<ActionPointData> ActionPointsExtra;
    public static List<string> Strings;
    public static List<SimpleEncounterData> SimpleEncounter;
    public static short[][] ExtraCodes;
    internal static Dictionary<string, Sprite> Icons;
    internal static List<LevelMetaData> LevelMetaData;

    // Adventure
    internal static AdventureManager AdventureManager;
    public static AdventureGameState state = AdventureGameState.Map;
    internal static ActionPoint CurrentActionPoint;
    public static int x;
    public static int y;
    public static int level;
    internal static SimpleEncounter CurrentSimpleEncounter;
}
