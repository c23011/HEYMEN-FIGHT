using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MeterUIChangerScript : MonoBehaviour
{
    public PlayerInstantiateScript playerInstSC;
    int player1pCharacter;
    int player2pCharacter;

    public GameObject[] player1pObj;
    public GameObject[] player2pObj;

    bool loadSW;

    void Start()
    {
        Invoke("LoadSW", 0.2f);
    }

    void Update()
    {
        if (loadSW == true)
        {
            player1pCharacter = playerInstSC.chara1;
            player2pCharacter = playerInstSC.chara2;

            player1pObj[player1pCharacter].SetActive(true);
            player2pObj[player2pCharacter].SetActive(true);

            loadSW = false;
        }

    }

    void LoadSW()
    {
        loadSW = true;
    }
}
