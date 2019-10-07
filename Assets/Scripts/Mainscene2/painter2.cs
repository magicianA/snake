using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class painter2 : MonoBehaviour
{
    private static painter2 _instance;
    public static painter2 Instance
    {
        get{
            return _instance;
        }
    }
    public float boxsize = 30f;
    public int mapx = 30;
    public int mapy = 20; 
    public GameObject wall1b1prefab; 
    public List <List <int>> terrain = new List<List<int>> (); 
    void Awake()
    {
        _instance = this;
    }
    void Start()
    {
        inittarrain();
        buildborder();
    }
    void inittarrain()
    {
        for(int i = 0 ;i < mapx ;i++){
            terrain.Add(new List<int> ());
            for(int j = 1 ;j < mapy ;j++)
                terrain[i].Add(0);
        }
    }
    void buildborder()
    {
        for(int i = 0;i < mapx;i++){
            Instantiate(wall1b1prefab,new Vector3(i * boxsize,0,-1),Quaternion.identity);
            Instantiate(wall1b1prefab,new Vector3(i * boxsize,(mapy - 1) * boxsize,-1),Quaternion.identity);
        }
        for(int i = 0;i < mapy - 1;i++){
            Instantiate(wall1b1prefab,new Vector3(0,i * boxsize,-1),Quaternion.identity);
            Instantiate(wall1b1prefab,new Vector3((mapx - 1) * boxsize,i * boxsize,-1),Quaternion.identity);
        }
    }
}
