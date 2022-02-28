using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHeavyAttackObject : MonoBehaviour
{
    // Start is called before the first frame update
    public int heayAttackDamage = 3;
    [SerializeField] float slashSpeed = 1f;
    [SerializeField] float waitBeforeDestroy = 0.05f;
    Rigidbody2D heavyAttackRigidBody;

    float speedOnX;
    Vector2 forceOnX;
    GameObject currentAttackSlash;
    void Start()
    {
        LaunchTheHeavyAttack();
    }

    // Update is called once per frame
    void Update()
    {
        ApplyVelocityOnSlash();
    }



    private void LaunchTheHeavyAttack()
    {
        heavyAttackRigidBody = gameObject.GetComponent<Rigidbody2D>();
        PlayerAttack pattack = FindObjectOfType<PlayerAttack>();
        speedOnX = pattack.transform.localScale.x * slashSpeed;
        forceOnX = new Vector2(speedOnX, 0f);
        heavyAttackRigidBody.velocity = forceOnX;
    }

    private void ApplyVelocityOnSlash(){
        forceOnX = new Vector2(speedOnX, 0f);
        heavyAttackRigidBody.velocity = forceOnX;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enemies"){
            EnemyHealth enemy = other.gameObject.GetComponent<EnemyHealth>();
            enemy.takeDamage(heayAttackDamage);
            StartCoroutine(pushAfterHitThenDestroy());
        }else{
            if(other.gameObject.tag != "Player"){
                Destroy(gameObject);
            }
        }
        
    }

    IEnumerator pushAfterHitThenDestroy(){
        yield return new WaitForSecondsRealtime(waitBeforeDestroy);
        Destroy(gameObject);
    }
}
