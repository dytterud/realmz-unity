using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextHandler : MonoBehaviour {

    public Text textArea;
    public AdventureManager adventureManager;
    private AdventureGameState returnState;

    // Use this for initialization
    void Start () {
        textArea.text = "";
    }
    
    // Update is called once per frame
    void Update () {
        if (GameData.state == AdventureGameState.Text)
        {
            if (Input.anyKeyDown)
            {
                GameData.state = returnState;
                textArea.text = "";
            }

        }
    }

    public void SetText(int textId)
    {
        var text = GameData.Strings[textId];
        textArea.text = text;
    }

    public void SetText(int textId, AdventureGameState returnState)
    {
        GameData.state = AdventureGameState.Text;
        SetText(textId);
        this.returnState = returnState;
    }

    public void ClearText()
    {
        textArea.text = "";
    }
}
