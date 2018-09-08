using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventureCamera : MonoBehaviour {

    //public AdventureManager adventureManager;
    float yOffset = 0.15f;

    // Use this for initialization
    void Start()
    {
        //adventureManager = GameObject.Find("Adventure").GetComponent<AdventureManager>();
    }

    // Update is called once per frame
    void Update()
    {
        var x = GameData.x + 5.0f;
        var y = -GameData.y - 2f + yOffset;

        if (GameData.x < 5)
            x = 10;
        if (GameData.y < 5)
            y = -6f + yOffset;
        if (GameData.x > 85)
            x = 90;
        if (GameData.y > 84)
            y = -86 + yOffset;
        transform.position = new Vector3(x, y, transform.position.z);
    }
}
