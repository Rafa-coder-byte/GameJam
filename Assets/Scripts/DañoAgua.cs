using System.Collections;
using UnityEngine;

public class WaterDamage : MonoBehaviour
{
    public PlayerHealth vidajugador;
    public PlayerMovement player;
    public CapsuleCollider2D playercol;
    public int damageAmount = 1; // Cantidad de daño que el agua hace al personaje
    public float damageInterval = 1.0f; // Intervalo de tiempo entre cada daño
    private bool isInWater = false;
    void Start()
    {
        if (vidajugador == null)
        {
            vidajugador = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<PlayerHealth>();
            playercol = vidajugador.GetComponent<CapsuleCollider2D>();
        }
    }
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


}