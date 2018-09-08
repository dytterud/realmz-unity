using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyController : MonoBehaviour
{

    //public AdventureManager adventureManager;

    // Use this for initialization
    void Start()
    {
        //adventureManager = GameObject.Find("Adventure").GetComponent<AdventureManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = PartyPos();
    }

    Vector3 PartyPos()
    {
        return new Vector3(GameData.x + 0.5f, 0.5f - GameData.y);
    }
}
