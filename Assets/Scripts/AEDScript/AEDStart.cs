using UnityEngine;
using System.Collections;

public class AEDStart : MonoBehaviour {

    public bool startbutton = false;
    public static bool AEDStarted = false;
    // Use this for initialization
    void Start()
    {
        AEDStarted = false; 
        TextMesh AEDtext = GameObject.Find("AEDText").GetComponent<TextMesh>();
        AEDtext.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        TextMesh AEDtext = GameObject.Find("AEDText").GetComponent<TextMesh>();
        GameObject AEDonoff = GameObject.Find("OnOffText");
        AEDOnOff onoff = AEDonoff.GetComponent<AEDOnOff>();
        if (startbutton & onoff.NowOff==false)
        {
            AEDStarted = true;
             AEDtext.text = "Start";
        }
        else
        {
            AEDStarted = false;
            AEDtext.text = "";
        }

    }
}
