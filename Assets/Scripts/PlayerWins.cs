using UnityEngine;
using TMPro; // Asegúrate de incluir esto si usas TextMeshPro

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI victoryText; // Asigna el TextMeshProUGUI en el Inspector
    public GameObject player;
    public GameObject menuboton;

    void Start()
    {
        // Asegúrate de que el texto de victoria esté desactivado al inicio
        victoryText.gameObject.SetActive(false);
    }

    // Método que se llama cuando el jugador gana
    public void PlayerWins()
    {
        // Muestra el texto de victoria
        victoryText.gameObject.SetActive(true);
        menuboton.gameObject.SetActive(true);
        player.gameObject.SetActive(false);
    }
}