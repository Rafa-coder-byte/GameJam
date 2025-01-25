using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Antisquare : MonoBehaviour
{
    public GameObject cuadrado;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            cuadrado.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("pingona"); // Añade un mensaje de depuración
            cuadrado.SetActive(true);
        }
    }
}
