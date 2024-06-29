using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public float attackDamage;

    public PlayerMove myPlayer;
    public PlayerMove enemyPlayer;

    int myID;
    int enemyID;

    void Start()
    {
        myID = myPlayer.PlayerID;
        if (myID == 1)
        {
            enemyID = 2;
        }

        if (myID == 2)
        {
            enemyID = 1;
        }
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" + enemyID)
        {
            enemyPlayer = other.gameObject.GetComponent<PlayerMove>();
            if (enemyPlayer.GuardSW == false)
            {
                enemyPlayer.playerHP -= attackDamage;
            }
        }
    }
}
