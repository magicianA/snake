using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockmove : MonoBehaviour
{
    public float speed = 100f;
    public int damage = 0;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);     
        if(transform.position.x < -230) 
            Destroy(gameObject);  
    }
}
