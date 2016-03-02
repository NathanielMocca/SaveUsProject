using UnityEngine;
using System.Collections;

public class AEDOnOff : MonoBehaviour {

    
    public bool OnOff = false;
    public bool NowOff = true;
    // Use this for initialization
    void Start ()
    {
    }
	
	// Update is called once per frame
	void Update () {
       
        TextMesh OnOfftext = GameObject.Find("OnOffText").GetComponent<TextMesh>();
       // TextMesh Volumetext = GameObject.Find("VolumeText").GetComponent<TextMesh>();
        if (OnOff)
        {
            NowOff = false;
            OnOfftext.text = "On";
        }
        else
        {
            NowOff = true;
            OnOfftext.text = "Off";
          
        }
        
    }

}
