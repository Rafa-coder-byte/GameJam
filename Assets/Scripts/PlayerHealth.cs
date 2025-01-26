using UnityEngine;
using TMPro;
public class PlayerHealth : MonoBehaviour
{
    public GameObject player; 
    public int maxHealth ;
    public int currentHealth;
    public TextMeshProUGUI vida;
    public bool died = false;
    void Start()
    {
        player = GameObject.Find("Personaje");
        maxHealth = 200;
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
    public int Get_Current_Health(){
        return currentHealth;
    } 
}
