using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snakehead4 : MonoBehaviour
{
    public List<Transform> bodylist = new List<Transform>();
    public GameObject bodyprefab;
    public float speedl = 200f, speedh = 300f;
    public float interval = 0.05f,tick = 0f;
    void Start()
    {
        
    }

    void Update()
    {
        movehead();
        if(tick <= 0){
            leavepath();
            tick = interval;
        }
        tick -= Time.deltaTime;
    }
    private void movehead()
    {
        Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(mousepos.y > transform.position.y && transform.position.y < 200){
            if(mousepos.y - transform.position.y > 40){
                transform.Translate(Vector3.up * speedh * Time.deltaTime);
            }
            else transform.Translate(Vector3.up * speedl * Time.deltaTime);
        }
        if(mousepos.y < transform.position.y && transform.position.y > -180){
            if(transform.position.y - mousepos.y > 40){
                transform.Translate(Vector3.down * speedh * Time.deltaTime);
            }
            else transform.Translate(Vector3.down * speedl * Time.deltaTime);
        }
    }
    private void leavepath()
    {
        Instantiate(bodyprefab,transform.position,Quaternion.identity);
        mainUI.Instance.updateUI(1);
    }
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "block"){
            if(GetComponent<SpriteRenderer>().color != collision.GetComponent<SpriteRenderer>().color){
                mainUI.Instance.death();
            }
        }
        if(collision.tag == "colorchanger"){
            GetComponent<SpriteRenderer>().color = collision.GetComponent<SpriteRenderer>().color;
        }
    }
}
