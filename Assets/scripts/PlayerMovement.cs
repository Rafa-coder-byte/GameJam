using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento del jugador
    public GameObject jugador;
    public Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jugador.gameObject.GetComponent<Animator>().enabled = false;
    }

    void Update()
    {
        
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)){
            jugador.transform.localScale =  new Vector3(0.75f , 0.75f,1); 
        }
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)){
            jugador.transform.localScale =  new Vector3(-0.75f , 0.75f,1); 
        }
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)){
            jugador.transform.localScale =  new Vector3(0.75f , 0.75f,1); 
        }
        if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)){
            jugador.transform.localScale =  new Vector3(0.75f , 0.75f,1); 
        }
    }

    void FixedUpdate()
    {
        // Mover al jugador
        if(movement.x != 0 || movement.y != 0)
        {
            jugador.gameObject.GetComponent<Animator>().enabled = true;
        }
        else
        {
            jugador.gameObject.GetComponent<Animator>().enabled = false;
        }
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
