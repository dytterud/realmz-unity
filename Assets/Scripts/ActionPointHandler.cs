using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ActionPointHandler : MonoBehaviour {

    // Use this for initialization
    void Start () {
        
    }
    
    // Update is called once per frame
    void Update () {
        if (GameData.state == AdventureGameState.ActionPoint)
        {
            if (GameData.CurrentActionPoint.ScriptHandler.Parse())
            {
                ExitAndRemove();
            }

        }
    }

    public void Handle(int x, int y, int level)
    {
        var locCode = x + y * 100 + level * 10000;
        var ap = GameData.ActionPoints.Where(a => a.LocationCode == locCode).First();

        Debug.Log("ap " + ap.PercentChance + "% " + ap.CommandCodes.ToPrettyString());

        if(ap.PercentChance < 1)
        {
            return;
        }

        GameData.CurrentActionPoint = new ActionPoint()
        {
            ScriptHandler = new ScriptHandler(AdventureGameState.ActionPoint, ap.CommandCodes, ap.ArgumentCodes),
            Data = ap
        };

        GameData.state = AdventureGameState.ActionPoint;
    }

    internal void Move()
    {
        var ap = GameData.CurrentActionPoint.Data;
        GameData.AdventureManager.Move(ap.ToX, ap.ToY, ap.ToLevel);
    }

    public void ExitAndKeep()
    {
        Move();
        GameData.state = AdventureGameState.Map;
    }

    public void ExitAndRemove()
    {
        GameData.CurrentActionPoint.Data.PercentChance = 0;
        //Move();
        GameData.state = AdventureGameState.Map;
    }
}
