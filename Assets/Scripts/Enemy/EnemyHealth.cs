using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int health = 10;
    private PlayerAttack pttack;
    // Start is called before the first frame update
    void Start()
    {
        pttack = FindObjectOfType<PlayerAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        checkHealth();
    }

    void checkHealth(){
        if(health <= 0){
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D attack)
    {
        Debug.Log(attack.collider);
        if(attack.gameObject.tag == "HeavyAttack"){
            Destroy(attack.gameObject);
            health -= pttack.getHitValue(attack.gameObject.tag);
            Debug.Log(health);
        }
        
    }

    public void  takeLightHitDamage(int damageValue){
        Debug.Log("taking light hit damage");
        health -= damageValue;
    }
}
