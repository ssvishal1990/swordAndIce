using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthSystem : MonoBehaviour
{
    [SerializeField] int playerMaxHealth = 10;
    public int currentHealth;
    [SerializeField] HealthBar playerHealthSystem;

    bool healthRegenRequired = false;
    int initialHealthRegenDelay = 4;
    // Start is called before the first frame update
    void Start()
    {
        playerMaxHealth = 10;
        currentHealth = playerMaxHealth;
        playerHealthSystem.setMaxHealth(currentHealth);
        playerHealthSystem.setHealth(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        checkHealth();
    }

    public void checkHealth(){
        if(healthRegenRequired){
            StartCoroutine(healReqUpdate(initialHealthRegenDelay));
            healthRegenRequired = false;
        }
        if(currentHealth > playerMaxHealth){
            currentHealth = playerMaxHealth;
        }
        if(currentHealth <= 0){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public void onDamage(int damageValue){
        currentHealth -= damageValue;
        playerHealthSystem.setHealth(currentHealth);
        healthRegenRequired = true;
        // StartCoroutine(healReqUpdate(initialHealthRegenDelay));
    }

    void RegenerateHealth(){
        currentHealth += 1;
        playerHealthSystem.setHealth(currentHealth);
        if(currentHealth == playerMaxHealth){
            healthRegenRequired = false;
        }

    }
    // IEnumerator healReqUpdate(int delayBeforeRegen){
    //     if(currentHealth >= playerMaxHealth){
    //         yield return new WaitForEndOfFrame();
    //     }else{
    //         yield return new WaitForSecondsRealtime(delayBeforeRegen);
    //         currentHealth += 1;
    //         playerHealthSystem.setHealth(currentHealth);
    //         // StartCoroutine(healReqUpdate(1));
    //     }    
    // }

    
    IEnumerator healReqUpdate(int delayBeforeRegen){
        yield return new WaitForSecondsRealtime(delayBeforeRegen);
        while(currentHealth < playerMaxHealth){
            currentHealth++;
            playerHealthSystem.setHealth(currentHealth);
            yield return new WaitForSecondsRealtime(1);
        }
    }
}
