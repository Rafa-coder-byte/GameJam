using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int score = 0;

    void Update()
    {
        // Detectar la tecla E para recoger objetos
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryPickUpObject();
        }
    }

    void TryPickUpObject()
    {
        // Crear un círculo de detección alrededor del jugador
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, 1f); // Asegúrate de que el rango sea suficiente
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.CompareTag("Collectible"))
            {
                // Incrementar el puntaje o realizar la acción deseada
                score++;
                Debug.Log("Objeto recogido! Puntaje: " + score);

                // Desactivar o destruir el objeto recogido
                hitCollider.gameObject.SetActive(false);
            }
        }
    }

    // Este método se usa solo para visualizar el rango de recogida en el editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 1f);
    }
}

