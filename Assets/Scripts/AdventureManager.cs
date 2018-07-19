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

    TileRenderer tileRenderer;

    // Use this for initialization
    void Start () {
        levelData = LevelData.Parse(Application.dataPath + "/Resources/Scenarios/City Of Bywater/Data LD");
        scenarioData = ScenarioData.Parse(Application.dataPath + "/Resources/Scenarios/City Of Bywater/City of Bywater");
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
        Debug.Log("Tile " + levelData.TileId(x, y, level) + " " + levelData.TileIdNormalized(x, y, level));
        // get new pos

        // is blocked
        // is AP

        // move

        // check surounding secret
        //

        this.x = x;
        this.y = y;
    }
}
