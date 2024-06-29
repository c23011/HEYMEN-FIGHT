using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonAttackScript : MonoBehaviour
{
    public PoisonBulletScript poisonBulletSC;
    public int enemyPlayerID;
    public PlayerMove enemyPlayer;
    public float bombDamage;

    bool damageSW;
    bool AreaSW;

    void Start()
    {

    }

    void Update()
    {
        enemyPlayerID = poisonBulletSC.enemyPlayerID;
        SlipDamage();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" + enemyPlayerID)
        {
            damageSW = true;
            AreaSW = true;

            enemyPlayer = other.gameObject.GetComponent<PlayerMove>();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" + enemyPlayerID)
        {
            damageSW = false;
            AreaSW = false;

        }
    }

    void DamageSWtrue()
    {
        damageSW = true;
    }

    void SlipDamage()
    {
        if (damageSW == true)
        {
            if (AreaSW == true)
            {
                enemyPlayer.playerHP -= bombDamage;
                damageSW = false;
                Invoke("DamageSWtrue", 1.0f);
            }
        }
    }
}
