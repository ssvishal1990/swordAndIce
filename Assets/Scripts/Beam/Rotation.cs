using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Rotation : MonoBehaviour
{
    [SerializeField] private Transform muzzlePositionForDown;
    [SerializeField] private Transform muzzlePositionForUp;
    [SerializeField] private Transform muzzlePositionForLeft;
    [SerializeField] private Transform muzzlePositionForRight;

    [SerializeField] private float updateByValue = 50f;
    [SerializeField] LineRenderer laserEmitterDown;
    [SerializeField] LineRenderer laserEmitterUp;
    [SerializeField] LineRenderer laserEmitterLeft;
    [SerializeField] LineRenderer laserEmitterRight;
    Rigidbody2D lookAtObjectRigidBody;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // laserEmitterDown.gameObject.transform
        rotateLaserEmitterBody();
        DrawLaserTrap(0f, -50f, laserEmitterDown, laserEmitterDown.gameObject.transform);
        DrawLaserTrap(0f, 50f, laserEmitterUp, muzzlePositionForUp);
        DrawLaserTrap(50f, 0f, laserEmitterRight, muzzlePositionForRight);
        DrawLaserTrap(-50f, 0f, laserEmitterLeft, muzzlePositionForLeft);
    }

    private void DrawLaserTrap(float x, float y, LineRenderer lr, Transform directionalStartingPoint)
    {
        lr.SetPosition(0, directionalStartingPoint.position);
        Vector3 newPoint = directionalStartingPoint.position;
        newPoint.y += y;
        newPoint.x += x;
        lr.SetPosition(1, newPoint);
    }
    

    private void rotateLaserEmitterBody()
    {
        Quaternion initialRotationQuaternion = transform.rotation; // Get initial rotation x, y, z ,w 
        Vector3 eulerangle = initialRotationQuaternion.eulerAngles; // get vector 3 representation
        eulerangle.z += updateByValue; // update z axis
        initialRotationQuaternion.eulerAngles = eulerangle; // this will overall create the new rotation in 4vector form 
        transform.rotation = initialRotationQuaternion; // assign the new vectory to game object
    }

}
