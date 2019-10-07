using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveobstacle : MonoBehaviour
{
    public float speed = 100f;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);     
        if(transform.position.x < -700) 
            Destroy(gameObject);  
    }
}
