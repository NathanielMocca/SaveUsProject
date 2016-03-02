using UnityEngine;
using System.Collections;

public class Introduction : MonoBehaviour {

    private int language = 0;
    private int next = 0;
    // Use this for initialization
    void Start()
    {
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
                switch(next)
                {
                    case 0:
                        GUI.Box(new Rect(400, 200, 500, 30), "這是一款模擬急救的遊戲,");
                        GUI.Box(new Rect(400, 230, 500, 30), "你可以將手置於感應器上方。");
                        break;
                    case 1:
                        GUI.Box(new Rect(400, 200, 500, 30), "你必須于時間內完成指定的動作，");
                        GUI.Box(new Rect(400, 230, 500, 30), "按下p鍵可以暫停或繼續遊戲。");
                        break;
                    case 2:
                        GUI.Box(new Rect(400, 200, 500, 30), "解說完畢，");
                        GUI.Box(new Rect(400, 230, 500, 30), "點擊 下一步 即開始遊戲！");
                        break;
                }
                if (GUI.Button(new Rect(400, 400, 100, 23), "下一步")) next++;
                if ((GUI.Button(new Rect(800, 400, 100, 23), "跳過"))||next==3) Application.LoadLevel("AED");
		if (GUI.Button(new Rect(600, 400, 100, 23), "首頁")) Application.LoadLevel("Start");
                break;
            default:
                 switch(next)
                {
                    case 0:
                        GUI.Box(new Rect(400, 200, 500, 30), "This is a first aid simulator(game),");
                        GUI.Box(new Rect(400, 230, 500, 30), "You can put your hands in front of leap motion controller.");
                        break;
                    case 1:
                         GUI.Box(new Rect(400, 200, 500, 30),"You must finish the steps in times，");
                        GUI.Box(new Rect(400, 230, 500, 30), "press p for pause or resume your games.");
                        break;
                    case 2:
                        GUI.Box(new Rect(400, 200, 500, 30), "That's all,");
                        GUI.Box(new Rect(400, 230, 500, 30), "Press Next to start game!");
                        break;

                }
                 if (GUI.Button(new Rect(400, 400, 100, 23), "Next")) next++;
                 if ((GUI.Button(new Rect(800, 400, 100, 23), "Skip")) || next == 3) Application.LoadLevel("AED");
 		if (GUI.Button(new Rect(600, 400, 100, 23), "Home")) Application.LoadLevel("Start");
                break;
        }
    }
}
