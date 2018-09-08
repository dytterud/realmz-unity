using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AdventureManager : MonoBehaviour {
    public int prev_x;
    public int prev_y;
    public int prev_level;

    public TileRenderer tileRenderer;
    public TextHandler textHandler;
    public ActionPointHandler actionPointHandler;
    public SimpleEncounterHandler simpleEncounterHandler;

    // Use this for initialization
    void Start () {
        GameData.AdventureManager = this;

        tileRenderer = gameObject.GetComponent<TileRenderer>();
        textHandler = gameObject.GetComponent<TextHandler>();
        actionPointHandler = gameObject.GetComponent<ActionPointHandler>();
        simpleEncounterHandler = gameObject.GetComponent<SimpleEncounterHandler>();
    }
    
    // Update is called once per frame
    void Update () {

    }

    public void MoveRelative(int x, int y)
    {
        HandleMovement(GameData.x + x, GameData.y + y, GameData.level);
    }

    void HandleMovement(int x, int y, int level)
    {

        // is outside map
        if (x < 0 || x > 89 || y < 0 || y > 89)
            return;

        var tileId = GameData.LevelData.TileId(x, y, level);

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
            Move(x, y, level);
            actionPointHandler.Handle(x, y, level);
            return;
        }

        var tileIdNormalized = tileId % 1000;

        // is blocked
        if (tileIdNormalized >= 1 && tileIdNormalized <= 200) // normal tile
        {
            var landId = GameData.LevelMetaData[level].LandType;
            var tile = GameData.Tilesets[landId].tiles[tileIdNormalized];
            if (tile.solid_type == 2)
                return;
        }
        else // special tile
        {
            if (GameData.SolidSpecial[Math.Abs(tileIdNormalized)])
                return;
        }

        // get new pos

        // is AP

        Move(x, y, level);
    }

    public void Move(int x, int y, int level)
    {
        // move
        prev_x = GameData.x;
        GameData.x = x;
        prev_y = GameData.y;
        GameData.y = y;
        prev_level = level;
        GameData.level = level;

        // play sound

        // add time
            // check surounding secret
            // random event

    }

    public void MoveBack()
    {
        GameData.x = prev_x;
        GameData.y = prev_y;
    }

}
