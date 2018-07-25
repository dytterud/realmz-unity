using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventureManager : MonoBehaviour {

    public int x;
    public int y;
    public int level;

    public ScenarioData scenarioData;
    public LevelData levelData;
    public Tileset[] tilesets = new Tileset[11];
    public bool[] solidSpecial;

    TileRenderer tileRenderer;

    // Use this for initialization
    void Start () {
        levelData = LevelData.Parse(Application.dataPath + "/Resources/Scenarios/City Of Bywater/Data LD");
        scenarioData = ScenarioData.Parse(Application.dataPath + "/Resources/Scenarios/City Of Bywater/City of Bywater");
        solidSpecial = Solid.Parse(Application.dataPath + "/Resources/Scenarios/City Of Bywater/Data Solids");

        tilesets[0] = Tileset.Parse(Application.dataPath + "/Resources/Data files/Data P BD");

        x = scenarioData.StartX;
        y = scenarioData.StartY;
        level = scenarioData.StartLevel;

        tileRenderer = gameObject.AddComponent<TileRenderer>();
        tileRenderer.adventureManager = this;
    }
    
    // Update is called once per frame
    void Update () {
        
    }

    public void MoveRelative(int x, int y)
    {
        HandleMovement(this.x + x, this.y + y, this.level);
    }

    void HandleMovement(int x, int y, int level)
    {

        // is outside map
        if (x < 0 || x > 89 || y < 0 || y > 89)
            return;

        var tileId = levelData.TileId(x, y, level);
        var tileIdNormalized = tileId % 1000;

        if (tileId <= -3000 || tileId > 3000) // secret
        {
            // chanse of discover?? take from character
            // if found
            // add s
            // change ap code from 3xx to 1xxx

            // else
        }

        if ((tileId <= -1000 && tileId > -3000) || (tileId > 1000 && tileId < 3000)) // action point
        {
            Debug.Log("AP " + tileId);
            var locCode = x + y * 100 + level * 10000;

            Move(x, y, level);



            return;
        }

        // is blocked
        if (tileIdNormalized >= 1 && tileIdNormalized <= 200) // normal tile
        {
            var tile = tilesets[level].tiles[tileIdNormalized];
            if (tile.solid_type == 2)
                return;
        }
        else // special tile
        {
            if (solidSpecial[Math.Abs(tileIdNormalized)])
                return;
        }

        // get new pos

        // is AP

        Move(x, y, level);


        // check surounding secret



    }

    private void Move(int x, int y, int level)
    {
        // move
        this.x = x;
        this.y = y;

        // play sound
    }

    internal int GetBaseTile()
    {
        return tilesets[level].base_tile_id;
    }
}
