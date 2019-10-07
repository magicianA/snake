using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class musicsetting : MonoBehaviour
{

    public Slider slider;
    public AudioSource s;
    void Awake()
    {
        s = GetComponent<AudioSource>();
    }    
    void Update()
    {
        s.volume = slider.value;
    }
}

