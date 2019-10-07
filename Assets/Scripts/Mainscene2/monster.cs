using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster : MonoBehaviour
{
    public int hp = 20;
    public GameObject bulletprefab,target;
    private float interval = 1f,tick = 0f;
    void Start()
    {
        
    }

    void Update()
    {
        if(tick <= 0){
            shoot();
            if(hp <= 5) skill();
            tick = interval;
        }
        tick -= Time.deltaTime;
        if(hp <= 10){
            interval = 0.5f;
        }
        if(hp <= 0){
            mainUI.Instance.death();
            Destroy(gameObject);
        }
    }
    
    void shoot()
    {
        Vector3 drec = target.transform.position - transform.position;
        GameObject bullet = Instantiate(bulletprefab,transform.position + drec.normalized * 90f,Quaternion.identity);
        bullet.transform.up = drec;
        bullet.GetComponent<bulletmove>().speed = 300f;
    }
    void skill()
    {
        Vector3[] pos = {new Vector3(1,0,0),new Vector3(0,1,0),new Vector3(0,-1,0),new Vector3(-1,0,0)};
        for(int i=0;i<4;i++){
            GameObject bullet = Instantiate(bulletprefab,transform.position + pos[i].normalized * 90f,Quaternion.identity);
            bullet.transform.up = pos[i];
        }
    }
}
