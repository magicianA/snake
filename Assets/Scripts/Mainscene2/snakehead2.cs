using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snakehead2 : MonoBehaviour
{
    public List<Transform> bodylist = new List<Transform>();
    public GameObject bodyprefab;
    public float speed = 100f;
    
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
        if(Input.GetKeyDown(KeyCode.G)) Grow();
        if(Input.GetKeyDown(KeyCode.R)) Reduce();
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
    }
}
