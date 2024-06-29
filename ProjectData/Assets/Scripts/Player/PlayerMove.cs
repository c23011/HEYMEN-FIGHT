using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float playerHP;

    [Header("プレイヤー速度")]
    public float playerSpeed;     //プレイヤー速度

    [Header("プレイヤー識別ID")]
    public int PlayerID;
    [Header("プレイヤーのキャラ")]
    public int characterCustom;
    [Header("プレイヤーの銃種")]
    public int gunTypeCustom;
    [Header("プレイヤーのコライダー")]
    public Collider2D playerCol;
    [Header("プレイヤーについているAimオブジェクト")]
    public BulletShotScript shotScript;

    float playerx;
    float playery;
    float LeftStickHoli;
    float LeftStickVert;



    [Header("各プレイヤーの攻撃判定")]
    public GameObject NormalAttack;
    public float attackEndTime;
    public float attackCoolDownTime;
    public float nowAttackCDTime;

    public bool AttackSW;
    public bool AttackCdCountSW;
    public bool ShotCdCountSW;
    public bool GuardSW;
    public bool moveSW;

    void Start()
    {
        AttackSW = true;
        moveSW = true;

    }
    void Update()
    {
        if (PlayerID == 1)
        {
            PlayerMoves1();
            PlayerAttack1();
            Guard1P();
            this.gameObject.tag = "Player1";
        }

        if (PlayerID == 2)
        {
            PlayerMoves2();
            PlayerAttack2();
            Guard2P();
            this.gameObject.tag = "Player2";
        }

        if (this.transform.position.x <= -8.0f)
        {
            this.transform.position = new Vector3(-7.9f,this.transform.position.y, this.transform.position.z);
        }

        if (this.transform.position.x >= 8.0f)
        {
            this.transform.position = new Vector3(7.9f, this.transform.position.y, this.transform.position.z);
        }

        if (this.transform.position.y >= 1.5f)
        {
            this.transform.position = new Vector3(this.transform.position.x, 1.4f, this.transform.position.z);
        }

        if (this.transform.position.y <= -4.0f)
        {
            this.transform.position = new Vector3(this.transform.position.x, -3.9f, this.transform.position.z);
        }

        ShotCdCountSW = shotScript.bulletShot;
    }

    //1P
    void PlayerMoves1()
    {
        if (moveSW == true)
        {
            LeftStickHoli = Input.GetAxis("LeftStick1PHorizontal");
            LeftStickVert = Input.GetAxis("LeftStick1PVertical");

            playerx = this.transform.position.x;
            playery = this.transform.position.y;

            //スティックの傾きがちょっとしかない時はスティック入力されていないことにする
            if (LeftStickHoli <= 0.2f && LeftStickHoli >= -0.2f)
            {
                LeftStickHoli = 0.0f;
            }

            if (LeftStickVert <= 0.2f && LeftStickVert >= -0.2f)
            {
                LeftStickVert = 0.0f;
            }

            if (LeftStickHoli != 0.0f || LeftStickVert != 0.0f)
            {
                this.transform.position = new Vector3(playerx + (LeftStickHoli * playerSpeed), playery + (LeftStickVert * -playerSpeed), this.transform.position.z);
            }
        }
    }

    void PlayerAttack1()
    {
        if (Input.GetButtonDown("CircleButton1P"))
        {
            if (moveSW == true)
            {
                if (AttackSW == true)
                {
                    moveSW = false;
                    NormalAttack.SetActive(true);
                    AttackCdCountSW = true;
                    Invoke("AttackEnd", attackEndTime);
                    Invoke("AttackSWtrue",attackCoolDownTime);
                    AttackSW = false;
                }
            }
        }
    }

    //---------------------------------------------------------------------------------------------------------
    //---------------------------------------------------------------------------------------------------------
    //---------------------------------------------------------------------------------------------------------

    //2P
    void PlayerMoves2()
    {
        if (moveSW == true)
        {
            LeftStickHoli = Input.GetAxis("LeftStick2PHorizontal");
            LeftStickVert = Input.GetAxis("LeftStick2PVertical");

            playerx = this.transform.position.x;
            playery = this.transform.position.y;

            //スティックの傾きがちょっとしかない時はスティック入力されていないことにする
            if (LeftStickHoli <= 0.2f && LeftStickHoli >= -0.2f)
            {
                LeftStickHoli = 0.0f;
            }

            if (LeftStickVert <= 0.2f && LeftStickVert >= -0.2f)
            {
                LeftStickVert = 0.0f;
            }

            if (LeftStickHoli != 0.0f || LeftStickVert != 0.0f)
            {
                this.transform.position = new Vector3(playerx + (LeftStickHoli * playerSpeed), playery + (LeftStickVert * -playerSpeed), this.transform.position.z);
            }
        }
    }



    void PlayerAttack2()
    {
        if (Input.GetButtonDown("CircleButton2P"))
        {
            if (moveSW == true)
            {
                if (AttackSW == true)
                {
                    moveSW = false;
                    NormalAttack.SetActive(true);
                    AttackCdCountSW = true;
                    Invoke("AttackEnd", attackEndTime);
                    Invoke("AttackSWtrue", attackCoolDownTime);
                    AttackSW = false;
                }
            }
        }
    }

    void AttackEnd()
    {
        NormalAttack.SetActive(false);
        moveSW = true;
    }

    void AttackSWtrue()
    {
        AttackSW = true;
        AttackCdCountSW = false;
    }

    public void PlayerCustom(int character , int gunType)
    {
        characterCustom = character;
        gunTypeCustom = gunType;
    }

    void Guard1P()
    {
        if (Input.GetButtonDown("L1Button1P"))
        {
            moveSW = false;
            GuardSW = true;
            Debug.Log("1Pガード中！");
        }

        if (Input.GetButtonUp("L1Button1P"))
        {
            moveSW = true;
            GuardSW = false;
            Debug.Log("1Pガード解除！");
        }
    }

    void Guard2P()
    {
        if (Input.GetButtonDown("L1Button2P"))
        {
            moveSW = false;
            GuardSW = true;
            Debug.Log("2Pガード中！");
        }

        if (Input.GetButtonUp("L1Button2P"))
        {
            moveSW = true;
            GuardSW = false;
            Debug.Log("2Pガード解除！");
        }
    }
}