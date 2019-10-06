using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class start : MonoBehaviour
{

    public Sprite btnimage;
    public GameObject btn;
    public void startgame()
    {
        SceneManager.LoadScene("modeselect");
    }

}
