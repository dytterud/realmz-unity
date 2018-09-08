using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public AdventureManager adventureManager;
    public float inputDelay = 0.2f;

    private KeyCode keyPressed = KeyCode.None;
    private float inputDelayElapsed = 0f;


    // Use this for initialization
    void Start () {
        adventureManager = GameObject.Find("Adventure").GetComponent<AdventureManager>();
    }
    
    // Update is called once per frame
    void Update () {
        if (GameData.state != AdventureGameState.Map)
            return;

        if (!Input.anyKey)
            return;

        var newKey = GetKey();

        if(newKey == KeyCode.None) // no new key
        {
            if (Input.GetKey(keyPressed)) // prev key is still pressed
            { 
                inputDelayElapsed += Time.deltaTime;
                if(inputDelayElapsed > inputDelay)
                {
                    newKey = keyPressed;
                    inputDelayElapsed = 0f;
                }
                else
                {
                    return;
                }
            }
            else
            {
                keyPressed = KeyCode.None;
            }
        }
        else
        {
            keyPressed = newKey;
            inputDelayElapsed = -0.4f; // wait longer first time
        }


        var NewX = 0;
        var NewY = 0;

        switch (newKey)
        {
            case KeyCode.UpArrow:
                NewY = -1;
                break;
            case KeyCode.DownArrow:
                NewY = 1;
                break;
            case KeyCode.RightArrow:
                NewX = 1;
                break;
            case KeyCode.LeftArrow:
                NewX = -1;
                break;
            default:
                return;
        };

        adventureManager.MoveRelative(NewX, NewY);
    }

    KeyCode GetKey()
    {
        var keys = new List<KeyCode>() { KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.DownArrow, KeyCode.UpArrow };

        foreach (var key in keys)
        {
            if (Input.GetKeyDown(key))
            {
                return key;
            }
        }

        return KeyCode.None;
    }
}
