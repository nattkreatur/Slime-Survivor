using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
public float speed = 5f;

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
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Jag träffade " + other.gameObject.name);
        Enemy enemy = other.GetComponent<Enemy>();
        enemy.TakeDamage(10);
    }
}
