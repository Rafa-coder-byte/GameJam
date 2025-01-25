using System.Collections;
using UnityEngine;

public class WaterDamage : MonoBehaviour
{
    public int damageAmount = 10; // Cantidad de daño que el agua hace al personaje
    public float damageInterval = 1.0f; // Intervalo de tiempo entre cada daño

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Inicia el daño continuo al personaje
            StartCoroutine(DamagePlayer(other));
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Detiene el daño continuo al personaje
            StopCoroutine(DamagePlayer(other));
        }
    }

    private IEnumerator DamagePlayer(Collider2D player)
    {
        while (true)
        {
            // Aquí puedes llamar a un método en el script del personaje para aplicar el daño
            player.GetComponent<PlayerHealth>().TakeDamage(damageAmount);
            yield return new WaitForSeconds(damageInterval);
        }
    }
}
