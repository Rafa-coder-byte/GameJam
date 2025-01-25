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
        // Obtener la entrada del jugador (teclas W, A, S, D o flechas)
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) 
        {
            jugador.gameObject.transform.localScale = new Vector3(0.75f,0.75f,1);
        }
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) 
        {
            jugador.gameObject.transform.localScale = new Vector3(-0.75f,0.75f,1);
        }
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

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
