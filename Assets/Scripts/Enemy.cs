using JetBrains.Annotations;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 30;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Slime HP: " + health);
    }
}
