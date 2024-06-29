using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandmireBulletScript : MonoBehaviour
{
    public GameObject LandmireAttack;
    [Header("爆発までの時間")]
    public float LandmireExplosionTime;
    [Header("現在の経過時間")]
    float LandmireNowTime;
    [Header("爆発の継続時間")]
    public float ActiveTime;

    public PlayerMove myPlayer;
    public PlayerMove enemyPlayer;

    bool myIDGetSW;
    public int myPlayerID;
    public int enemyPlayerID;

    bool StartTimerSW;

    void Start()
    {
        myIDGetSW = true;
    }

    void Update()
    {
        LandmireBulletAttack();
    }

    void LandmireBulletAttack()
    {
        if (StartTimerSW == true)
        {
            LandmireNowTime += Time.deltaTime;
        }

        if (LandmireNowTime >= LandmireExplosionTime)
        {
            LandmireAttack.SetActive(true);
            Destroy(this.gameObject, ActiveTime);
        }
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

        if (myPlayerID == 2)
        {
            enemyPlayerID = 1;
        }

        if (other.tag == "Player" + enemyPlayerID)
        {
            StartTimerSW = true;
        }
    }
}
