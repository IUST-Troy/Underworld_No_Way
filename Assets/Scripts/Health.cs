using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("Hurt");

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
        if (GetComponent<Rigidbody2D>() != null)
            GetComponent<Rigidbody2D>().gravityScale = 0;
        this.enabled = false;
    }
}
