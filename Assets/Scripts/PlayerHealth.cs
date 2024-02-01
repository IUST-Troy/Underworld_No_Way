using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Animator animator;
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("Hurt");
        healthBar.SetHealth(currentHealth);

        // play hurt animation
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        // Die animation 
        animator.SetTrigger("Death");

        // Disable the enemy
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().gravityScale = 0;
        this.enabled = false;
    }
}
