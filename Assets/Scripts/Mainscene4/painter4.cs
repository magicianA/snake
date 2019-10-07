using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class painter4 : MonoBehaviour
{
    public GameObject[] obstacles = new GameObject[2];
    public GameObject[] colorchangerprefab = new GameObject[4];
    public float tick = 3f,ticktime = 0f;
    private int cnt = 0;
    void Start()
    {
        
    }

    void Update()
    {
        if(ticktime <= 0){
            if(cnt > 2){
                gencolorchanger();
                cnt = 0;
            }
            else{
                genobstacle();
                cnt++;
            }
            ticktime = tick;
        }
        ticktime -= Time.deltaTime;
    }
    void genobstacle()
    {
        int r = System.Convert.ToInt32(Random.Range(0,2));
        Instantiate(obstacles[r],new Vector3(570,10,5),Quaternion.identity);
    }
    void gencolorchanger()
    {
        int r = System.Convert.ToInt32(Random.Range(0,4));
        GameObject cc = Instantiate(colorchangerprefab[r],new Vector3(570,0,-5),Quaternion.identity);
    }
}
