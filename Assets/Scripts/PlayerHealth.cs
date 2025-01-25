using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // L�gica para cuando el personaje muere
        Debug.Log("El personaje ha muerto.");
        // Aqu� puedes a�adir la l�gica para reiniciar el nivel o mostrar una pantalla de Game Over
    }
}
