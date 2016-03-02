using UnityEngine;
using System.Collections;

public class AEDStep : MonoBehaviour {
    private int language = 0;  
    private int next = 0;
	private string line1,line2,line3,line4,nextstep;
	private bool failed = false;
    public AudioClip  step1ch, step2ch, step3ch, step4ch, step5ch;
    public AudioClip  step1en, step2en, step3en, step4en, step5en;

    AudioSource Audio;
    // Use this for initialization
    
    void Awake()
    {
        Audio = GetComponent<AudioSource>();
    }
    
    void Start()
    {
        language = StartButtons.language;
    }
	
	// Update is called once per frame
	void Update () {

		//DebugModeSkipPlay (); //enable for debug mode : checking step explanation or skip all gaming step

		WordController();//edit word here

        AudioController();//edit audio

		SetTimeOfStep();//set every gaming step's initial times

		CheckStepFailed();

		if(!failed)CheckStepClear();//check step success or not

		CheckIsplaying();//checking in gaming step or explaining step,decide start counting time or not
	}

	private void DebugModeSkipPlay() //enable for debug mode : checking step explanation or skip all gaming step
	{
		int remainder = next % 2;
		if (remainder==0 && next !=0)//gaming step
		{
			next++; 
		}
	}

    private void AudioController()
    {
        switch (language)
        {
            case 1:
                switch (next)
                {
                    case 0:
                        break;

                    case 1://step 1
                        Audio.clip = step1ch; //開啟AED，請按綠色按鈕
                        Audio.Play();
                        break;

                    case 2: //start step 1
                        break;

                    case 3://step 2
                        Audio.clip = step2ch; //請將貼片貼於對應位置
                        Audio.Play();
                        break;

                    case 4://start step 2        
                        break;

                    case 5://step 3
                        Audio.clip = step3ch; // 將插頭接上AED
                        Audio.Play();
                        break;

                    case 6://start step 3
                        break;

                    case 7://step 4
                        Audio.clip = step4ch; //請不要觸碰患者身體，機器自動檢查心律中
                        Audio.Play();
                        break;

                    case 8://start step 4
                        break;

                    case 9://step 5
                        Audio.clip = step5ch; //需要電擊，請按粉紅色按紐
                        Audio.Play();
                        break;

                    case 10:
                        break;
                    //step 11 is conclusion
                }
                break;

            default:
                switch (next)
                {
                    case 0:
                        break;

                    case 1:
                        Audio.clip = step1en; // turn on the power of AED,click the green button
                        Audio.Play();
                        break;

                    case 2:
                        break;

                    case 3://step 2
                        Audio.clip = step2en; //paste the stickers to corresponding place. 
                        Audio.Play();
                        break;

                    case 4://start step 2
                        break;

                    case 5://step 3
                        Audio.clip = step3en; // plug in the socket to AED
                        Audio.Play();
                        break;

                    case 6://start step 3
                        break;

                    case 7://step 4
                        Audio.clip = step4en; // DO NOT touch patient.Now checking heart rhythm automatically. 
                        Audio.Play();
                        break;

                    case 8://start step 4
                        break;

                    case 9://step 5
                        Audio.clip = step5en; // Need Defibrillation. please start AED by clicking the pink button. 
                        Audio.Play();
                        break;

                    case 10:
                        break;

                    //change word of this step 11 in OnGUI
                }
                break;
        }
    }

	private void WordController()
	{
		switch (language)
		{
			case 1:
				nextstep = "下一步";
				switch (next)
				{
				case 0:
					line1="目標:使用AED拯救昏迷中的病患";
					line2="本關卡共有 5 個步驟，請於時間內完成所有步驟！";
					line3="按P鍵暫停/繼續遊戲";
					line4="按R鍵重置目前步驟的道具位置/狀況";
					break;

				case 1://step 1
					line1 = "步驟 1：";
					line2 = "10秒內開啟AED機";
					line3 = "（點擊AED上綠色的按鈕）";
					line4 = "點擊 下一步 即開始！";
					break;

				case 2: //start step 1
					line1 = "步驟 1：";
					line2 = "開啟AED機";
					line3 = "失敗了";
					line4 = "再試一次！";
					break;

				case 3://step 2
					line1 ="步驟 2：";
					line2 = "30秒內把AED機旁的貼片貼于左肩和右腰處";
					line3 = "（觀察貼片上的圖片貼到對應位置）";
					line4 = "點擊 下一步 即開始！";
					break;

				case 4://start step 2        
					line1 = "步驟 2：";
					line2 = "把AED機旁的貼片貼于左肩和右腰處";
					line3 = "失敗了";
					line4 = "再試一次！";
					break;

				case 5://step 3
					line1 ="步驟 3：";
					line2 = "15秒內將插頭接上AED";
					line3 = "(插口位於AED的左上角)";
					line4 = "點擊 下一步 即開始！";
					break;

				case 6://start step 3
					line1 = "步驟 3：";
					line2 = "將插頭接上AED";
					line3 = "失敗了";
					line4 = "再試一次！";
					break;

				case 7://step 4
					line1 ="步驟 4：";
					line2 = "等待AED機自動檢查患者的心律直至時間結束。";
					line3 = "注意：不要碰患者的身體！";
					line4 = "點擊 下一步 即開始！";
					break;

				case 8://start step 4
					line1 = "步驟 4：";
                    line2 = "等待AED機自動檢查患者的心律直至時間結束";
					line3 = "失敗了";
					line4 = "再試一次！";
					break;

				case 9://step 5
					line1 ="步驟 5：";
					line2 = "10秒內啟動AED機開始電擊";
					line3 ="(點擊AED機上粉紅色的按鈕)";
					line4 = "點擊 下一步 即開始！";
					break;

				case 10:
					line1 = "步驟 5：";
					line2 = "啟動AED機開始電擊";
					line3 = "失敗了";
					line4 = "再試一次！";
					break;
			
					//step 11 is conclusion,change the word in OnGUI
				}
			break;

			default:
				nextstep = "Next";
				switch (next)
				{
				case 0:
					line1 = "Target:Use AED to save this patients that in a coma";
					line2 = "Total 5 steps in this level,finish all the step in times!";
					line3 = "Press P to pause/resume game";
					line4 = "Press R to reset Items position/condition of current step";
					break;

				case 1:
					line1 = "Step 1:";
					line2 = "Turn on the AED in 10 seconds";
					line3 = "(click the green button of AED)";
					line4 = "Press Next to start!";
					break;

				case 2:
					line1 = "Step 1:";
					line2 = "Turn on the AED";
					line3 = "You failed";
					line4 = "Try again!";
					break;

				case 3://step 2
					line1 = "Step 2:";
					line2 = "Put the sticker beside the AED on the shoulder and waist in 30 seconds.";
					line3 = "(position corresponding by the image of stickers)";
					line4 = "Press Next to start!";
					break;

				case 4://start step 2
					line1 = "Step 2:";
					line2 = "Put the sticker beside the AED on the shoulder and waist";
					line3 = "You failed";
					line4 = "Try again!";
					break;

				case 5://step 3
					line1 = "Step 3:";
					line2 = "Plug in the AED in 15 seconds.";
					line3 = "(the socket is on the upper left of the AED)";
					line4 = "Press Next to start!";
					break;

				case 6://start step 3
					line1 = "Step 3:";
					line2 = "Plug in the AED";
					line3 = "You failed";
					line4 = "Try again!";
					break;

				case 7://step 4
					line1 = "Step 4:";
                    line2 = "Wait the AED checking patient's heart rhythm automatic until time's up";
					line3 = "NOTICE:DON'T TOUCH THE PATIENT'S BODY";
					line4 = "Press Next to start!";
					break;

				case 8://start step 4
					line1 = "Step 4:";
                    line2 = "Wait the AED checking patient's heart rhythm automatic until time's up";
					line3 = "You failed";
					line4 = "Try again!";
					break;

				case 9://step 5
					line1 = "Step 5:";
					line2 = "Start the AED in 10 seconds";
					line3 = "(click the pink button of AED)";
					line4 = "Press Next to start!";
					break;

				case 10:
					line1 = "Step 5:";
					line2 = "Start the AED";
					line3 = "You failed";
					line4 = "Try again!";
					break;

					//change word of this step 11 in OnGUI
				}
				break;
		}
	}

	private void SetTimeOfStep()
	{
		switch (next)
		{
			case 1://step 1
				TimerAndPause.timer = 10; //set this step's timer
				break;
			case 3://step 2
				TimerAndPause.timer = 30; 
				break;
			case 5://step 3
				TimerAndPause.timer = 15; 
				break;
			case 7://step 4
				TimerAndPause.timer = 5;
				break;
			case 9://step 5
				TimerAndPause.timer = 10;
				break;
		}
	}

	private void CheckStepFailed()
	{
		switch(next)
		{
		case 2:
			if (TimerAndPause.timesUp)failed = true;
			break;
		case 4:
			if (TimerAndPause.timesUp)failed = true;
			break;
		case 6:
			if (TimerAndPause.timesUp)failed = true;
			break;
		case 8://waiting step
			break;
		case 10:
			if (TimerAndPause.timesUp)failed = true;
			break;

		default:
			failed = false;
			break;
		}
	}

	private void CheckStepClear()
	{
		switch(next)
		{
		case 2:
			GameObject onofftext = GameObject.Find("OnOffText");
			AEDOnOff onoff = onofftext.GetComponent<AEDOnOff>();
			if (!(onoff.NowOff)) next++;
			break;
		case 4:
			if (shoulderDetect.ShoulderDetected && waistDetect.WaistDetected) next++;
			break;
		case 6:
			if (SocketDetect.SocketDetected) next++;
			break;
		case 8:
			if (TimerAndPause.timesUp) next++;
			break;
		case 10:
			if (AEDStart.AEDStarted)
				next++;
			break;
		}
	}

	private void CheckIsplaying()
	{
		//checking in gaming step or explaining step,decide start counting time or not
		int remainder = next % 2;
		if ((remainder==1) || (next == 0)) //explaining step
		{
			TimerAndPause.playing = false;
		}
		else if (remainder==0 && next !=0)//gaming step
		{
			TimerAndPause.playing = true;
			//next++;  //enable for debug mode : checking step explanation or skip all gaming step
		}
	}

    void OnGUI()
    {
		int remainder = next % 2;

		if (next == 11) 
		{
			switch (language) 
			{
			case 1:
				GUI.Box(new Rect(400, 110, 500, 30), "恭喜通關！");
				GUI.Box(new Rect(400, 140, 500, 30), "複習：");
				GUI.Box(new Rect(400, 170, 500, 30), "步驟 1：開啟AED機");
				GUI.Box(new Rect(400, 200, 500, 30), "步驟 2：把AED機旁的貼片貼于左肩和右腰處");
				GUI.Box(new Rect(400, 230, 500, 30), "步驟 3：將插頭接上AED");
				GUI.Box(new Rect(400, 260, 500, 30), "步驟 4：等待AED機自動檢查患者的心律直至顯示完成");
				GUI.Box(new Rect(400, 290, 500, 30), "步驟 5：啟動AED機開始電擊");
				GUI.Box(new Rect(400, 320, 500, 30), "注意事項：");
				GUI.Box(new Rect(400, 350, 500, 30), "在進行第二步驟時確保先把患者的上衣脫掉");
				GUI.Box(new Rect(400, 380, 500, 30), "在第四步驟時千萬不要碰患者的身體");
				GUI.Box(new Rect(400, 410, 500, 30), "在嘗試進行任何急救之前，請先叫救護車。");
				if (GUI.Button(new Rect(400, 450, 100, 23), "下一關")) ;
				if (GUI.Button(new Rect(550, 450, 100, 23), "再一次")) Application.LoadLevel("AED");
				if (GUI.Button(new Rect(700, 450, 100, 23), "遊戲選單")) Application.LoadLevel("Menu");
				// if ((GUI.Button(new Rect(700, 400, 100, 23), "跳過")) || next == 3) Application.LoadLevel("AED");
				break;

			default:
				GUI.Box(new Rect(400, 110, 500, 30), "All Done！");
				GUI.Box(new Rect(400, 140, 500, 30), "Revision：");
				GUI.Box(new Rect(400, 170, 500, 30), "Step 1:Turn on the AED");
				GUI.Box(new Rect(400, 200, 500, 30), "Step 2:put the sticker beside the AED on the shoulder and waist");
				GUI.Box(new Rect(400, 230, 500, 30), "Step 3:Plug in the AED");
                GUI.Box(new Rect(400, 260, 500, 30), "Step 4:Wait the AED checking patient's heart rhythm automatic until it's done");
				GUI.Box(new Rect(400, 290, 500, 30), "Step 5:Start the AED");
				GUI.Box(new Rect(400, 320, 500, 30), "Notice:");
				GUI.Box(new Rect(400, 350, 500, 30), "Make sure cloth off before you start step 2.");
				GUI.Box(new Rect(400, 380, 500, 30), "Don't touche the body of patient on step 4.");
				GUI.Box(new Rect(400, 410, 500, 30), "You should call ambulance before you do anythings.");
				if (GUI.Button(new Rect(400, 450, 100, 23), "Next Level")) ;
				if (GUI.Button(new Rect(550, 450, 100, 23), "Again")) Application.LoadLevel("AED");
				if (GUI.Button(new Rect(700, 450, 100, 23), "Menu")) Application.LoadLevel("Menu");
				break;
			}
		}

		else if ((remainder == 1 && next!=11) || (next == 0)) //explaining step
		{ 
			GUI.Box (new Rect (400, 200, 500, 30), line1);
			GUI.Box (new Rect (400, 230, 500, 30), line2);
			GUI.Box (new Rect (400, 260, 500, 30), line3);
			GUI.Box (new Rect (400, 290, 500, 30), line4);
			if (GUI.Button (new Rect (600, 400, 100, 23), nextstep))
				next++;
		}

		else if (remainder==0 && next !=0)//gaming step
		{
			GUI.Box(new Rect(10, 80, 150, 23), line1);
			GUI.Box(new Rect(10, 110, 150, 23), line2);
			if (failed)
			{
				GUI.Box(new Rect(400, 200, 500, 30), line3);
				if (GUI.Button(new Rect(600, 400, 100, 23), line4)) next--;
			}
		}
    }
}
