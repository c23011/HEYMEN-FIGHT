using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandmireAttackScript : MonoBehaviour
{
    public LandmireBulletScript landmireBulletSC;
    public int enemyPlayerID;
    public PlayerMove enemyPlayer;
    public float LandmireDamage;

    bool damageSW;

    void Start()
    {
        
    }

    void Update()
    {
        enemyPlayerID = landmireBulletSC.enemyPlayerID;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" + enemyPlayerID)
        {
            damageSW = true;

            enemyPlayer = other.gameObject.GetComponent<PlayerMove>();
            if (damageSW == true)
            {
                enemyPlayer.playerHP -= LandmireDamage;
                damageSW = false;
            }
        }
    }
}
