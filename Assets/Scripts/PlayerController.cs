using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int score = 0;
    public TrashCounter trashCounter;
    public PlayerHealth playerHealth;

    void Start()
    {
        trashCounter = FindFirstObjectByType<TrashCounter>(); 
    }

    

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            score++;
            trashCounter.IncrementTrashCount();
            Debug.Log("Objeto recogido! Puntaje: " + score);
            Destroy(other.gameObject);
        }
   
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 1f);
    }
}


