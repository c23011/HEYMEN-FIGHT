using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotScript : MonoBehaviour
{
    public PlayerMove playerMove;

    [Header("�v���C���[��]���x")]
    public float playerRotSpeed;  //�v���C���[��]���x

    [SerializeField]
    float playerAngleX;
    [SerializeField]
    float playerAngleY;

    void Start()
    {
        
    }

    void Update()
    {
        if (playerMove.PlayerID == 1)
        {
            PlayerAngle1();
        }

        if (playerMove.PlayerID == 2)
        {
            PlayerAngle2();
        }

    }

    void PlayerAngle1()
    {
        if (playerMove.moveSW == true)
        {
            playerAngleX = Input.GetAxisRaw("RightStick1PHorizontal");
            //playerAngleY = Input.GetAxis("RightStick1PVertical");

            //�X�e�B�b�N�̌X����������Ƃ����Ȃ����̓X�e�B�b�N���͂���Ă��Ȃ����Ƃɂ���

            if (playerAngleX <= 0.2f && playerAngleX >= 0.2f)
            {
                playerAngleX = 0.0f;
            }
            
            transform.Rotate(new Vector3(0, 0, playerAngleX * playerRotSpeed));
        }
    }

    void PlayerAngle2()
    {
        if (playerMove.moveSW == true)
        {
            playerAngleX = Input.GetAxisRaw("RightStick2PHorizontal");
            //playerAngleY = Input.GetAxis("RightStick2PVertical");

            //�X�e�B�b�N�̌X����������Ƃ����Ȃ����̓X�e�B�b�N���͂���Ă��Ȃ����Ƃɂ���
            if (playerAngleX <= 0.2f && playerAngleX >= 0.2f)
            {
                playerAngleX = 0.0f;
            }
            
            transform.Rotate(new Vector3(0, 0,playerAngleX * playerRotSpeed));
        }
    }
}
