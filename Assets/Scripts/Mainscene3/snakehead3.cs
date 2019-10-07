using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snakehead3 : MonoBehaviour
{
    public float movespeedl = 300f, movespeedh = 500f;
    private List<Transform> bodylist = new List<Transform>();
    public GameObject bodyprefab;
    void Start()
    {
        transform.up = Vector3.right;
        grow(); grow();
    }
    void Update()
    {
        movehead();
    }
    private void movehead()
    {
        Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(mousepos.y > transform.position.y && transform.position.y < 57){
            if(mousepos.y - transform.position.y > 40){
                transform.Translate(Vector3.left * movespeedh * Time.deltaTime);
            }
            else transform.Translate(Vector3.left * movespeedl * Time.deltaTime);
        }
        if(mousepos.y < transform.position.y && transform.position.y > -150){
            if(transform.position.y - mousepos.y > 40){
                transform.Translate(Vector3.right * movespeedh * Time.deltaTime);
            }
            else transform.Translate(Vector3.right * movespeedl * Time.deltaTime);
        }
    }
    private void grow()
    {
        GameObject body = Instantiate(bodyprefab,getlastbody(),Quaternion.identity);
        if(bodylist.Count > 0)
            body.GetComponent<followy>().target = bodylist[bodylist.Count-1].transform;
        else 
            body.GetComponent<followy>().target = transform;
        bodylist.Add(body.transform);
        mainUI.Instance.updateUI(4);
    }
    private Vector3 getlastbody()
    {
        Vector3 res = new Vector3();
        if(bodylist.Count > 0){
            res = bodylist[bodylist.Count-1].position;
        }
        else res = transform.position;
        res.x -= 20f;
        return res;
    }
    public void reduce()
    {
        if(bodylist.Count > 0){
            Destroy(bodylist[bodylist.Count-1].gameObject);
            bodylist.RemoveAt(bodylist.Count-1);
        }
        else mainUI.Instance.death();
    }
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "block"){
            int n = collision.gameObject.GetComponent<blockmove>().damage;
            Destroy(collision.gameObject);
            for(int i = 0 ;i < n;i++) reduce();
        }
        if(collision.tag == "food3"){
            int n = collision.gameObject.GetComponent<blockmove>().damage;
            Destroy(collision.gameObject);
            for(int i = 0 ;i < n;i++) grow();            
        }
    }
}
