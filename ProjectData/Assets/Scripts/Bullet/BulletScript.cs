using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Rigidbody2D bulletRG;
    [Header("弾速")]
    public float BulletSpeed = 0.0f;
    [Header("銃タイプの指定")]
    public int bulletID;

    public float ActiveTime;

    bool BulletSW;

    public PlayerMove myPlayer;
    public PlayerMove enemyPlayer;

    bool myIDGetSW;
    int myPlayerID;
    int enemyPlayerID;

    void Start()
    {
        myIDGetSW = true;
        if (bulletID == 0)
        {
            NormalBullet();
        }
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //自機がどっちのプレイヤーか取得
        if (myIDGetSW == true)
        {
            myPlayer = other.GetComponent<PlayerMove>();
            myPlayerID = myPlayer.PlayerID;
            myIDGetSW = false;
        }

        if (myPlayerID == 1)
        {
            enemyPlayerID = 2;
        }

        if(myPlayerID == 2)
        {
            enemyPlayerID = 1;
        }

        if (other.gameObject.tag == "Player" + enemyPlayerID)
        {
            BulletSW = true;

            if (myIDGetSW == false)
            {
                enemyPlayer = other.GetComponent<PlayerMove>();
                enemyPlayer.playerHP = enemyPlayer.playerHP - 1;
                Destroy(this.gameObject, ActiveTime);
            }

            if (BulletSW == true)
            {
                BulletSW = false;
            }
        }
    }

    void NormalBullet()
    {
        this.bulletRG.AddForce(transform.up * BulletSpeed);
        Destroy(this.gameObject, 2.0f);
    }
}
