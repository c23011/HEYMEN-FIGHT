using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonBulletScript : MonoBehaviour
{
    public Rigidbody2D bulletRG;
    public float BulletSpeed;
    [Header("�����l")]
    public float BulletSlipSpeed;
    public float BulletSlipSpeedParcent;
    bool slipSW;
    Vector3 stopPos;

    [Header("�U���̔���")]
    public GameObject poisonAttack;
    [Header("�����܂ł̎���")]
    public float poisonExplosionTime;
    [Header("���݂̌o�ߎ���")]
    float poisonNowTime;
    [Header("�Ŗ��̌p������")]
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
        PoisonBullet();
    }

    void PoisonBullet()
    {
        poisonNowTime += Time.deltaTime;
        if (poisonNowTime < poisonExplosionTime)
        {
            this.bulletRG.AddForce(transform.up * (BulletSpeed - (poisonNowTime * 5.0f)));
            slipSW = true;
        }
        if (poisonNowTime >= poisonExplosionTime)
        {
            if (slipSW == true)
            {
                BulletSlipSpeed /= BulletSlipSpeedParcent;
                this.bulletRG.AddForce(transform.up * -BulletSlipSpeed);
                stopPos = this.transform.position;
            }

            if (BulletSlipSpeed == 0)
            {
                slipSW = false;
                this.transform.position = stopPos;
                poisonAttack.SetActive(true);
                Destroy(this.gameObject, ActiveTime);
            }
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
