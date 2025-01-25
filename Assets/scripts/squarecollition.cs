using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareCollision : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float moveSpeed = 5f;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.velocity = movement * moveSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            Debug.Log("Colisión con el obstáculo");
            // Aquí puedes añadir cualquier lógica adicional que quieras al chocar con el obstáculo
        }
    }
}
