using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento del jugador

    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        if(Input.GetKeyDown(KeyCode.Space)){
            rb.position = new Vector3(-0.61751f , 2.622866f , 0.03833227f);
        }
        
    }
}
