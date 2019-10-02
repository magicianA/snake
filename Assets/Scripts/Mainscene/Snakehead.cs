using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snakehead : MonoBehaviour
{
    private float speed = 1f;
    void Start()
    {
         
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            this.transform.position += Vector3.right;
        }
    }

}
