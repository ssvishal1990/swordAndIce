using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthSystem : MonoBehaviour
{
    int playerMaxHealth;
    int currentHealth;
    [SerializeField] HealthBar playerHealthSystem;
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
        if(currentHealth <= 0){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public void onDamage(int damageValue){
        currentHealth -= damageValue;
        playerHealthSystem.setHealth(currentHealth);
    }
}
