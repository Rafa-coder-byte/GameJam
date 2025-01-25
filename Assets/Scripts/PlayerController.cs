using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int score = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryPickUpObject();
        }
    }

    void TryPickUpObject()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, 1f);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.CompareTag("Collectible"))
            {
                score++;
                hitCollider.gameObject.SetActive(false);
            }
        }
    }

    
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 1f);
    }
}


