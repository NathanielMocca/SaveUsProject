using UnityEngine;
using System.Collections;

public class TimerAndPause : MonoBehaviour {
   public static float timer = 10; //given time,seconds

   public static bool pauseGame = false;
	public static bool playing = false;
   public static bool timesUp = false;
    bool showPauseGUI  = false;
    private int language = 0;
	private bool setable = true;
	// Use this for initialization
	void Start () {
        language = StartButtons.language;
        timesUp = false;
	}
	
	// Update is called once per frame
	public void Update () {
        timer -= Time.deltaTime; // counting time

		//check if time's up
        if (timer <= 0)
        {
            timer = 0;
            timesUp = true;
            pauseGame = true; //if time's up then stop the game
        }
        else if(timer>0)
        {
            timesUp = false;
        }

		//--------------------new----------
		//check is in playing step,start counting & receive Key p 
		if (playing) 
		{	
			if (setable) //set start counting
			{
				pauseGame = false;
				setable = false;
			}
			if (Input.GetKeyDown ("p")) {	//press p for pause
				pauseGame = !pauseGame;
			}
		} 
		else if(!playing)
		{
			setable = true;
			pauseGame = true;
		}
		//--------------------end----------
			
		//pause
		if(pauseGame == true)
		{
			Time.timeScale = 0; // stop game's time
			//   pauseGame = true;
			//   GameObject.Find("Main Camera").GetComponent(MouseLook).enable=false;
			showPauseGUI = true;
		}
		else if (pauseGame == false)
		{
			Time.timeScale = 1; // resume time
			//pauseGame = false;
			//   GameObject.Find("Main Camera").GetCompoment(MouseLook).enable=true;
			showPauseGUI = false;
		}
        
    }
    void OnGUI () 
    {
        switch(language)
        {
            case 1:
                if(showPauseGUI==true) //pausing box
                {
                    GUI.Box(new Rect(10,40,100,23),"暫停中");
                }
                if(timer>0) //timer box
                {
                    GUI.Box(new Rect(10,10,150,23),"剩餘時間: "+timer.ToString("0")+" 秒");
                }
                else
                {
                    GUI.Box(new Rect(10,10,100,23),"時間到！！");
                }
                break;
            default:
                 if(showPauseGUI==true) //pausing box
                {
                    GUI.Box(new Rect(10,40,100,23),"Pause");
                }
                if(timer>0) //timer box
                {
                    GUI.Box(new Rect(10,10,150,23),"Time Remaining: "+timer.ToString("0")+" s");
                }
                else
                {
                    GUI.Box(new Rect(10,10,100,23),"Time's Up!!");
                }
                break;

        }
 
    }
}
