using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 6; // N�mero m�ximo de puntos de vida
    private float currentHealth; // Salud actual (puede ser decimal)
    public Image[] hearts; // Array para almacenar las im�genes de los corazones
    public Sprite fullHeart; // Sprite del coraz�n lleno
    public Sprite halfHeart; // Sprite del coraz�n medio
    public Sprite emptyHeart; // Sprite del coraz�n vac�o
    public GameObject player;

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
        // Aqu� puedes manejar la l�gica de la muerte del jugador
        Debug.Log("El jugador ha muerto!");
        player.gameObject.SetActive(false);

        // Por ejemplo, reiniciar la escena actual
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        // O mostrar un men� de Game Over
        // Puedes implementar un m�todo para mostrar un men� de Game Over aqu�
    }
}
/*
 using UnityEngine;
using TMPro;
public class PlayerHealth : MonoBehaviour
{
    public GameObject player; 
    public int maxHealth ;
    public int currentHealth;
    public TextMeshProUGUI vida;
    public bool died = false;
    void Start()
    {
        player = GameObject.Find("Personaje");
        maxHealth = 200;
        currentHealth = maxHealth;
        vida.text = "Vida: " + currentHealth.ToString();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0 && !died)
        {
            vida.text = "Vida: 0";
            died = true;
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("El personaje ha muerto.");
        player.gameObject.SetActive(false);
    }
    void FixedUpdate()
    {
        if(!died) vida.text = "Vida: " + currentHealth.ToString();
    }
    public int Get_Current_Health(){
        return currentHealth;
    } 
}
*/