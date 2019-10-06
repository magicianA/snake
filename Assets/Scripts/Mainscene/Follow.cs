using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform target;
    private List<Vector3> pos = new List<Vector3>();
    public float speedl = 100f,speedh = 300f;
    public float interval = 0.02f;
    public float tick = 0.05f;
    void Update()
    {
        pos.Add(target.position);
        if(tick <= 0){
            move();
            pos.RemoveAt(0);
        }
        tick -= Time.deltaTime;
    }
    void move() //勉强可用
    {
        if(Vector3.Distance(transform.position,target.position) > 20f){
            if(pos.Count > 0){
                Vector3 drec = pos[0] - transform.position;
                transform.up = drec;
                if(Vector3.Distance(transform.position,target.position) > 30f)
                    transform.Translate(Vector3.up * speedh * Time.deltaTime);
                else transform.Translate(Vector3.up * speedl * Time.deltaTime);
            }
            else{
                Vector3 drec = target.position - transform.position;
                transform.up = drec;
                transform.Translate(Vector3.up * speedl * Time.deltaTime);
                pos.RemoveAt(0);
            }
        }
    }
}
