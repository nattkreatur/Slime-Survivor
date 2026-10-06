using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float health = 100f;
    public float speed = 5f;
    private Enemy nearbyEnemy;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }
    void Update()
    {
        //Variabeln direction utgår från 0 men tar input från ifsatsen
        Vector3 direction = Vector3.zero;

        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector3.right;
        } 
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector3.left;
        }
        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector3.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector3.down;
        }
        //normaliserar farten från dubbla inputs hastigheter till en vid ex: A+W
        direction = direction.normalized;
        //Detta ger rörelse
        transform.position += direction * speed * Time.deltaTime;

        //Egenskaper för attack
        ///////////////////////
        if(Input.GetKeyDown(KeyCode.Space) && nearbyEnemy != null)
        {
            nearbyEnemy.TakeDamage(10);
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Jag träffade " + other.gameObject.name);
        if (other.CompareTag("Enemy")){
            nearbyEnemy = other.GetComponent<Enemy>();
        }
        
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            nearbyEnemy = null; 
        }
        
    }

        public void TakeDamage(int damage)
    {
        health -= damage;
        StartCoroutine(DamageFlash());
        Debug.Log("Player HP: " + health);

        if(health <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Game over");
        }
    }

    private IEnumerator DamageFlash()
    {
        spriteRenderer.color = Color.white;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = originalColor;
        
    }

}
