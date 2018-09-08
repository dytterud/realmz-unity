using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour {

    //static SceneSwitcher Instance;

    // Use this for initialization
    void Start () {

    }

    public void LoadMain()
    {
        // load data

        SceneManager.LoadScene("MainScene", LoadSceneMode.Additive);
    }

    public void LoadScenario()
    {
        var current = SceneManager.GetActiveScene();
        // load data
        SceneManager.UnloadSceneAsync("MainScene");
        SceneManager.LoadScene("AdventureScene", LoadSceneMode.Additive);
    }
}
