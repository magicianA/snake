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
    public int mapx = 80;
    public int mapy = 80; 
    public float walldensity = 0.05f;
    public GameObject wall1b1prefab,wall1b3prefab,wall1b5prefab,wall1b7prefab; // map parameters
    public GameObject foodprefab;
    public List<Transform> foodlist = new List<Transform>();
    public float fooddensity = 0.02f; //food parameters
    public float itemdensity = 0.007f;
    public GameObject[] itemprehab = new GameObject[7];
    //1=boom 2=energy 3=mushroom 4=poisonousgrass 5=shield 6=smartgrass
    public float[] itemweight = {0f,0.1f,0.2f,0.3f,0.4f,0.5f,1f}; // add up to 1
    //item parameters
    public List <List <int>> terrain = new List<List<int>> (); 
    void Awake()
    {
        _instance = this;
    }
    void Start()
    {
        inittarrain();
        initmap();
        initfood();
        inititem();
    }
    void inittarrain()
    {
        for(int i = 0 ;i < mapx ;i++){
            terrain.Add(new List<int> ());
            for(int j = 1 ;j < mapy ;j++)
                terrain[i].Add(0);
        }
    }
    void initmap()
    {
        buildborder();
        _buildwall();
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

            while(terrain[x][y] != 0){
                x = System.Convert.ToInt32(Random.Range(1,mapx-1));
                y = System.Convert.ToInt32(Random.Range(1,mapy-1));
            }
            terrain[x][y] = 8;
            Instantiate(wall1b1prefab,new Vector3(x * boxsize,y * boxsize , 0),Quaternion.identity);
        }
    }
    void _buildwall()
    {
        int wallnum = System.Convert.ToInt32(walldensity * mapy * mapx * 0.2);
        Vector3[] drec = {Vector3.left,Vector3.up,Vector3.down,Vector3.right};
        for(int i = 0;i < wallnum;i++){
            GameObject wall = Instantiate(wall1b1prefab,new Vector3(0,0,100),Quaternion.identity);
            wall.transform.up = drec[System.Convert.ToInt32(Random.Range(0,4))];
            wall.transform.position = new Vector3(Random.Range(1,mapx-1) * boxsize,Random.Range(1,mapy-1) * boxsize,-1); 
        }
        for(int i = 0;i < wallnum;i++){
            GameObject wall = Instantiate(wall1b3prefab,new Vector3(0,0,100),Quaternion.identity);
            wall.transform.up = drec[System.Convert.ToInt32(Random.Range(0,4))];
            wall.transform.position = new Vector3(Random.Range(1,mapx-1) * boxsize,Random.Range(1,mapy-1) * boxsize,-1); 
        }
        for(int i = 0;i < wallnum;i++){
            GameObject wall = Instantiate(wall1b5prefab,new Vector3(0,0,100),Quaternion.identity);
            wall.transform.up = drec[System.Convert.ToInt32(Random.Range(0,4))];
            wall.transform.position = new Vector3(Random.Range(1,mapx-1) * boxsize,Random.Range(1,mapy-1) * boxsize,-1); 
        }
        for(int i = 0;i < wallnum;i++){
            GameObject wall = Instantiate(wall1b5prefab,new Vector3(0,0,100),Quaternion.identity);
            wall.transform.up = drec[System.Convert.ToInt32(Random.Range(0,4))];
            wall.transform.position = new Vector3(Random.Range(1,mapx-1) * boxsize,Random.Range(1,mapy-1) * boxsize,-1); 
        }    
    }
    void initfood(){
        for(int i = 0; i < System.Convert.ToInt32(fooddensity * mapy * mapx); i++)
            genfood();
    }
    public void genfood(){
        int x = System.Convert.ToInt32(Random.Range(1,mapx-1));
        int y = System.Convert.ToInt32(Random.Range(1,mapy-1));
        while(terrain[x][y] != 0){
            x = System.Convert.ToInt32(Random.Range(1,mapx-1));
            y = System.Convert.ToInt32(Random.Range(1,mapy-1));
        }
        terrain[x][y] = 7;
        Instantiate(foodprefab,new Vector3(x * boxsize,y * boxsize , 0),Quaternion.identity);
    }
    void inititem()
    {
        for(int i = 0; i < System.Convert.ToInt32(itemdensity * mapy * mapx); i++)
            genitem();
    }
    public void genitem(){
        float p = Random.Range(0,1);
        for(int i = 1;i <= 6;i++){
            if(itemweight[i] - itemweight[i-1] > p){
                int x = System.Convert.ToInt32(Random.Range(1,mapx-1));
                int y = System.Convert.ToInt32(Random.Range(1,mapy-1));
                while(terrain[x][y] != 0){
                    x = System.Convert.ToInt32(Random.Range(1,mapx-1));
                    y = System.Convert.ToInt32(Random.Range(1,mapy-1));
                }
                terrain[x][y] = i;
                Instantiate(itemprehab[i],new Vector3(x * boxsize,y * boxsize , 0),Quaternion.identity);
            }
        }
    }

}
