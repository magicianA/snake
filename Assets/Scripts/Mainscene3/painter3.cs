using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class painter3 : MonoBehaviour
{
    public float blocktick = 4f;
    private float blocktime = 0f;
    public GameObject blockprefab;
    public Sprite[] blocksprite = new Sprite[4];
    private void blockcountdown()
    {   
        if(blocktime <= 0){
            genblock();
            blocktime = blocktick;
        }
        blocktime -= Time.deltaTime;
    }
    void Start()
    {
        
    }

    void Update()
    {
        blockcountdown();
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
}
