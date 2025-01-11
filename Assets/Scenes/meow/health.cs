using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    [SerializeField] int pHealth = 100;

    private int currentHealth;

    public int damage = 10;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = pHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            health playerHealth = collision.gameObject.GetComponent<health>();
            if (playerHealth != null)
            { 
                playerHealth.TakeDamage(damage);
            }
        }
    }
}
