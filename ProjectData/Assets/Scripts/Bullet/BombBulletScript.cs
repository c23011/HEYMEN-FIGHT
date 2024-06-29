using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBulletScript : MonoBehaviour
{
    public Rigidbody2D bulletRG;
    public float BulletSpeed;

    public GameObject bombAttack;
    [Header("�����܂ł̎���")]
    public float bombExplosionTime;
    [Header("���݂̌o�ߎ���")]
    float bombNowTime;
    [Header("�����̌p������")]
    public float ActiveTime;

    public PlayerMove myPlayer;
    public PlayerMove enemyPlayer;

    bool myIDGetSW;
    public int myPlayerID;
    public int enemyPlayerID;

    void Start()
    {
        myIDGetSW = true;
    }

    void Update()
    {
        BombBullet();
    }

    void BombBullet()
    {
        bombNowTime += Time.deltaTime;
        if (bombNowTime < bombExplosionTime)
        {
            this.bulletRG.AddForce(transform.up * (BulletSpeed - (bombNowTime * 5.0f)));
        }

        if (bombNowTime >= bombExplosionTime)
        {
            this.bulletRG.AddForce(transform.up * -1.0f);
            bombAttack.SetActive(true);
            Destroy(this.gameObject, ActiveTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //���@���ǂ����̃v���C���[���擾
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
    }
}
