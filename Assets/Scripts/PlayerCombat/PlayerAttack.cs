using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject heavy_attack_prefab;
    [SerializeField] float waitBeforeDestroy = 3f;
    [SerializeField] float forceOnX = 50f;

    [SerializeField] int AttackDmageLight = 1;
    [SerializeField] int AttackDmageHeavy = 2;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public  void launchHeavyAttack(InputAction.CallbackContext context)
    {
        if (context.started || context.canceled)
        {
            return;
        }
        Debug.Log("heavy Attack launch called");
        GameObject attackObj = createHeavyAttackObject();
        Launch(attackObj);
        StartCoroutine(waitAndDestroy(attackObj));

    }

    // This method will wait for a few seconds and then check if object still exists. If it does then it will destroy it.
    IEnumerator waitAndDestroy(GameObject obj){
        yield return new WaitForSecondsRealtime(waitBeforeDestroy);
        Destroy(obj);
    }

    private void Launch(GameObject attackObj)
    {
        Rigidbody2D heavyAttackObject = attackObj.GetComponent<Rigidbody2D>();
        Vector2 attackForce = new Vector2(heavyAttackObject.velocity.x + 10f, heavyAttackObject.velocity.y);
        heavyAttackObject.AddForce(Vector2.right * forceOnX * transform.localScale.x, ForceMode2D.Impulse);
    }

    GameObject createHeavyAttackObject(){
        GameObject attackObj = Instantiate(heavy_attack_prefab, transform, true);
        Vector3 attackObjectPosition = gameObject.transform.position;
        attackObjectPosition.x += 3f * transform.localScale.x;
        attackObj.transform.position = attackObjectPosition;
        return attackObj;
    }

    public int getHitValue(string attackTag){
        if(attackTag == "HeavyAttack"){
            return AttackDmageHeavy;
        }else{
            return AttackDmageLight;
        }   
    }
}
