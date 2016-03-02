using UnityEngine;
using System.Collections;

public class AEDVolume : MonoBehaviour {

    public int Volume = 5;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        TextMesh AEDtext = GameObject.Find("AEDText").GetComponent<TextMesh>();
        TextMesh OnOfftext = GameObject.Find("OnOffText").GetComponent<TextMesh>();
         TextMesh Volumetext = GameObject.Find("VolumeText").GetComponent<TextMesh>();
         GameObject AEDonoff = GameObject.Find("OnOffText");
        AEDOnOff onoff = AEDonoff.GetComponent<AEDOnOff>();
        if (onoff.NowOff==false)
        {
            if (Volume >= 10)
             {
                 Volumetext.text = "Volume:Max";
                 Volume = 10;
             }
             else if(Volume<=0)
             {
                 Volumetext.text = "Volume:Silent";
                 Volume = 0;
             }
             else
             {
                 Volumetext.text = "Volume:"+Volume;
             }

        }
        else
        {
            Volumetext.text = "";
        }
        
    }
}
