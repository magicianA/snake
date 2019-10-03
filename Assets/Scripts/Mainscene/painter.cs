using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Painter generate walls&food&items,in other words,it paints.
public class painter : MonoBehaviour
{
    private static painter _instance;
    public static painter Instance
    {
        get{
            return _instance;
        }
    }
    public float boxsize = 30f;
    public int mapx = 20;
    public int mapy = 20; 
    public float walldensity = 0.04f;
    public GameObject wall1b1prefab; // map parameters
    public GameObject foodprefab;
    public List<Transform> foodlist = new List<Transform>();
    public float fooddensity = 0.07f; //food parameters
    public float itemdensity = 0.1f;
    public float itemweight; //item parameters
    void Awake()
    {
        _instance = this;
    }
    void Start()
    {
        initmap();
        initfood();
    }

    void Update()
    {
        
    }
    void initmap()
    {
        buildborder();
        buildwall();
    }
    void buildborder()
    {
        for(int i = 0;i < mapx;i++){
            Instantiate(wall1b1prefab,new Vector3(i * boxsize,0,1),Quaternion.identity);
            Instantiate(wall1b1prefab,new Vector3(i * boxsize,(mapy - 1) * boxsize,1),Quaternion.identity);
        }
        for(int i = 0;i < mapy - 1;i++){
            Instantiate(wall1b1prefab,new Vector3(0,i * boxsize,1),Quaternion.identity);
            Instantiate(wall1b1prefab,new Vector3((mapx - 1) * boxsize,i * boxsize,1),Quaternion.identity);
        }
    }
    void buildwall()
    {
        int wallnum = System.Convert.ToInt32(walldensity * mapy * mapx);
        for(int i= 0; i < wallnum;i++){
            int x = System.Convert.ToInt32(Random.Range(1,mapx-1));
            int y = System.Convert.ToInt32(Random.Range(1,mapy-1));
            Instantiate(wall1b1prefab,new Vector3(x * boxsize,y * boxsize , 0),Quaternion.identity);
        }
    }
    void initfood(){
        for(int i = 0; i < System.Convert.ToInt32(fooddensity * mapy * mapx); i++)
            genfood();
    }
    public void genfood(){
        Instantiate(foodprefab,new Vector3( System.Convert.ToInt32(Random.Range(1,mapx-1))*boxsize, System.Convert.ToInt32(Random.Range(1,mapy-1))*boxsize,0),Quaternion.identity);
    }

}
