using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletmove : MonoBehaviour
{
    public float speed = 1000f;
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "wall"){
            Destroy(gameObject);
        }
        if(collision.tag == "monster"){
            collision.gameObject.GetComponent<monster>().hp--;
            mainUI.Instance.updateUI(-1);
            Destroy(gameObject);
        }
        if(collision.tag == "snake"){
            collision.gameObject.GetComponent<snakehead2>().Reduce();
            Destroy(gameObject);
        }
    }
}
