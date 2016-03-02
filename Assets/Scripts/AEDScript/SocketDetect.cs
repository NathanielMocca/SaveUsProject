using UnityEngine;
using System.Collections;

public class SocketDetect : MonoBehaviour {
    public static bool SocketDetected = false;
    void Start()
    {
        SocketDetected = false;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == GameObject.Find("Socket"))
        {
            SocketDetected = true;
            Debug.Log("touchSocket");
            collision.transform.parent = this.gameObject.transform;
            Rigidbody rigid = collision.gameObject.GetComponent<Rigidbody>();
            rigid.constraints = RigidbodyConstraints.FreezeAll;
        }
    }
}
