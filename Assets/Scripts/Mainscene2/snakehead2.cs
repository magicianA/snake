using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snakehead2 : MonoBehaviour
{
    public List<Transform> bodylist = new List<Transform>();
    public GameObject bodyprefab,bulletprefab;
    public float speed = 100f;
    
    void Start()
    {
        for(int i = 0;i < 10;i++) Grow();
    }
    private void MoveHead()
    {
        Vector3 mouse = Input.mousePosition;
        Vector3 SnakePos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 drec = mouse - SnakePos;
        drec.z = 0;
        if(drec.magnitude > 40f){
            transform.up = drec;
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        else{
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
    }
    void Update()
    {
        MoveHead();
        if(Input.GetMouseButtonDown(0)) shoot();
    }

    public void Grow()
    {
        GameObject body = Instantiate(bodyprefab,getlastbody(),Quaternion.identity);
        if(bodylist.Count > 0)
            body.GetComponent<follow2>().target = bodylist[bodylist.Count-1];
        else body.GetComponent<follow2>().target = transform;
        bodylist.Add(body.transform);
    }
    
    private Vector3 getlastbody()
    {
        if(bodylist.Count > 0){
            return bodylist[bodylist.Count-1].position;
        }
        return transform.position;
    }
    
    public void Reduce(){
        if(bodylist.Count > 0){
            Destroy(bodylist[bodylist.Count-1].gameObject);
            bodylist.RemoveAt(bodylist.Count-1);
        }
        else  mainUI.Instance.death();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "wall"){
            mainUI.Instance.death();
        }
        if(collision.tag == "monster"){
            mainUI.Instance.death();
        }
    }
    void shoot()
    {
        GameObject bullet = Instantiate(bulletprefab,transform.position + transform.up.normalized * 50f,Quaternion.identity);
        bullet.transform.up = transform.up;
    }
}
