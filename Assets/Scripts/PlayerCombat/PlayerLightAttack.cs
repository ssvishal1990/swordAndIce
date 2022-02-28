using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Tutorial Script not in use
public class PlayerLightAttack : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform attackPoint;
    [SerializeField] float attackRange;
    [SerializeField] LayerMask enemyLayers;
    [SerializeField] int AttackDmageLight = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] hitEnemies =  Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach(Collider2D enemy in hitEnemies){
            Debug.Log("We hit" + enemy.name);
            enemy.gameObject.GetComponent<EnemyHealth>().takeDamage(AttackDmageLight);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if(attackPoint == null){
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);    
    }
}
