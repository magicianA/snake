using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    private List<Vector3> path = new List<Vector3>();
    public Transform target;
    public float dis = 20f;
    public float spd = 100f;
    void Start()
    {
        
    }
    void Update()
    {
        follow();
    }
    void walkto(Vector3 targetpos,float speed){
        transform.up = targetpos - transform.position;
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
    void follow()
    {
        if(path.Count > 0){
            while(path.Count > 20) path.RemoveAt(0);
            if(Vector3.Distance(target.position,path[path.Count-1]) > dis ) path.Add(target.position);
            walkto(path[0],spd);
            path.RemoveAt(0);
        }
        else path.Add(target.position);
    }
}
