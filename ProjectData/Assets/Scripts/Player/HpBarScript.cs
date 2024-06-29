using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBarScript : MonoBehaviour
{
    public Slider HpBar1;
    public Slider HpBar2;

    public float NowHp1P;
    public float NowHp2P;
    public float MaxHp1P;
    public float MaxHp2P;

    //プレイヤーをInstantiateしてるスクリプトから簡易的にHPを参照
    public PlayerInstantiateScript playerInstScript;

    bool NowHpSW;
    void Start()
    {
        
    }

    void Update()
    {
        //現在のHPをsliderで可視化

        NowHp1P = playerInstScript.NowHp1P;
        NowHp2P = playerInstScript.NowHp2P;

        MaxHp1P = playerInstScript.MaxHp1P;
        MaxHp2P = playerInstScript.MaxHp2P;

        HpBar1.maxValue = MaxHp1P;
        HpBar2.maxValue = MaxHp2P;
        HpBar1.value = NowHp1P;
        HpBar2.value = NowHp2P;
    }
}
