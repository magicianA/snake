using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setting : MonoBehaviour
{
    public GameObject menu;
    public void control()
    {
        menu.SetActive(true);
    }
    public void closecontrol()
    {
        menu.SetActive(false);
    }
}
