using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followy : MonoBehaviour
{
    
    public float movespeedl = 800f, movespeedh = 1000f;
    public GameObject target;
    void Start()
    {
        
    }

    void Update()
    {
        move();
    }
        
    private void move()
    {
        Vector3 targetpos = target.transform.position;
        if(targetpos.y > transform.position.y && transform.position.y < 57){
            if(targetpos.y - transform.position.y > 40){
                transform.Translate(Vector3.up * movespeedh * Time.deltaTime);
            }
            else transform.Translate(Vector3.up * movespeedl * Time.deltaTime);
        }
        if(targetpos.y < transform.position.y && transform.position.y > -150){
            if(transform.position.y - targetpos.y > 40){
                transform.Translate(Vector3.down * movespeedh * Time.deltaTime);
            }
            else transform.Translate(Vector3.down * movespeedl * Time.deltaTime);
        }
    }

}
