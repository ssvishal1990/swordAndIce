using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurn : MonoBehaviour
{
    GameObject mainEnemyBodyObject;
    Rigidbody2D enemyRigidBody; 

    Transform[] listOfParentObjects;

    [SerializeField] Vector2 moveValue;
    private void Start()
    {
        GetMainEnemyBody();
        enemyRigidBody = mainEnemyBodyObject.GetComponent<Rigidbody2D>();
    }

    private void GetMainEnemyBody()
    {
        mainEnemyBodyObject = gameObject.GetComponentInParent<Transform>().gameObject;
        listOfParentObjects = gameObject.GetComponentsInParent<Transform>();
        foreach (Transform t in listOfParentObjects)
        {
            if (t.gameObject.tag == "Enemies")
            {
                mainEnemyBodyObject = t.gameObject;
                break;
            }
        }
    }

    private void Update()
    {
        Move();
    }

    private void Move(){
        enemyRigidBody.velocity = moveValue;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Ground"){
            Debug.Log("Ground exit detected");
            moveValue.x *= -1;
            Vector3 enemyLocalScale = mainEnemyBodyObject.transform.localScale;
            enemyLocalScale.x *= -1;
            mainEnemyBodyObject.transform.localScale = enemyLocalScale; 
        }
    }
}
