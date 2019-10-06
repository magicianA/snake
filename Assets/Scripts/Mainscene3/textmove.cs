using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textmove : MonoBehaviour
{
    void Start()
    {
        GetComponent<TextMesh>().text = System.Convert.ToString(transform.parent.GetComponent<blockmove>().damage);
    }
    void Update()
    {
        
    }
}
