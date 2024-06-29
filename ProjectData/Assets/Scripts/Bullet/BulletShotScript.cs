using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShotScript : MonoBehaviour
{
    public GameObject[] BulletPrefab;
    public int BulletID;

    public PlayerMove playerMoveSC;
    public bool bulletShot;
    public float bulletShotCDTime;

    void Start()
    {
        BulletID = playerMoveSC.gunTypeCustom;
        bulletShot = true;
    }

    void Update()
    {
        PlayerShot();
    }

    void PlayerShot()
    {
        if (Input.GetButtonDown("R1Button" + playerMoveSC.PlayerID + "P"))
        {
            if (playerMoveSC.moveSW == true)
            {
                if (bulletShot == true)
                {
                    if (BulletID == 0)
                    {
                        Instantiate(BulletPrefab[BulletID], this.transform.position, this.transform.rotation);
                        bulletShot = false;

                        Invoke("ShotCoolDown", bulletShotCDTime);
                    }

                    if (BulletID != 0)
                    {
                        Instantiate(BulletPrefab[BulletID], this.transform.position, this.transform.rotation/*Quaternion.identity*/);
                        bulletShot = false;

                        Invoke("ShotCoolDown", bulletShotCDTime);
                    }
                }
            }
        }
    }

    void ShotCoolDown()
    {
        bulletShot = true;
    }
}
