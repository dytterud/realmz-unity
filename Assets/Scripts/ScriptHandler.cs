using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class ScriptHandler
{
    private readonly AdventureGameState scriptState;
    private short[] commandCodes;
    private short[] argumentCodes;
    private int position = -1;

    private static readonly System.Random random = new System.Random();

    public ScriptHandler(AdventureGameState scriptState, short[] CommandCodes, short[] ArgumentCodes)
    {
        this.scriptState = scriptState;
        commandCodes = CommandCodes;
        argumentCodes = ArgumentCodes;
    }

    /// <summary>
    ///    
    /// </summary>
    /// <returns>True if script has reach the end</returns>
    public bool Parse()
    {
        position++;
        if (position == commandCodes.Length)
        {
            return true;
        }

        var code = commandCodes[position];
        var arg = argumentCodes[position];
        short[] ec;

        switch (code)
        {
            case 0:
                break;
            case 1: // display text
                // Negative ID will cause string to be displayed without requiring player to click mouse to continue
                if (arg < 0)
                    GameData.AdventureManager.textHandler.SetText(-arg);
                else
                    GameData.AdventureManager.textHandler.SetText(arg, scriptState);
                break;
            case 2: // battle
                MonoBehaviour.print("Battle: " + arg);
                break;
            case 3: // Player option
                ec = GetEc(arg);
                MonoBehaviour.print("Player option: " + ec.ToPrettyString());
                break;
            case 4: // simple encounter
                GameData.AdventureManager.simpleEncounterHandler.Handle(arg);
                break;
            case 9: // play sound
                MonoBehaviour.print("Play sound: " + arg);
                break;
            case 12: // change land tile
                ec = GetEc(arg);
                MonoBehaviour.print("change land tile: " + ec.ToPrettyString());
                // 1) Land / Dungeon level of tile to change
                // 2)	X - Coordinate
                // 3)	Y - Coordinate
                // 4)	New Tile ID
                // 5)	0 = Land Level, 1 = Dungeons

                GameData.AdventureManager.tileRenderer.Alter(ec[0], ec[1], ec[2], ec[3], ec[4] == 1);
                break;
            case 16: // heal / Hurt Party
                ec = GetEc(arg);
                MonoBehaviour.print("heal / Hurt Party: " + ec.ToPrettyString());
                break;
            case 19: // Display Random String
                ec = GetEc(arg);
                //MonoBehaviour.print("Random String. x-ap: " + ec.ToPrettyString());
                var stringId = random.Next(ec[0], ec[1] + 1);
                GameData.AdventureManager.textHandler.SetText(stringId, scriptState);
                break;
            case 23: // Alter Random Rectangle Information of a Land 
                ec = GetEc(arg);
                MonoBehaviour.print("23: Alter Land Random Rectangle: " + ec.ToPrettyString());
                break;
            case 24: // exit Action Point and Keep
                GameData.AdventureManager.actionPointHandler.ExitAndKeep();
                return false;
            case 25: // exit Action Point and Delete Action
                GameData.AdventureManager.actionPointHandler.ExitAndRemove();
                return false;
            case 26: // get Mouse
                     // this will put up a small window that requires the player to click the mouse to continue
                MonoBehaviour.print("Get mouse.");
                break;
            case 27: // display Picture
                MonoBehaviour.print("Display picture: " + arg);
                break;
            case 29: // give / Display Map
                MonoBehaviour.print("Give / Display map: " + arg);
                break;
            case 28: // give / Display Map
                MonoBehaviour.print("Redraw screen (remove picture)");
                break;
            case 33: // take gold
                ec = GetEc(arg);
                MonoBehaviour.print("33: Take gold. x-ap: " + ec.ToPrettyString());
                break;

            case 35: // Eliminate Simple Encounter Option (current)
                MonoBehaviour.print("35: Eliminate Simple Encounter Option (current)");

                GameData.AdventureManager.simpleEncounterHandler.RemoveOption(arg);
                break;
            case 39: // extend Action Point Script
                //MonoBehaviour.print("Extend AP: " + arg);
                AddExtraAp(arg);
                break;
            case 42: // Branch on Percent 
                ec = GetEc(arg);
                MonoBehaviour.print("Branch on Percent: " + ec.ToPrettyString());
                break;
            case 45: // Teleport Only 
                ec = GetEc(arg);
                MonoBehaviour.print("Teleport Only : " + ec.ToPrettyString());
                if (ec[0] != -1) GameData.level = ec[0];
                if (ec[1] != -1) GameData.x = ec[1];
                if (ec[2] != -1) GameData.y = ec[2];
                // play sound
                break;
            case 56: // Branch on Battle Outcome
                ec = GetEc(arg);
                MonoBehaviour.print("Branch on Battle Outcome: " + ec.ToPrettyString());
                break;
            default:
                MonoBehaviour.print("Unknown code: " + code +" arg: "+arg);
                break;
        }

        return false;
    }

    private void AddExtraAp(short id)
    {
        var eap = GameData.ActionPointsExtra[id];
        position = -1;
        commandCodes = eap.CommandCodes;
        argumentCodes = eap.ArgumentCodes;
    }

    private short[] GetEc(short id)
    {
        return GameData.ExtraCodes[id];
    }
    //public bool Parse(int[] CommandCodes, int[] ArgumentCodes)
    //{

    //}
}
