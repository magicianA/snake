using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followy : MonoBehaviour
{
    
    private float speedl = 300f, speedh = 400f;
    public Transform target;
    public List<Vector3> pos = new List<Vector3>();
    public float interval = 0.02f;
    public float tick = 0.05f;
    void Start()
    {
        
    }

    void Update()
    {
        pos.Add(target.position);
        if(tick <= 0){
            move();
            pos.RemoveAt(0);
        }
        tick -= Time.deltaTime;
    }
        
    private void move()
    {
        if(System.Math.Abs(transform.position.y - target.position.y) > 1f){
            if(pos.Count > 0){
                if(System.Math.Abs(transform.position.y - target.position.y) > 30f)
                    transform.Translate(drec(pos[0].y,transform.position.y) * speedh * Time.deltaTime);
                else transform.Translate(drec(pos[0].y,transform.position.y) * speedl * Time.deltaTime);
            }
        }
    }
    Vector3 drec(float tar,float now){
        if(tar > now) return Vector3.up;
        return Vector3.down;
    }

}
