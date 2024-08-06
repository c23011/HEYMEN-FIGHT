using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInstantiateScript : MonoBehaviour
{
    public GameObject[] Character;

    public GameObject CharaSelecter;
    public CharacterSelectScript charaSelScript;

    public PlayerMove playerMoveScript1P;
    public PlayerMove playerMoveScript2P;
    public int playerID1P;
    public int playerID2P;

    bool instSW;

    public GameObject player1;
    public GameObject player2;

    public float MaxHp1P;
    public float MaxHp2P;
    public float NowHp1P;
    public float NowHp2P;
    public int chara1;
    public int chara2;

    public float MaxAttackCDtime1P;
    public float MaxAttackCDtime2P;

    public float MaxShotCDtime1P;
    public float MaxShotCDtime2P;

    bool LoadSW;
    public GameObject HpController;

    float player1pX;
    float player2pX;
    bool swapSW;

    void Start()
    {

    }

    void Update()
    {
        if (instSW == true)
        {
            Player1();
            Player2();

            instSW = false;
            LoadSW = true;
            swapSW = true;
        }

        if (LoadSW == true)
        {
            NowHp1P = playerMoveScript1P.playerHP;
            NowHp2P = playerMoveScript2P.playerHP;

            MaxAttackCDtime1P = playerMoveScript1P.attackCoolDownTime;
            MaxAttackCDtime2P = playerMoveScript2P.attackCoolDownTime;

            MaxShotCDtime1P = playerMoveScript1P.shotScript.bulletShotCDTime;
            MaxShotCDtime2P = playerMoveScript2P.shotScript.bulletShotCDTime;
        }

        if (swapSW == true)
        {
            CharacterSwap();
        }
    }

    //Select画面で選択したキャラと特殊攻撃の読み取り
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "CharacterSel")
        {
            CharaSelecter = other.gameObject;
            charaSelScript = other.GetComponent<CharacterSelectScript>();

            instSW = true;
            HpController.SetActive(true);
        }
    }

    //1PのPlayer生成とパラメータ割り当て
    public void Player1()
    {
        chara1 = charaSelScript.SelectedCharacter1;
        int gun1 = charaSelScript.SelectedGunType1;
        
        player1 = Instantiate(Character[chara1],new Vector3(-6.0f,0.75f,0.0f),Quaternion.identity);
        playerMoveScript1P = player1.GetComponent<PlayerMove>();
        playerMoveScript1P.PlayerID = playerID1P;
        playerMoveScript1P.characterCustom = chara1;
        playerMoveScript1P.gunTypeCustom = gun1;
        MaxHp1P = playerMoveScript1P.playerHP;
    }

    //2PのPlayer生成とパラメータ割り当て
    public void Player2()
    {
        chara2 = charaSelScript.SelectedCharacter2;
        int gun2 = charaSelScript.SelectedGunType2;

        player2 = Instantiate(Character[chara2],new Vector3(6.0f,0.75f,0.0f),Quaternion.identity);
        playerMoveScript2P = player2.GetComponent<PlayerMove>();
        playerMoveScript2P.PlayerID = playerID2P;
        playerMoveScript2P.characterCustom = chara2;
        playerMoveScript2P.gunTypeCustom = gun2;
        MaxHp2P = playerMoveScript2P.playerHP;
    }

    //1Pと2Pがすれ違った際に向きを反転させる
    void CharacterSwap()
    {
        player1pX = player1.transform.position.x;
        player2pX = player2.transform.position.x;

        if (player1pX <= player2pX)
        {
            player1.transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
        }

        if (player1pX >= player2pX)
        {
            player1.transform.rotation = new Quaternion(0.0f, 180.0f, 0.0f, 0.0f);
        }

        if (player2pX <= player1pX)
        {
            player2.transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
        }

        if (player2pX >= player1pX)
        {
            player2.transform.rotation = new Quaternion(0.0f, 180.0f, 0.0f, 0.0f);
        }
    }
}
