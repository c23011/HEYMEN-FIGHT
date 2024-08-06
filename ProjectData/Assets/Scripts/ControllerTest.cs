using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ControllerTest : MonoBehaviour
{
    float Hori;
    float Vert;

    int currentConnectionCount;
    string[] cName;

    void Start()
    {
        cName = Input.GetJoystickNames();
        for (int i = 0; i < cName.Length; i++)
        {
            if (cName[i] != "")
            {
                currentConnectionCount++;
                Debug.Log(cName[0]);
                Debug.Log(cName[1]);
            }
        }
    }
    void Update()
    {
        DownKeyCheck();
        StickCheck();
    }


    void DownKeyCheck()
    {
        if (Input.anyKeyDown)
        {
            foreach (KeyCode code in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(code))
                {
                    //����������
                    Debug.Log(code);
                    break;
                }
            }
        }
    }

    void StickCheck()
    {
        Hori = Input.GetAxis("Horizontal1");
        Vert = Input.GetAxis("Vertical1");

        float degree = Mathf.Atan2(Vert, Hori) * Mathf.Rad2Deg;

        if (degree < 0)
        {
            degree += 360;
        }

        Debug.Log(degree);
    }
}
