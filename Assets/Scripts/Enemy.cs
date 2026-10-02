using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 30;
    public float speed = 2f;
    private bool isKnockedBack = false;
    public float knockbackForce = 1f;
    private Rigidbody2D rb;
    public PlayerMovement player; //Referens playermovement-komponenten/scriptet

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (!isKnockedBack)
        {
            Vector2 direction = player.transform.position - transform.position;
            direction = direction.normalized;
            rb.linearVelocity = direction * speed;
        }
        
    }
    
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Slime HP: " + health);

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Spelar tar DMG " + other.gameObject.name);
        if (other.CompareTag("Player")){
            player.TakeDamage(10);
            Vector3 knockbackDirection = transform.position - player.transform.position;
            knockbackDirection = knockbackDirection.normalized;
            isKnockedBack = true;
            rb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
        }
        
    }

}
