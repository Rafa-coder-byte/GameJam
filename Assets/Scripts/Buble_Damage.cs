using UnityEngine;

public class GarbageCollision : MonoBehaviour
{
    public AudioClip audio_collision;
    private AudioSource audioSource;
    private void Start(){
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {   

            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1);
            }
            PlayCollisionSound();
            
        }
    }
    private void PlayCollisionSound()
    {
        audioSource.clip = audio_collision;
        audioSource.Play();
    }

}

