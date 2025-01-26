using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 6; // N�mero m�ximo de puntos de vida
    private float currentHealth; // Salud actual (puede ser decimal)
    public Image[] hearts; // Array para almacenar las im�genes de los corazones
    public Sprite fullHeart; // Sprite del coraz�n lleno
    public Sprite halfHeart; // Sprite del coraz�n medio
    public Sprite emptyHeart; // Sprite del coraz�n vac�o
    public GameObject player;
    public GameObject menuboton;
    public TextMeshProUGUI gameover;

    void Start()
    {
        currentHealth = maxHealth; // Inicializa la salud al m�ximo
        UpdateHearts(); // Actualiza la visualizaci�n de los corazones
    }

    public void TakeDamage(float damage)
    {  
        currentHealth -= damage; // Resta el da�o a la salud actual
        Debug.Log("Current Health: " + currentHealth);
        if (currentHealth < 0)
        {
            currentHealth = 0; // Aseg�rate de que no sea menor que 0
        }
        UpdateHearts(); // Actualiza la visualizaci�n de los corazones

        // Verificar si el jugador ha muerto
        if (currentHealth == 0)
        {
            PlayerDied(); // Llama a la funci�n de muerte
        }
    }

    public void Heal(float healAmount)
    {
        currentHealth += healAmount; // Suma la curaci�n a la salud actual
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth; // Aseg�rate de que no supere el m�ximo
        }
        UpdateHearts(); // Actualiza la visualizaci�n de los corazones
    }

    void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            // Calcular el valor de cada coraz�n
            float heartValue = (i + 1) * 2; // Cada coraz�n representa 2 puntos de vida

            if (currentHealth >= heartValue) // Si la salud es mayor o igual al valor del coraz�n
            {
                hearts[i].sprite = fullHeart; // Asigna el sprite del coraz�n lleno
            }
            else if (currentHealth >= heartValue - 1) // Si la salud es mayor o igual al valor del coraz�n menos 1
            {
                hearts[i].sprite = halfHeart; // Asigna el sprite del coraz�n medio
            }
            else
            {
                hearts[i].sprite = emptyHeart; // Asigna el sprite del coraz�n vac�o
            }
        }
    }

    void PlayerDied()
    {
        menuboton.gameObject.SetActive(true);
        gameover.gameObject.SetActive(true);
        Debug.Log("El jugador ha muerto!");
        player.gameObject.SetActive(false);
    }
}