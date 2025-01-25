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
        // Lógica para cuando el personaje muere
        Debug.Log("El personaje ha muerto.");
        // Aquí puedes añadir la lógica para reiniciar el nivel o mostrar una pantalla de Game Over
    }
}
