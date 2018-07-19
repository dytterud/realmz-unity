using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventureCamera : MonoBehaviour {

    public AdventureManager adventureManager;

    // Use this for initialization
    void Start()
    {
        adventureManager = GameObject.Find("Adventure").GetComponent<AdventureManager>();
    }

    // Update is called once per frame
    void Update()
    {
        var x = transform.position.x;
        var y = transform.position.y;
        if (adventureManager.x > 4 && adventureManager.x < 86)
            x = adventureManager.x + 5;
        if (adventureManager.y > 4 && adventureManager.y < 86)
            y = -adventureManager.y - 1.5f;
        transform.position = new Vector3(x, y, transform.position.z);
    }
}
