using UnityEngine;
using System.Collections;

public class PositionPreset : MonoBehaviour {

    private Vector3 WaistPosition, ShoulderPosition, SocketPosition;

    void Start()
    {//取得各物件初始位置
        GameObject waistSticker = GameObject.Find("WaistSticker");
        GameObject shoulderSticker = GameObject.Find("ShoulderSticker");
        GameObject Socket = GameObject.Find("Socket");
        WaistPosition = waistSticker.transform.localPosition;
        ShoulderPosition = shoulderSticker.transform.localPosition;
        SocketPosition = Socket.transform.localPosition;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == GameObject.Find("WaistSticker"))
        {
            Debug.Log("WaistStickerOutOfRange");
            collision.transform.localPosition = WaistPosition; //back to preset position

        }
        if (collision.gameObject == GameObject.Find("ShoulderSticker"))
        {
            Debug.Log("SholderStickerOutOfRange");
            collision.transform.localPosition = ShoulderPosition; //back to preset position
        }
        if (collision.gameObject == GameObject.Find("Socket"))
        {
            Debug.Log("SocketOutOfRange");
            collision.transform.localPosition = SocketPosition; //back to preset position
        }
    }
}
