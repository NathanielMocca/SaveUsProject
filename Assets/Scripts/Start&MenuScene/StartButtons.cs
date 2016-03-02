using UnityEngine;
using System.Collections;

public class StartButtons : MonoBehaviour {

    public static int language=0;//0=English,1=Chinese
    private bool LanguageButton,StartButton,MenuButton,ENButton,CNButton;

	// Use this for initialization
	void Start () {
        LanguageButton=false;
        StartButton=false;
        MenuButton=false;
        ENButton = false;
        CNButton = false;
	}
	
	// Update is called once per frame
	void Update () {
	    if(ENButton)
        {
            language = 0;
        }
        else if(CNButton)
        {
            language = 1;
        }

        if(StartButton)
        {
            Application.LoadLevel("Intro");//Change into Intro Scene
        }
        if(MenuButton)
        {
            Application.LoadLevel("Menu"); //Change into Menu Scene
        }
	}

    void OnGUI()
    {
        switch(language)
        {
            case 1:
                StartButton=GUI.Button(new Rect(10, 80, 150, 23), "開始遊戲");
                MenuButton = GUI.Button(new Rect(10, 110, 150, 23), "關卡選擇");
                GUI.Box(new Rect(10, 140, 150, 23), "");
               LanguageButton=GUI.Toggle(new Rect(50, 140, 110,23), LanguageButton, "語言");
                break;
            default:
                StartButton=GUI.Button(new Rect(10, 80, 150, 23), "Start");
                MenuButton = GUI.Button(new Rect(10, 110, 150, 23), "Menu");
                GUI.Box(new Rect(10, 140, 150, 23), "");
                LanguageButton=GUI.Toggle(new Rect(50, 140, 110, 23), LanguageButton,"Language");
                break;
        }
        if (LanguageButton)
        {
            ENButton = GUI.Button(new Rect(30, 170, 100, 23), "English");
            CNButton = GUI.Button(new Rect(30, 200, 100, 23), "中文");
        }
    }
}
