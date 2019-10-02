using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject target;
    void Start()
    {
        target = GameObject.Find("SnakeHead");
    }

    void Update()
    {
        move();
    }
    void move()
    {
        Vector3 targetpos = target.transform.position;
        targetpos.z = transform.position.z;
        transform.position = targetpos;
    }
}
