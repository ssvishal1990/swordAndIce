using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShaderLaser : MonoBehaviour
{
    public Camera camera;
    public LineRenderer lineRenderer;
    public Transform firePoint;

    public Transform gunPosition;

    bool constantLaserPositionUpdate = false; 

    private Quaternion rotation;

    public ParticleSystem startPsystem;
    public ParticleSystem endPsystem;

    TheBoarderPlayerMovements controlLaser;
    // Start is called before the first frame update
    void Start()
    {
        controlLaser = new TheBoarderPlayerMovements();
        lineRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLaser();
    }

    void EnableLaser(){
        lineRenderer.enabled = true;
        constantLaserPositionUpdate = true;
        startPsystem.Play();
        endPsystem.Play();
    }

    void UpdateLaser(){
        if(!constantLaserPositionUpdate){
            return ;
        }
        Vector2 mousePotion = (Vector2)camera.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        lineRenderer.SetPosition(0, firePoint.position);

        lineRenderer.SetPosition(1, mousePotion);

        rotateToMouse();

        Vector2 direction = camera.ScreenToWorldPoint(Mouse.current.position.ReadValue()) - gunPosition.position;
        RaycastHit2D hit = Physics2D.Raycast((Vector2)gunPosition.position, direction.normalized, direction.magnitude);

        if(hit){
            lineRenderer.SetPosition(1, hit.point);
        }
    }
    void DisableLaser(){
        lineRenderer.enabled = false;
        constantLaserPositionUpdate = false;
        startPsystem.Stop();
        endPsystem.Stop();
    }

    public void FireLaser(InputAction.CallbackContext context){
        if(context.started){
            EnableLaser();
        }else if(context.canceled){
            DisableLaser();
        }
    }

    void rotateToMouse(){
        Vector2 direction = camera.ScreenToWorldPoint(Mouse.current.position.ReadValue()) - gunPosition.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rotation.eulerAngles= new Vector3(0,0, angle);
        // transform.rotation = rotation;
        gunPosition.rotation = rotation;
    }
}
