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
            Debug.Log("Se esta activando al Boss1");
            // Reiniciar el contador de basura a 0
            trashCounter.ResetTrashCount();
        }
    }

    // Método para activar el ataque del boss
    void ActivarAtaqueBoss()
    {
        Debug.Log("Se esta activando al Boss2");
        boss.SetActive(true); // Activa el GameObject del boss
    }
}
