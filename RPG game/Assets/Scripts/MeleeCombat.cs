using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J)){
            Attack();
        }
    }

    void Attack(){
        animator.SetTrigger("MeleeAttack");

        

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange,enemyLayer);

        foreach (Collider2D item in hitEnemies)
        {
            Debug.Log("hit");
        }
    }

    void OnGizmosSelected(){
        if (attackRange == null){
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position,attackRange);
    }
}
