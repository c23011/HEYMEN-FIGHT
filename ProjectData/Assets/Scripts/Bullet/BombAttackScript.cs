using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAttackScript : MonoBehaviour
{
    public BombBulletScript bombBulletSC;
    public int enemyPlayerID;
    public PlayerMove enemyPlayer;
    public float bombDamage;

    bool damageSW;

    void Start()
    {
        
    }

    void Update()
    {
        enemyPlayerID = bombBulletSC.enemyPlayerID;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" + enemyPlayerID)
        {
            damageSW = true;

            enemyPlayer = other.gameObject.GetComponent<PlayerMove>();
            if (damageSW == true)
            {
                enemyPlayer.playerHP -= bombDamage;
                damageSW = false;
            }
        }
    }
}
