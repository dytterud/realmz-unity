using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileRenderer : MonoBehaviour {
    private Tilemap groundTilemap;
    internal AdventureManager adventureManager;

    // Use this for initialization
    void Start () {
        GameObject go = new GameObject("Grid");
        go.AddComponent<Grid>();

        var groundGo = new GameObject("Ground");
        groundGo.transform.parent = go.transform;
        groundTilemap = groundGo.AddComponent<Tilemap>();
        groundGo.AddComponent<TilemapRenderer>();

        Render();
    }


    // Update is called once per frame
    void Update () {
        
    }

    public void Render()
    {
        var level = adventureManager.level;

        Sprite[] sprites = Resources.LoadAll<Sprite>(GetSprite(level));
        short[,] tiles = adventureManager.levelData.GetTiles(level);

        Tile m_Tile = ScriptableObject.CreateInstance<Tile>();

        groundTilemap.ClearAllTiles();
        int tileId;
        for (int y = 0; y < 90; y++)
        {
            for (int x = 0; x < 90; x++)
            {
                tileId = (tiles[y, x] % 1000) - 1;
                if (tileId > 200 || tileId < 0)
                    continue;

                Vector3Int p = new Vector3Int(x, -y, 0);
                m_Tile.sprite = sprites[tileId];
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
