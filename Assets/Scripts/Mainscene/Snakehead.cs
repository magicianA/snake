using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snakehead : MonoBehaviour
{
    public float speed = 100f;
    void Start()
    {
         
    }

    void Update()
    {
        Move();
    }
    private void Move()
    {
        Vector3 mouse = Input.mousePosition;
        Vector3 SnakePos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 drec = mouse - SnakePos;
        drec.z = 0;
        if(drec.magnitude > 40f){
            drec = drec.normalized;
            transform.up = drec;
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        else{
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
    }

}
