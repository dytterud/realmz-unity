using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public static class GameLoader
{
    public static void LoadData()
    {
        // outdoor
        GameData.Tilesets[0] = Tileset.Parse(Application.dataPath + "/Resources/Data files/Data P BD");
        GameData.TileSprites[0] = Resources.LoadAll<Sprite>("Data Files/The Family Jewels/pict/00300");
        // indoor
        GameData.Tilesets[4] = Tileset.Parse(Application.dataPath + "/Resources/Data files/Data Castle BD");
        GameData.TileSprites[4] = Resources.LoadAll<Sprite>("Data Files/The Family Jewels/pict/00304");


        GameData.Icons = Resources.LoadAll<Sprite>("Data Files/The Family Jewels/cicn/").ToDictionary(x => x.name, x => x);
    }

    public static void LoadScenario()
    {
        var path = Application.dataPath + "/Resources/Scenarios/City Of Bywater/";

        GameData.LevelData = LevelData.Parse(path + "Data LD");
        GameData.ScenarioData = ScenarioData.Parse(path + "City of Bywater");
        GameData.SolidSpecial = Solid.Parse(path + "Data Solids");
        GameData.ActionPoints = ActionPointData.Parse(path + "Data DD");
        GameData.ActionPointsExtra = ActionPointData.Parse(path + "Data ED3");
        GameData.Strings = String.Parse(path + "Data SD2");
        GameData.SimpleEncounter = SimpleEncounterData.Parse(path + "Data ED");
        GameData.ExtraCodes = ExtraCode.Parse(path + "Data EDCD");
        GameData.LevelMetaData = LevelMetaData.Parse(path + "Data RD");

        GameData.x = GameData.ScenarioData.StartX;
        GameData.y = GameData.ScenarioData.StartY;
        GameData.level = GameData.ScenarioData.StartLevel;
    }

    // save and load functions
}
