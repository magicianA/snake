using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movebody4 : MonoBehaviour
{
    public float speed = 100f;
    GameObject target;
    void Start()
    {
        target = GameObject.Find("snakehead");
        GetComponent<SpriteRenderer>().color  = target.GetComponent<SpriteRenderer>().color;
    }

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);     
        if(transform.position.x < -400) 
            Destroy(gameObject);  
    }
}
