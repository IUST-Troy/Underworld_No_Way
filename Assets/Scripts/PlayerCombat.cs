using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public Transform heavyAttackPoint;
    public Transform ultimatePoint;
    public float attackRange = 0.5f;
    public float heavyAttackRange = 1.0f;
    public float ultimateRange = 20f;
    public LayerMask enemyLayers;
    public int attackDamage = 20;
    public int heavyAttackDamage = 40;
    public int ultimateDamage = 400;
    bool canAttack = true;
    bool canHeavyAttack = true;
    bool canUseUltimate = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Attack();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            UltimateAttack();
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            HeavyAttack();
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
                if (enemy.GetComponent<Health>()  != null)
                    enemy.GetComponent<Health>().TakeDamage(attackDamage);
                else
                    enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
            }
            await Task.Delay(200);
            canAttack = true;
        }
    }

    public async void HeavyAttack()
    {
        if (canHeavyAttack)
        {
            canHeavyAttack = false;
            // Play an attack animation
            animator.SetTrigger("HeavyAttack");

            await Task.Delay(500);

            // Detect enemies in range of attack
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, heavyAttackRange, enemyLayers);

            // Damage them
            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<Health>().TakeDamage(heavyAttackDamage);
            }
            await Task.Delay(500);
            canHeavyAttack = true;
        }
    }

    public async void UltimateAttack()
    {
        if (canUseUltimate)
        {
            canUseUltimate = false;

            animator.SetTrigger("Recover");

            await Task.Delay(1000);

            // Detect enemies in range of attack
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(ultimatePoint.position, ultimateRange, enemyLayers);

            // Damage them
            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<Health>().TakeDamage(ultimateDamage);
            }
            await Task.Delay(100);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);

        if (ultimatePoint == null)
            return;

        Gizmos.DrawWireSphere(ultimatePoint.position, ultimateRange);
    }
}
