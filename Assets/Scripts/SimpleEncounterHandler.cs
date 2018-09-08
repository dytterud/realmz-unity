using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleEncounterHandler : MonoBehaviour {

    public GameObject simpleEncounterGo;
    public Text s1;
    public Text s2;
    public Text s3;
    public Text s4;
    public Button exitBtn;
    public AdventureManager adventureManager;
    private ScriptHandler scriptHandler;

    // Use this for initialization
    void Start () {
		exitBtn.onClick.AddListener(Exit);
    }
	
	// Update is called once per frame
	void Update () {
        if (GameData.state == AdventureGameState.SimpleEncounter)
        {
            if(scriptHandler != null)
            {
                if (scriptHandler.Parse())
                {
                    if (GameData.CurrentSimpleEncounter.Attempted >= GameData.CurrentSimpleEncounter.Data.MaxTimes)
                    {
                        Exit();
                        return;
                    }

                    scriptHandler = null;
                    simpleEncounterGo.SetActive(true);
                    adventureManager.textHandler.SetText(GameData.CurrentSimpleEncounter.Data.Prompt);
                    // play sound
                }
            }

        }
    }

    public void Handle(short id)
    {
        GameData.CurrentSimpleEncounter = new SimpleEncounter(id);
        GameData.state = AdventureGameState.SimpleEncounter;
        var data = GameData.CurrentSimpleEncounter.Data;

        // how to tell if one is not used??
        s1.text = data.OptionTexts[0];
        s2.text = data.OptionTexts[1];
        s3.text = data.OptionTexts[2];
        s4.text = data.OptionTexts[3];

        if (data.CanBackout == 0)
            exitBtn.gameObject.SetActive(false);
        else
            exitBtn.gameObject.SetActive(true);


        scriptHandler = null;
        simpleEncounterGo.SetActive(true);
        adventureManager.textHandler.SetText(data.Prompt);
        // play sound

        // If you place - 4 as the Result # for option 1, it will branch directly to Result #4 and skip giving the player any options.
        // This will let you do some preliminary stuff prior to any choices being offered to the player.

    }

    public void RemoveOption(int option) // 1 - 4
    {
        switch (option)
        {
            case 1:
                s1.gameObject.SetActive(false);
                break;
            case 2:
                s2.gameObject.SetActive(false);
                break;
            case 3:
                s3.gameObject.SetActive(false);
                break;
            case 4:
                s4.gameObject.SetActive(false);
                break;
            default:
                break;
        }

    }

    public void Selected(int selection)
    {
        GameData.CurrentSimpleEncounter.Attempted++;
        var data = GameData.CurrentSimpleEncounter.Data;
        // play sound
        var index = data.ChoiceResultIndex[selection] - 1;
        var CommandCodes = data.ChoiceCodes[index];
        var ArgumentCodes = data.ChoiceArgs[index];
        Debug.Log("Result #" + (index+1)+" Codes: "+ CommandCodes.ToPrettyString() +" args: "+ ArgumentCodes.ToPrettyString());
        adventureManager.textHandler.ClearText();
        scriptHandler = new ScriptHandler(AdventureGameState.SimpleEncounter, CommandCodes, ArgumentCodes);
        simpleEncounterGo.SetActive(false);
    }

    public void Exit()
    {
        scriptHandler = null;
        simpleEncounterGo.SetActive(false);
        GameData.state = AdventureGameState.ActionPoint;
    }
}
