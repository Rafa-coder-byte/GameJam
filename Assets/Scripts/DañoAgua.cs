using System.Collections;
using UnityEngine;

public class WaterDamage : MonoBehaviour
{
    public PlayerHealth vidajugador;
    public CapsuleCollider2D playercol;
    public int damageAmount = 10; // Cantidad de daño que el agua hace al personaje
    public float damageInterval = 1.0f; // Intervalo de tiempo entre cada daño
    private bool isInWater = false;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isInWater)
        {
            isInWater = true;
            StartCoroutine(DamagePlayer());
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && isInWater)
        {
            isInWater = false;
        }
    }

    private IEnumerator DamagePlayer()
    {
        while (isInWater)
        {
            vidajugador.TakeDamage(damageAmount);
            yield return new WaitForSeconds(damageInterval);
        }
    }

    void Start()
    {
        playercol = vidajugador.GetComponent<CapsuleCollider2D>();
    }
}