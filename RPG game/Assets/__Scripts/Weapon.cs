using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform shootPoint;
    public Animator animator;
    public int damage = 20;
    public LineRenderer lineRenderer;

    void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
		{
			StartCoroutine(Shoot());
		}
	}
    IEnumerator Shoot()
    {
        animator.SetTrigger("RangedAttack");
        
        
        RaycastHit2D hitEnemies = Physics2D.Raycast(shootPoint.position, -shootPoint.right);

        if (hitEnemies)
        {
            EnemyHealth enemy = hitEnemies.transform.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            lineRenderer.SetPosition(0,shootPoint.position);
            lineRenderer.SetPosition(1,hitEnemies.point);
        } else {
            lineRenderer.SetPosition(0, shootPoint.position);
			lineRenderer.SetPosition(1, (Vector2)shootPoint.position + -(Vector2)shootPoint.right * 100);
        }
        lineRenderer.enabled = true;

		yield return new WaitForSeconds(0.02f);

		lineRenderer.enabled = false;
    }
}
