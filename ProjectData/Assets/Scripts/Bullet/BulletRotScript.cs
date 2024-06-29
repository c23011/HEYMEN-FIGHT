using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRotScript : MonoBehaviour
{
    public GameObject bulletObj;
    public Quaternion bulletRot;
    public float bulletRotZ;
    void Start()
    {

    }

    void Update()
    {
        bulletRot = bulletObj.transform.rotation;

        if (bulletRot.x != 0.0f)
        {
            this.gameObject.transform.rotation = new Quaternion(0.0f, 0.0f, -bulletRot.x, 0);
        }

        if (bulletRot.z != 0.0f)
        {
            this.gameObject.transform.rotation = new Quaternion(0.0f, 0.0f, -bulletRot.z, 0);
        }
    }
}
