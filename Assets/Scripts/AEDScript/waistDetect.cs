using UnityEngine;
using System.Collections;

public class waistDetect : MonoBehaviour {
    public static bool WaistDetected = false;
    void Start()
    {
        WaistDetected = false;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == GameObject.Find("WaistSticker"))
        {
            WaistDetected = true;
            Debug.Log("touchwaist");
            collision.transform.parent = this.gameObject.transform;
            Rigidbody rigid = collision.gameObject.GetComponent<Rigidbody>();
            rigid.constraints = RigidbodyConstraints.FreezeAll;            
        }
    }
}
