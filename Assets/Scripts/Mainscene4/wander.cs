using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wander : MonoBehaviour
{
    public float speed = 100f;
    void Start()
    {
        transform.up = Vector3.up;
    }
    void Update()
    {
        if(transform.position.y > 140) transform.up = Vector3.down;
        if(transform.position.y < -150) transform.up = Vector3.up;
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
