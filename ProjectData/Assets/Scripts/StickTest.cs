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
        Debug.Log("����" + StickRot1);
        Debug.Log("���c" + StickRot2);
        Debug.Log("�E��" + StickRot3);
        Debug.Log("�E�c" + StickRot4);

        //transform.Translate()
    }

    void Stick()
    {
        // ���X�e�B�b�N�̂悱�����̌X��
        StickRot1 = Input.GetAxisRaw("Horizontal");

        // ���X�e�B�b�N�̂��ĕ����̌X��
        StickRot2 = Input.GetAxisRaw("Vertical");

        // �E�X�e�B�b�N�̂悱�����̌X��
        StickRot3 = Input.GetAxisRaw("Horizontal2");

        // �E�X�e�B�b�N�̂��ĕ����̌X��
        StickRot4 = Input.GetAxisRaw("Vertical2");
    }
}
