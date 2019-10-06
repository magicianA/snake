using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramove2 : MonoBehaviour
{
    public GameObject target;
    void Start()
    {
        target = GameObject.Find("snakehead2");
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
