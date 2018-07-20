using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileRenderer : MonoBehaviour {
    private Tilemap groundTilemap;
    private Tilemap specialTilemap;
    internal AdventureManager adventureManager;

    // Use this for initialization
    void Start () {
        GameObject go = new GameObject("Grid");
        go.AddComponent<Grid>();

        var groundGo = new GameObject("Ground");
        groundGo.transform.parent = go.transform;
        groundTilemap = groundGo.AddComponent<Tilemap>();
        groundGo.AddComponent<TilemapRenderer>();

        var specialGo = new GameObject("Special");
        specialGo.transform.parent = go.transform;
        specialTilemap = specialGo.AddComponent<Tilemap>();
        specialGo.AddComponent<TilemapRenderer>();

        Render();
    }


    // Update is called once per frame
    void Update () {
        
    }

    public void Render()
    {
        var level = adventureManager.level;

        Sprite[] sprites = Resources.LoadAll<Sprite>(GetSprite(level));
        Sprite[] icons = Resources.LoadAll<Sprite>("Data Files/The Family Jewels/cicn/");
        var iconsMap = icons.ToDictionary(x => x.name, x => x);
        short[,] tiles = adventureManager.levelData.GetTiles(level);

        var baseTileId = adventureManager.GetBaseTile();

        Tile m_Tile = ScriptableObject.CreateInstance<Tile>();
        Tile s_Tile = ScriptableObject.CreateInstance<Tile>();

        groundTilemap.ClearAllTiles();
        int tileId;
        for (int y = 0; y < 90; y++)
        {
            for (int x = 0; x < 90; x++)
            {
                tileId = (tiles[y, x] % 1000) - 1;
                Vector3Int p = new Vector3Int(x, -y, 0);
                if (tileId > 200 || tileId < 0) // special tile
                {
                    var name = (tileId + 1).ToString("D5");
                    s_Tile.sprite = iconsMap[name];
                    specialTilemap.SetTile(p, s_Tile);

                    m_Tile.sprite = sprites[baseTileId];
                }
                else // normal tile
                {
                    m_Tile.sprite = sprites[tileId];

                }

                groundTilemap.SetTile(p, m_Tile);
            }
        }
    }

    private string GetSprite(int level)
    {
        var path = "Data Files/The Family Jewels/pict/";
        switch (level)
        {
            case 0:
                return path + "00300";
            default:
                throw new Exception();
        }
    }
}
