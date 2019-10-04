using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Snakehead : MonoBehaviour
{
    public float speed = 100f;
    public List<Transform> bodylist = new List<Transform> ();
    public GameObject bodyprefab,sheildcircleprefab;
    private GameObject sheildcircle;
    private bool isspeedup = false, issheild = false;
    private float  speeduptime = 0f,sheildtime = 0f;
    void Start()
    {

    }

    void Update()
    {
        MoveHead();
        MoveBody();
        if(Input.GetKeyDown(KeyCode.G)){
            Grow();
        }
        if(Input.GetKeyDown(KeyCode.R)){
            Reduce();
        }
        speedupcountdown();
        sheildcountdown();
    }
    private void speedupcountdown()
    {
        if(isspeedup){
            speeduptime -= Time.deltaTime;
            if(speeduptime <= 0){
                isspeedup = false;
                speed = 100f;
            }
        }
    }
    private void sheildcountdown()
    {
        if(issheild){
            sheildtime -= Time.deltaTime;
            if(sheildtime <= 0){
                issheild = false;
                Destroy(sheildcircle);
            }
        }
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
    private void MoveBody()
    {
        if(bodylist.Count > 0){
            for(int i = 0;i < bodylist.Count; i++){
                Vector3 targets;
                if(i==0) targets = transform.position;
                else targets = bodylist[i-1].position;
                Vector3 drecs = targets - bodylist[i].position;
                if(drecs.magnitude > 20f){
                    bodylist[i].transform.up = drecs;
                    bodylist[i].Translate(Vector3.up * speed * Time.deltaTime); 
                }
            }
        }
    }
    public void Grow()
    {
        GameObject body = Instantiate(bodyprefab,getlastbody(),Quaternion.identity);
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
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "food"){
            Destroy(collision.gameObject);
            Grow();
            painter.Instance.genfood();
        }
        if(collision.tag == "wall"){
            while(bodylist.Count > 0) Reduce();
            Debug.Log("You died");
            //SceneManager.LoadScene("gamestart");
        }
        if(collision.tag == "boom"){
            Destroy(collision.gameObject);
            if(!issheild){
                int n = bodylist.Count;
                while(bodylist.Count > n/2) Reduce();
            }
        }
        if(collision.tag == "poisonousgrass"){
            Destroy(collision.gameObject);
            if(!issheild){
                Reduce(); Reduce();
            }
        }
        if(collision.tag == "mushroom"){
            Destroy(collision.gameObject);
            int n = bodylist.Count;
            for(int i = 0; i < n; i++) Grow();
        }
        if(collision.tag == "energy"){
            Destroy(collision.gameObject);
            isspeedup = true;
            speed = 200f; 
            speeduptime = 6f;
        }
        if(collision.tag == "sheild"){
            Destroy(collision.gameObject);
            issheild = true;
            sheildtime = 6f;
            sheildcircle = Instantiate(sheildcircleprefab,transform.position,Quaternion.identity); 
        }
    }

}
