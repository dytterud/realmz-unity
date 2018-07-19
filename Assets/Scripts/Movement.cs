using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public AdventureManager adventureManager;

    // Use this for initialization
    void Start () {
        adventureManager = GameObject.Find("Adventure").GetComponent<AdventureManager>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!Input.anyKey)
            return;

        var key = GetKey();

        var NewX = 0;
        var NewY = 0;

        switch (key)
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
        //if (!Input.GetKey(KeyPressed))
        //{
        //    KeyPressed = KeyCode.None;
        //}
        return KeyCode.None;
    }
}
