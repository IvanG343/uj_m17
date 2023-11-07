using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Star : MonoBehaviour
{
    [SerializeField] private float damage;

    private Health health;

    private void Start()
    {
        health = GetComponent<Health>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }

    private void Update()
    {
        if(health.currentHealth <= 0)
        {
            //Invoke("removeEnemy", 3);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    private void removeEnemy()
    {
        Destroy(gameObject);
    }
}
