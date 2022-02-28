using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    int maxHealth = 20;
    int currentHealth = 0;
    int damage = 2;

    public GameObject healthObject;
    [SerializeField] HealthBar healthBar;
    void Start()
    {
        currentHealth = maxHealth;
        HealthBar healthBar = healthObject.GetComponent<HealthBar>();
        healthBar.setMaxHealth(maxHealth);
    }

    public void TakeDamage(InputAction.CallbackContext context){
        if(context.started || context.canceled){
            return;
        }
        currentHealth -= damage;
        healthBar.setHealth(currentHealth);
    }
}
