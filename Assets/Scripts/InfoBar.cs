using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoBar : MonoBehaviour {

    public Text TextX;
    public Text TextY;

    // Use this for initialization
    void Start () {
    }
    
    // Update is called once per frame
    void Update () {
        TextX.text = ""+GameData.x;
        TextY.text = ""+GameData.y;
    }
}
