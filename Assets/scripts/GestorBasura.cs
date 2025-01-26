using UnityEngine;

public class GestorDeBasura : MonoBehaviour
{
    public int cantidadNecesariaParaAtaque = 30; // Ajusta seg�n tu necesidad
    public GameObject boss; // Asigna el boss en el Inspector
    private TrashCounter trashCounter;
    private RandomObjectSpawner picked_garbage;
    private PlayerMovement player;
    

    void Start()
    {// Desactiva el boss al inicio del juego
        boss.SetActive(false);
        // Encuentra el componente TrashCounter
        trashCounter = GetComponent<TrashCounter>();
    }
    

    // M�todo para verificar y activar el boss
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

    // M�todo para activar el ataque del boss
    void ActivarAtaqueBoss()
    {
        Debug.Log("Se esta activando al Boss2");
        boss.SetActive(true); // Activa el GameObject del boss

    }
    void Verify_Trash(){
        if(trashCounter.trashCount == picked_garbage.numberOfObjects){
            boss.SetActive(false);
            

        }
    }
}
