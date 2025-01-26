using UnityEngine;
using TMPro; // Asegúrate de tener esto para usar TextMeshPro

public class TrashCounter : MonoBehaviour
{
    public TextMeshProUGUI trashText; // Cambiar a TextMeshProUGUI
    private int trashCount = 0;
    public bool ronda=false;
    


    void Start()
    {
        // Asegurarse de que el texto inicial se muestra
        trashText.text = "Basura Recogida: " + trashCount;
    }

    public int TrashCount // Propiedad para acceder a trashCount
    {
        get { return trashCount; }
    }

    // Método para incrementar el contador de basura
    public void IncrementTrashCount()
    {
        trashCount++;
        trashText.text = "Basura Recogida: " + trashCount;

        if (!ronda)
        {
            // Notifica al GestorDeBasura para verificar si es hora de activar el boss
            GestorDeBasura gestorDeBasura = GetComponent<GestorDeBasura>();
            if (gestorDeBasura != null)
            {
                gestorDeBasura.VerificarYActivarBoss();
            }
        }
        if (ronda && trashCount >= 30) {
            FinalizarJuego();
        }
       
    }
    public void ResetTrashCount()
    {
        Debug.Log("Se reseteo");
        trashCount = 0; // Reinicia el contador a 0
        trashText.text = "Basura Recogida: " + trashCount; // Actualiza el texto
        ronda=true;
    }

    private void FinalizarJuego()
    {
        Debug.Log("¡Has ganado el juego");
        Time.timeScale = 0;

        // Llama al método para mostrar el texto de victoria
        GameManager gameManager = Object.FindFirstObjectByType<GameManager>();
        if (gameManager != null)
        {
            Debug.Log("Pa que salga el cartel");
            gameManager.PlayerWins();
        }
        else
        {
            Debug.LogError("No se encontró el GameManager en la escena.");
        }

        

    }


}


