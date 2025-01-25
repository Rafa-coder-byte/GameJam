using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class antisquare : MonoBehaviour
{
    public GameObject cuadrado;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            cuadrado.gameObject.SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.B))
        {
            
            cuadrado.gameObject.SetActive(true);
            ////////
            ////////
            ////////
        }
    }
}
