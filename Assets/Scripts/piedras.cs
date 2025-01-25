using UnityEngine;

public class Rock : MonoBehaviour
{
    // Propiedades de la piedra
    public string rockName = "Piedra";
    public float size = 1.0f; // Tamaño de la piedra
    public float weight = 5.0f; // Peso de la piedra

    // Método de inicialización
    void Start()
    {
        // Configura las propiedades iniciales de la piedra si es necesario
    }

    // Método de ejemplo para interactuar con la piedra
    void OnMouseDown()
    {
        // La piedra es un obstáculo, no se puede mover ni destruir
        Debug.Log(rockName + " es un obstáculo y no se puede mover ni destruir.");
    }
}
