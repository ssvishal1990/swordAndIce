using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLadderOnDestroy : MonoBehaviour
{
    [SerializeField] GameObject ladderPrefab;
    [SerializeField] int objectHealth = 3;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        onDestroyed();
    }

    private void onDestroyed(){
        if(objectHealth > 0){
            return;
        }
        Transform ladderPosition = transform;
        Vector3  LadderPositionVector = ladderPosition.position;
        LadderPositionVector.y += 6f;
        GameObject sessionObject = GameObject.FindGameObjectWithTag("ScenePersist");
        ladderPosition.position = LadderPositionVector;
        Instantiate(ladderPrefab, ladderPosition.position, transform.rotation, sessionObject.transform);
        // Instantiate(ladderPrefab, ladderPosition.position, transform.rotation);
        Destroy(gameObject);
    }
    public void takeDamge(int damageValue){
        objectHealth -= damageValue;
    }


}
