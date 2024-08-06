using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRotScript : MonoBehaviour
{
    //Normal意外のBulletのRotationをどの向きに撃っても正しい向きにさせる

    public GameObject bulletObj;
    public Quaternion bulletRot;
    public float bulletRotZ;
    void Start()
    {

    }

    void Update()
    {
        //各テクスチャの親オブジェクトのRotationが(0,0,0,0)以外になった場合に発動
        //親オブジェクトのQuaternion値と逆の値にすることで元の向きに
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
