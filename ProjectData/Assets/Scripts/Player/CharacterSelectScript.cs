using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectScript : MonoBehaviour
{
    //キャラの種類一覧　→　[0]ノーマル[1]パワー[2]リーチ[3]スピード
    //銃の種類一覧　　　→　[0]ノーマル[1]ボム[2]地雷[3]毒

    [Header("キャラ")]
    public GameObject[] Character1P;
    public GameObject[] Character2P;

    [Header("銃の種類")]
    public GameObject[] GunType1P;
    public GameObject[] GunType2P;

    /*[Header("プレイヤー識別ID")]
    public int PlayerID1;
    public int PlayerID2;*/

    int NowCharacter1P;
    int NowCharacter2P;
    int NowGunType1P;
    int NowGunType2P;

    [Header("ここ触らないでね")]
    public int SelectedCharacter1;
    public int SelectedCharacter2;
    public int SelectedGunType1;
    public int SelectedGunType2;

    [SerializeField]
    bool CharacterSelectSW1;

    [SerializeField]
    bool CharacterSelectSW2;

    [SerializeField]
    bool GunSelectSW1;
    [SerializeField]
    bool GunSelectSW2;

    [SerializeField]
    bool goSW1;
    [SerializeField]
    bool goSW2;

    void Start()
    {
        CharacterSelectSW1 = true;
        GunSelectSW1 = false;
        CharacterSelectSW2 = true;
        GunSelectSW2 = false;

        NowCharacter1P = 0;
        NowCharacter2P = 0;
        NowGunType1P = 0;
        NowGunType2P = 0;

        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        CharacterSelect1();
        GunSelect1();
        CharacterSelect2();
        GunSelect2();

        if (goSW1 == true && goSW2 == true)
        {
            goSW1 = false;
            goSW2 = false;
            Invoke("GoMainScene", 1.0f);
        }
    }

    void CharacterSelect1()
    {
        if (CharacterSelectSW1 == true)
        {
            if (Input.GetButtonDown("L1Button1P"))
            {
                if (NowCharacter1P > 0)
                {
                    Character1P[NowCharacter1P].SetActive(false);
                    NowCharacter1P--;

                    Character1P[NowCharacter1P].SetActive(true);
                }
            }

            if (Input.GetButtonDown("R1Button1P"))
            {
                if (NowCharacter1P < 3)
                {
                    Character1P[NowCharacter1P].SetActive(false);
                    NowCharacter1P++;

                    Character1P[NowCharacter1P].SetActive(true);
                }
            }

            //キャラ決定
            if (Input.GetButtonDown("CircleButton1P"))
            {
                SelectedCharacter1 = NowCharacter1P;
                CharacterSelectSW1 = false;
                GunType1P[0].SetActive(true);
                //Debug.Log(SelectedCharacter1);

                Invoke("GunSelectSWtrue1", 0.1f);
            }
        }
    }

    void GunSelect1()
    {
        if (GunSelectSW1 == true)
        {
            if (Input.GetButtonDown("L1Button1P"))
            {
                if (NowGunType1P > 0)
                {
                    GunType1P[NowGunType1P].SetActive(false);
                    NowGunType1P--;
                    GunType1P[NowGunType1P].SetActive(true);
                }
            }

            if (Input.GetButtonDown("R1Button1P"))
            {
                if (NowGunType1P < 3)
                {
                    GunType1P[NowGunType1P].SetActive(false);
                    NowGunType1P++;

                    GunType1P[NowGunType1P].SetActive(true);
                }
            }

            //銃決定
            if (Input.GetButtonDown("CircleButton1P"))
            {
                SelectedGunType1 = NowGunType1P;
                GunSelectSW1 = false;
                //Debug.Log(SelectedGunType1);

                goSW1 = true;
            }
        }
    }

    void GunSelectSWtrue1()
    {
        GunSelectSW1 = true;
    }



    //---------------------------------------------------------------------

    void CharacterSelect2()
    {
        if (CharacterSelectSW2 == true)
        {
            if (Input.GetButtonDown("L1Button2P"))
            {
                if (NowCharacter2P > 0)
                {
                    Character2P[NowCharacter2P].SetActive(false);
                    NowCharacter2P--;

                    Character2P[NowCharacter2P].SetActive(true);
                }
            }

            if (Input.GetButtonDown("R1Button2P"))
            {
                if (NowCharacter2P < 3)
                {
                    Character2P[NowCharacter2P].SetActive(false);
                    NowCharacter2P++;

                    Character2P[NowCharacter2P].SetActive(true);
                }
            }

            //キャラ決定
            if (Input.GetButtonDown("CircleButton2P"))
            {
                SelectedCharacter2 = NowCharacter2P;
                CharacterSelectSW2 = false;
                GunType2P[0].SetActive(true);
                //Debug.Log(SelectedCharacter2);

                Invoke("GunSelectSWtrue2", 0.1f);
            }
        }
    }

    void GunSelect2()
    {
        if (GunSelectSW2 == true)
        {
            if (Input.GetButtonDown("L1Button2P"))
            {
                if (NowGunType2P > 0)
                {
                    GunType2P[NowGunType2P].SetActive(false);
                    NowGunType2P--;
                    GunType2P[NowGunType2P].SetActive(true);
                }
            }

            if (Input.GetButtonDown("R1Button2P"))
            {
                if (NowGunType2P < 3)
                {
                    GunType2P[NowGunType2P].SetActive(false);
                    NowGunType2P++;

                    GunType2P[NowGunType2P].SetActive(true);
                }
            }

            //銃決定
            if (Input.GetButtonDown("CircleButton2P"))
            {
                SelectedGunType2 = NowGunType2P;
                GunSelectSW2 = false;
                //Debug.Log(SelectedGunType2);

                goSW2 = true;
            }
        }
    }

    void GunSelectSWtrue2()
    {
        GunSelectSW2 = true;
    }

    void GoMainScene()
    {
        SceneManager.LoadScene("Main");
    }
}