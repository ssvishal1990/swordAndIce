using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject heavy_attack_prefab;
    [SerializeField] float waitBeforeDestroy = 1f;
    [SerializeField] float forceOnX = 5f;

    [SerializeField] int AttackDmageLight = 1;
    [SerializeField] int AttackDmageHeavy = 2;
    [SerializeField] Transform attackPoint;
    [SerializeField] float attackRange;
    [SerializeField] LayerMask enemyLayers;
    [SerializeField] GameObject heavyAttackLauncher;



    private List<GameObject> currentGameObjects;
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Create a range attack object
    // Launch that range attack
    // check if that range attack collides with enemy
    // On collision do damage and destroy heavy attack object
    public  void HeavyAttack(InputAction.CallbackContext context)
    {
        if (context.started || context.canceled)
        {
            return;
        }
        Debug.Log("Creating heavy attack Object");
        // Instantiate(heavy_attack_prefab, heavyAttackLauncher.transform);
        Instantiate(heavy_attack_prefab, heavyAttackLauncher.transform.position, heavyAttackLauncher.transform.rotation);

    }

    public void performLightAttack(InputAction.CallbackContext context)
    {
        if (context.started || context.canceled)
        {
            return;
        }
        Attack(attackPoint);
    }

    public  void Attack(Transform attackPoint)
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
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
