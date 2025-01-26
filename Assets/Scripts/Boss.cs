using UnityEngine;

public class Boss : MonoBehaviour
{
    public float speed = 0.1f;
    public GameObject garbagePrefab;
    public float throwForce = 10f;
    public float throwCooldown = 2f;
    public int garbageDamage = 5;
    private Transform playerTransform;
    private Rigidbody2D rb;
    private float nextThrowTime;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        nextThrowTime = 0f;

        // Desactiva el boss al iniciar el juego
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (playerTransform != null)
        {
            Vector2 direction = (playerTransform.position - transform.position).normalized;
            rb.velocity = direction * speed;

            if (direction.x > 0)
                transform.localScale = new Vector3(1, 1, 1);
            else if (direction.x < 0)
                transform.localScale = new Vector3(-1, 1, 1);

            ThrowGarbage();
        }
    }

    void ThrowGarbage()
    {
        if (Time.time >= nextThrowTime)
        {
            Vector2 throwDirection = (playerTransform.position - transform.position).normalized;
            GameObject garbage = Instantiate(garbagePrefab, transform.position, Quaternion.identity);
            garbage.transform.localScale = new Vector3(0.5f, 0.5f, 0);
            Rigidbody2D garbageRb = garbage.GetComponent<Rigidbody2D>();
            garbageRb.AddForce(throwDirection * throwForce, ForceMode2D.Impulse);

            nextThrowTime = Time.time + throwCooldown;
        }
    }
}
