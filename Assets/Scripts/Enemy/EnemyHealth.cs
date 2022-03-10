using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int health = 20;
    [SerializeField] HealthBar hpbar;
    private PlayerAttack pttack;
    // Start is called before the first frame update
    void Start()
    {
        pttack = FindObjectOfType<PlayerAttack>();
        hpbar.setMaxHealth(health);
        
    }

    // Update is called once per frame
    void Update()
    {
        checkHealth();
    }

    void checkHealth(){
        if(health <= 0){
            GameSessionController gameSessionController = FindObjectOfType<GameSessionController>();
            gameSessionController.increementScore(100);
            Destroy(gameObject);
        }
    }

    public void  takeDamage(int damageValue){
        Debug.Log("taking hit damage");
        health -= damageValue;
        updateHealthBar();
    }

    void updateHealthBar(){
        hpbar.setHealth(health);
    }
}
