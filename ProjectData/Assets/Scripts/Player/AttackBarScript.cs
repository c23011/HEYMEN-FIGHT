using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackBarScript : MonoBehaviour
{
    //Attackのクールタイムは各Attackオブジェクトから
    //PlayerMoveに読み込ませ、そのPlayerMoveを
    //PlayerInsterが読み込ませるようにしている
    //Shotも同様
    public Slider attackBar1P;
    public Slider attackBar2P;

    public Slider shotBar1P;
    public Slider shotBar2P;

    public float nowAttackCDTime1P;
    public float nowAttackCDTime2P;
    public float maxAttackCDTime1P;
    public float maxAttackCDTime2P;

    public float nowShotCDTime1P;
    public float nowShotCDTime2P;
    public float maxShotCDTime1P;
    public float maxShotCDTime2P;

    //プレイヤーをInstantiateしてるスクリプトから簡易的にAttackのクールダウンを参照
    public PlayerInstantiateScript playerInstScript;

    bool atCountSW1P;
    bool atCountSW2P;

    bool stCountSW1P;
    bool stCountSW2P;

    bool StartSW;

    //playerMove.attackCoolDownTime
    void Start()
    {
        Invoke("StartMeter", 1.0f);
    }

    void Update()
    {
        if (StartSW == true)
        {
            AttackMeter();
            ShotMeter();
        }
    }

    void StartMeter()
    {
        StartSW = true;
    }

    void AttackMeter()
    {
        //現在のクールダウンタイムをsliderで可視化
        maxAttackCDTime1P = playerInstScript.MaxAttackCDtime1P;
        maxAttackCDTime2P = playerInstScript.MaxAttackCDtime2P;
        attackBar1P.maxValue = maxAttackCDTime1P;
        attackBar2P.maxValue = maxAttackCDTime2P;

        if (playerInstScript.playerMoveScript1P.AttackCdCountSW == true && atCountSW1P == false)
        {
            atCountSW1P = true;
            nowAttackCDTime1P = 0.0f;
            Invoke("AtCoolDown1P", maxAttackCDTime1P);
        }

        if (nowAttackCDTime1P < maxAttackCDTime1P)
        {
            nowAttackCDTime1P += Time.deltaTime;
        }

        if (nowAttackCDTime1P >= maxAttackCDTime1P)
        {
            nowAttackCDTime1P = maxAttackCDTime1P;
        }

        attackBar1P.value = nowAttackCDTime1P;


        //--------------------------------------------------------------------------------------
        if (playerInstScript.playerMoveScript2P.AttackCdCountSW == true && atCountSW2P == false)
        {
            nowAttackCDTime2P = 0.0f;
            atCountSW2P = true;
            Invoke("AtCoolDown2P", maxAttackCDTime2P);
        }

        if (nowAttackCDTime2P < maxAttackCDTime2P)
        {
            nowAttackCDTime2P += Time.deltaTime;
        }

        if (nowAttackCDTime2P >= maxAttackCDTime2P)
        {
            nowAttackCDTime2P = maxAttackCDTime2P;
        }

        attackBar2P.value = nowAttackCDTime2P;

    }

    void ShotMeter()
    {
        //現在のクールダウンタイムをsliderで可視化
        maxShotCDTime1P = playerInstScript.MaxShotCDtime1P;
        maxShotCDTime2P = playerInstScript.MaxShotCDtime2P;
        shotBar1P.maxValue = maxShotCDTime1P;
        shotBar2P.maxValue = maxShotCDTime2P;

        if (playerInstScript.playerMoveScript1P.ShotCdCountSW == false && stCountSW1P == false)
        {
            stCountSW1P = true;
            nowShotCDTime1P = 0.0f;
            Invoke("StCoolDown1P", maxShotCDTime1P + 0.1f);
        }

        if (nowShotCDTime1P < maxShotCDTime1P)
        {
            nowShotCDTime1P += Time.deltaTime;
        }

        if (nowShotCDTime1P >= maxShotCDTime1P)
        {
            nowShotCDTime1P = maxShotCDTime1P;
        }

        shotBar1P.value = nowShotCDTime1P;


        //--------------------------------------------------------------------------------------
        if (playerInstScript.playerMoveScript2P.ShotCdCountSW == false && stCountSW2P == false)
        {
            stCountSW2P = true;
            nowShotCDTime2P = 0.0f;
            Invoke("StCoolDown2P", maxShotCDTime2P + 0.1f);
        }

        if (nowShotCDTime2P < maxShotCDTime2P)
        {
            nowShotCDTime2P += Time.deltaTime;
        }

        if (nowShotCDTime2P >= maxShotCDTime2P)
        {
            nowShotCDTime2P = maxShotCDTime2P;
        }
        
        shotBar2P.value = nowShotCDTime2P;

    }

    void AtCoolDown1P()
    {
        atCountSW1P = false;
    }

    void AtCoolDown2P()
    {
        atCountSW2P = false;
    }

    void StCoolDown1P()
    {
        stCountSW1P = false;
    }

    void StCoolDown2P()
    {
        stCountSW2P = false;
    }
}
