using UnityEngine;

public class GestorDeBasura : MonoBehaviour
{
    public int cantidadNecesariaParaAtaque = 30; // Ajusta según tu necesidad
    public GameObject boss; // Asigna el boss en el Inspector
    private TrashCounter trashCounter;

    void Start()
    {
        // Desactiva el boss al inicio del juego
        boss.SetActive(false);
        // Encuentra el componente TrashCounter
        trashCounter = GetComponent<TrashCounter>();
    }

    // Método para verificar y activar el boss
    public void VerificarYActivarBoss()
    {
        if (trashCounter.TrashCount >= cantidadNecesariaParaAtaque)
        {
            ActivarAtaqueBoss();
        }
    }

    // Método para activar el ataque del boss
    void ActivarAtaqueBoss()
    {
        boss.SetActive(true); // Activa el GameObject del boss
    }
}
