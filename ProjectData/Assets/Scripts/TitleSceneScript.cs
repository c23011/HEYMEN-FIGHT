using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneScript : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.JoystickButton2) || Input.GetKey(KeyCode.JoystickButton9))
        {
            SceneManager.LoadScene("CharaSelect");
        }
    }
}
