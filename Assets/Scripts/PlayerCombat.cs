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
    private int attackDamage;
    private int heavyAttackDamage;
    private int ultimateDamage;
    public int baseDamage= 20;
    bool canAttack = true;
    bool canHeavyAttack = true;
    bool canUseUltimate = true;

    void Start(){
        var multiplier = PlayerPrefs.GetFloat("AMP");
        Debug.Log(multiplier);
        attackDamage = (int) (baseDamage*multiplier);
        Debug.Log($"AttackDMG: {attackDamage}");
        heavyAttackDamage = 2 * attackDamage;
        ultimateDamage = 10 * attackDamage;
    }
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
                if (enemy.GetComponent<EnemyHealth>()  != null){
                    Debug.Log(attackDamage);
                    enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);}
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
                enemy.GetComponent<EnemyHealth>().TakeDamage(heavyAttackDamage);
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
                enemy.GetComponent<EnemyHealth>().TakeDamage(ultimateDamage);
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
