using UnityEngine;
using System.Collections;

public class shoulderDetect : MonoBehaviour {

    public static bool ShoulderDetected = false;

    void Start()
    {
        ShoulderDetected = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == GameObject.Find("ShoulderSticker"))
        {
            ShoulderDetected = true;
            Debug.Log("touchShoulder");
            collision.transform.parent = this.gameObject.transform;
            Rigidbody rigid = collision.gameObject.GetComponent<Rigidbody>();
            rigid.constraints = RigidbodyConstraints.FreezeAll;
        }
    }
}
