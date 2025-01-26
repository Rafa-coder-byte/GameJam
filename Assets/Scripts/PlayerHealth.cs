using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 6; // Número máximo de puntos de vida
    private float currentHealth; // Salud actual (puede ser decimal)
    public Image[] hearts; // Array para almacenar las imágenes de los corazones
    public Sprite fullHeart; // Sprite del corazón lleno
    public Sprite halfHeart; // Sprite del corazón medio
    public Sprite emptyHeart; // Sprite del corazón vacío
    public GameObject player;

    void Start()
    {
        currentHealth = maxHealth; // Inicializa la salud al máximo
        UpdateHearts(); // Actualiza la visualización de los corazones
    }

    public void TakeDamage(float damage)
    {  
        currentHealth -= damage; // Resta el daño a la salud actual
        Debug.Log("Current Health: " + currentHealth);
        if (currentHealth < 0)
        {
            currentHealth = 0; // Asegúrate de que no sea menor que 0
        }
        UpdateHearts(); // Actualiza la visualización de los corazones

        // Verificar si el jugador ha muerto
        if (currentHealth == 0)
        {
            PlayerDied(); // Llama a la función de muerte
        }
    }

    public void Heal(float healAmount)
    {
        currentHealth += healAmount; // Suma la curación a la salud actual
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth; // Asegúrate de que no supere el máximo
        }
        UpdateHearts(); // Actualiza la visualización de los corazones
    }

    void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            // Calcular el valor de cada corazón
            float heartValue = (i + 1) * 2; // Cada corazón representa 2 puntos de vida

            if (currentHealth >= heartValue) // Si la salud es mayor o igual al valor del corazón
            {
                hearts[i].sprite = fullHeart; // Asigna el sprite del corazón lleno
            }
            else if (currentHealth >= heartValue - 1) // Si la salud es mayor o igual al valor del corazón menos 1
            {
                hearts[i].sprite = halfHeart; // Asigna el sprite del corazón medio
            }
            else
            {
                hearts[i].sprite = emptyHeart; // Asigna el sprite del corazón vacío
            }
        }
    }

    void PlayerDied()
    {
        // Aquí puedes manejar la lógica de la muerte del jugador
        Debug.Log("El jugador ha muerto!");
        player.gameObject.SetActive(false);

        // Por ejemplo, reiniciar la escena actual
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        // O mostrar un menú de Game Over
        // Puedes implementar un método para mostrar un menú de Game Over aquí
    }
}
/*
 using UnityEngine;
using TMPro;
public class PlayerHealth : MonoBehaviour
{
    public GameObject player; 
    public int maxHealth = 100;
    private int currentHealth;
    public TextMeshProUGUI vida;
    public bool died = false;
    void Start()
    {
        player = GameObject.Find("Personaje");
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
}
*/