using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileRenderer : MonoBehaviour {
    private Tilemap groundTilemap;
    private Tilemap specialTilemap;
    public AdventureManager adventureManager;
    public GameObject grid;

    private int ActiveLevel = -1;

    // Use this for initialization
    void Start () {
        Setup();
    }


    // Update is called once per frame
    void Update () {
        if(GameData.level != ActiveLevel)
        {
            ActiveLevel = GameData.level;
            Render();
        }
    }

    public void Setup()
    {
        var groundGo = new GameObject("Ground");
        groundGo.transform.parent = grid.transform;
        groundTilemap = groundGo.AddComponent<Tilemap>();
        groundGo.AddComponent<TilemapRenderer>();

        var specialGo = new GameObject("Special");
        specialGo.transform.parent = grid.transform;
        specialTilemap = specialGo.AddComponent<Tilemap>();
        specialGo.AddComponent<TilemapRenderer>();
    }

    public void Render()
    {
        var landId = GameData.LevelMetaData[GameData.level].LandType;

        var sprites = GameData.TileSprites[landId];
        var iconsMap = GameData.Icons;
        short[,] tiles = GameData.LevelData.GetTiles(ActiveLevel);

        var baseTileId = GameData.Tilesets[landId].base_tile_id - 1;

        Tile m_Tile = ScriptableObject.CreateInstance<Tile>();
        Tile s_Tile = ScriptableObject.CreateInstance<Tile>();

        groundTilemap.ClearAllTiles();
        specialTilemap.ClearAllTiles();

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

    public void Alter(short level, short x, short y, short tileId, bool isDungeon)
    {
        Tile newTile = ScriptableObject.CreateInstance<Tile>();
        Vector3Int p = new Vector3Int(x, -y, 0);

        if (tileId > 200 || tileId < 0) // special tile
        {
            var name = (tileId + 1).ToString("D5");
            newTile.sprite = GameData.Icons[name];
            specialTilemap.SetTile(p, newTile);
        }
        else // normal tile
        {
            var landId = GameData.LevelMetaData[GameData.level].LandType;
            var sprites = GameData.TileSprites[landId];
            newTile.sprite = sprites[tileId];
            groundTilemap.SetTile(p, newTile);
            specialTilemap.SetTile(p, null);
        }
    }
}
