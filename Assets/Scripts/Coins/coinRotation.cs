using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinRotation : MonoBehaviour
{
    [SerializeField] float updateByValue = 10f;


    void Update()
    {
        rotateCoin();
    }



    private void rotateCoin()
    {
        
        Quaternion initialRotationQuaternion = transform.rotation; // Get initial rotation x, y, z ,w 
        Vector3 eulerangle = initialRotationQuaternion.eulerAngles; // get vector 3 representation
        eulerangle.y += updateByValue; // update y axis
        initialRotationQuaternion.eulerAngles = eulerangle; // this will overall create the new rotation in 4vector form 
        transform.rotation = initialRotationQuaternion; // assign the new vectory to game object      
    }
}
