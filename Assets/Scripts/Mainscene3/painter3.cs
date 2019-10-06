using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class painter3 : MonoBehaviour
{
    private float blocktick = 4f,food3tick = 4f;
    private float blocktime = 0f,food3time = 2f;
    public GameObject blockprefab,food3prefab;
    public Sprite[] blocksprite = new Sprite[4];
    private void countdown()
    {   
        
        if(food3time <= 0 && blocktime > 0){
            genfood3();
            food3time = food3tick;
        }
        if(blocktime <= 0){
            genblock();
            blocktime = blocktick;
        }
        blocktime -= Time.deltaTime;
        food3time -= Time.deltaTime;
    }
    void Start()
    {
        
    }

    void Update()
    {
        countdown();
    }
    void genblock()
    {
        GameObject block1 = Instantiate(blockprefab,new Vector3(600,46,0),Quaternion.identity);
        block1.GetComponent<SpriteRenderer>().sprite = blocksprite[System.Convert.ToInt32(Random.Range(0,4))];
        block1.GetComponent<blockmove>().damage = System.Convert.ToInt32(Random.Range(0,4));

        GameObject block2 = Instantiate(blockprefab,new Vector3(600,-16,0),Quaternion.identity);
        block2.GetComponent<SpriteRenderer>().sprite = blocksprite[System.Convert.ToInt32(Random.Range(0,4))];
        block2.GetComponent<blockmove>().damage = System.Convert.ToInt32(Random.Range(0,4));
        
        GameObject block3 = Instantiate(blockprefab,new Vector3(600,-76,0),Quaternion.identity);
        block3.GetComponent<SpriteRenderer>().sprite = blocksprite[System.Convert.ToInt32(Random.Range(0,4))];
        block3.GetComponent<blockmove>().damage = System.Convert.ToInt32(Random.Range(0,4));
        
        GameObject block4 = Instantiate(blockprefab,new Vector3(600,-136,0),Quaternion.identity);
        block4.GetComponent<SpriteRenderer>().sprite = blocksprite[System.Convert.ToInt32(Random.Range(0,4))];
        block4.GetComponent<blockmove>().damage = System.Convert.ToInt32(Random.Range(0,4));

    }
    void genfood3()
    {

        GameObject food1 = Instantiate(food3prefab,new Vector3(600,52,0),Quaternion.identity);
        food1.GetComponent<blockmove>().damage = System.Convert.ToInt32(Random.Range(0,6));

        GameObject food2 = Instantiate(food3prefab,new Vector3(600,11,0),Quaternion.identity);
        food2.GetComponent<blockmove>().damage = System.Convert.ToInt32(Random.Range(0,6));
        
        GameObject food3 = Instantiate(food3prefab,new Vector3(600,-36,0),Quaternion.identity);
        food3.GetComponent<blockmove>().damage = System.Convert.ToInt32(Random.Range(0,6));
        
        GameObject food4 = Instantiate(food3prefab,new Vector3(600,-83,0),Quaternion.identity);
        food4.GetComponent<blockmove>().damage = System.Convert.ToInt32(Random.Range(0,6));
    
        GameObject food5 = Instantiate(food3prefab,new Vector3(600,-136,0),Quaternion.identity);
        food5.GetComponent<blockmove>().damage = System.Convert.ToInt32(Random.Range(0,6));    
    }
}
