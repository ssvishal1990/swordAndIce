using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurn : MonoBehaviour
{

    Rigidbody2D enemyRigidBody; 

    Transform[] listOfParentObjects;
    [SerializeField] GameObject mainEnemyBodyObject;

    [SerializeField] Vector2 moveValue;
    [SerializeField] List<string> turnWhenCollidingWithObjectTags =  new List<string>();
    private void Start()
    {
        // GetMainEnemyBody();
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("On trigger enter detected" + other.tag + "  " + other.name);
        if(turnWhenCollidingWithObjectTags.Contains(other.tag)){
            FlipEnemy();
        }
    }
    private void Move(){
        enemyRigidBody.velocity = moveValue;
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        // Debug.Log("Detected Trigger Exit == " + other.tag);
        if(other.tag == "Ground")
        {
            FlipEnemy();
        }
    }

    private void FlipEnemy()
    {
        moveValue.x *= -1;
        Vector3 enemyLocalScale = mainEnemyBodyObject.transform.localScale;
        enemyLocalScale.x *= -1;
        mainEnemyBodyObject.transform.localScale = enemyLocalScale;
    }
}
