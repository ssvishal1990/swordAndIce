using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject heavy_attack_prefab;

    [SerializeField] int AttackDmageLight = 1;
    [SerializeField] Transform attackPoint;
    [SerializeField] float attackRange;
    [SerializeField] LayerMask enemyLayers;
    [SerializeField] GameObject heavyAttackLauncher;

    [SerializeField] CoolDownBar heavyAttackCoolDownBar;
    [SerializeField] int maxHeavyAttack = 3;
    int hitCount = 1;

    PlayerAnimations playerAnimations;
    private int currentHeavyAttackSlash = 3;



    private List<GameObject> currentGameObjects;
    void Start()
    {
        heavyAttackCoolDownBar.setMaxValue(maxHeavyAttack);
        heavyAttackCoolDownBar.setCurrentValue(maxHeavyAttack);
        playerAnimations = GetComponent<PlayerAnimations>();
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    public  void HeavyAttack(InputAction.CallbackContext context)
    {
        if (context.started || context.canceled || currentHeavyAttackSlash <=0)
        {
            return;
        }
        // Debug.Log("Creating heavy attack Object");
        // Instantiate(heavy_attack_prefab, heavyAttackLauncher.transform);
        Debug.Log(currentHeavyAttackSlash);
        playerAnimations.setHeavyAttackTrigger();
        currentHeavyAttackSlash--;
        heavyAttackCoolDownBar.setCurrentValue(currentHeavyAttackSlash);

        Instantiate(heavy_attack_prefab, heavyAttackLauncher.transform.position, heavyAttackLauncher.transform.rotation);

    }

    public void increasecurrentHeavyAttackSlash(){
        currentHeavyAttackSlash++;
        heavyAttackCoolDownBar.setCurrentValue(currentHeavyAttackSlash);
    }

    public void performLightAttack(InputAction.CallbackContext context)
    {
        if (context.started || context.canceled)
        {
            return;
        }
        Attack(attackPoint);
        if(hitCount == 3){
            hitCount = 1;
        }

        playerAnimations.setLightAttackCombatAnimation(hitCount);
        hitCount++;
    }

    public  void Attack(Transform attackPoint)
    {
        
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            // Debug.Log("We hit" + enemy.name);
            EnemyHealth enemyHealthComponent =  enemy.gameObject.GetComponent<EnemyHealth>();
            CreateLadderOnDestroy toCreateLadder = enemy.gameObject.GetComponent<CreateLadderOnDestroy>();
            if(enemyHealthComponent != null){
                enemyHealthComponent.takeDamage(AttackDmageLight);
            }else if(toCreateLadder != null){
                toCreateLadder.takeDamge(AttackDmageLight);
            }

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
