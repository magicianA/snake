using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainUI : MonoBehaviour
{
    
    private static mainUI _instance;
    public Text scoretext,deathtext;
    public GameObject deathmenu;
    public static mainUI Instance
    {
        get{
            return _instance;
        }
    }
    void Awake()
    {
        _instance = this;
        scoretext = GameObject.Find("ScoreText").GetComponent<Text>();
    }
    void Start()
    {

    }

    void Update()
    {
        
    }
    public void updateUI(int s)
    {
        int p = System.Convert.ToInt32(scoretext.text);
        p += s;
        scoretext.text = System.Convert.ToString(p);
    }
    public void death()
    {
        deathmenu.SetActive(true);
        deathtext.text = "您的分数为" +  scoretext.text + "分";
        Time.timeScale = 0;
    }
}
