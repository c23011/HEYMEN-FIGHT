using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickTest : MonoBehaviour
{
    float StickRot1;
    float StickRot2;
    float StickRot3;
    float StickRot4;

    void Start()
    {
        StickRot1 = 0;
        StickRot2 = 0;
        StickRot3 = 0;
        StickRot4 = 0;
    }

    void Update()
    {
        Stick();
        Debug.Log("左横" + StickRot1);
        Debug.Log("左縦" + StickRot2);
        Debug.Log("右横" + StickRot3);
        Debug.Log("右縦" + StickRot4);

        //transform.Translate()
    }

    void Stick()
    {
        // 左スティックのよこ方向の傾き
        StickRot1 = Input.GetAxisRaw("Horizontal");

        // 左スティックのたて方向の傾き
        StickRot2 = Input.GetAxisRaw("Vertical");

        // 右スティックのよこ方向の傾き
        StickRot3 = Input.GetAxisRaw("Horizontal2");

        // 右スティックのたて方向の傾き
        StickRot4 = Input.GetAxisRaw("Vertical2");
    }
}
