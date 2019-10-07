using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{
    public GameObject menu;
    public void OnPause()
    {
        Time.timeScale = 0;
        menu.SetActive(true);
    }

    public void OnResume()
    {
        Time.timeScale = 1f;
        menu.SetActive(false);
    }
    public void Onexit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("gamestart");
    }

}