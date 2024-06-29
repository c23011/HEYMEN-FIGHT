using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneResultScript : MonoBehaviour
{
    public PlayerInstantiateScript playerInstScript;

    public GameObject winObj;

    public GameObject result1P;
    public GameObject result2P;

    bool resultSW;
    void Start()
    {
        
    }

    void Update()
    {
        Invoke("Result", 1.0f);
    }

    void Result()
    {
        if (playerInstScript.NowHp1P <= 0 && resultSW == false)
        {
            winObj.SetActive(true);
            result2P.SetActive(true);
            resultSW = true;
        }

        if (playerInstScript.NowHp2P <= 0 && resultSW == false)
        {
            winObj.SetActive(true);
            result1P.SetActive(true);
            resultSW = true;
        }

        if (resultSW == true)
        {
            if (Input.GetButtonDown("CircleButton1P") || Input.GetButtonDown("CircleButton2P"))
            {
                SceneManager.LoadScene("CharaSelect");
            }
        }
    }
}
