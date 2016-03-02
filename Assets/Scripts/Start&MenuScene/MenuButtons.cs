using UnityEngine;
using System.Collections;

public class MenuButtons : MonoBehaviour {

    private int language = 0;
	// Use this for initialization
	void Start () {
        language = StartButtons.language;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        switch (language)
        {
            case 1:
                if (GUI.Button(new Rect(250, 80, 150, 23), "首頁")) Application.LoadLevel("Start");
                if (GUI.Button(new Rect(250, 110, 150, 23), "遊戲說明")) Application.LoadLevel("Intro");
                if (GUI.Button(new Rect(250, 140, 150, 23), "1.自動體外心臟去顫器")) Application.LoadLevel("AED");
                break;
            default:
                if (GUI.Button(new Rect(250, 80, 150, 23), "Home")) Application.LoadLevel("Start");
                if (GUI.Button(new Rect(250, 110, 150, 23), "Introduction")) Application.LoadLevel("Intro");
                if (GUI.Button(new Rect(250, 140, 150, 23), "1.AED")) Application.LoadLevel("AED");
                break;
        }
    }
}
