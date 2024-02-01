using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 20;
    bool canAttack = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Attack();
        }
    }

    public async void Attack()
    {
        if (canAttack)
        {
            canAttack = false;
            // Play an attack animation
            animator.SetTrigger("Attack");

            await Task.Delay(200);

            // Detect enemies in range of attack
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

            // Damage them
            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<Health>().TakeDamage(attackDamage);
            }
            await Task.Delay(200);
            canAttack = true;
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
