using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private SceneSwitcher sceneSwitcher;

    // Use this for initialization
    void Start () {
        GameLoader.LoadData();
        GameLoader.LoadScenario();

        sceneSwitcher = gameObject.GetComponent<SceneSwitcher>();
        sceneSwitcher.LoadMain();
    }
	
}
