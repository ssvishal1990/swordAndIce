using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using Cinemachine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D playerRgBd;
    TheBoarderPlayerMovements movements;
    CapsuleCollider2D playerBody;
    
    bool facingRight = true;
    [SerializeField] float x_axis_move_speed = 1f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] float screex_value_left = 0.8f;
    [SerializeField] float screex_value_right = 0.2f; 

    [SerializeField] float y_axis = 5f;

    [SerializeField] private float slopeCheckDistance = 0.5f;

    [SerializeField] GameObject slopeChecker;

    PlayerHealthSystem playerHealthSystem;

    private bool isOnSlope = false;

    private float slopeDownAngleOld;

    Vector2 capsuleColliderSize ;

    private float slopeDownAngle;
    private Vector2 slopeNormalPerpendicular;

    Vector2 moveInput;
    // Start is called before the first frame update
    private void Awake()
    {
        playerHealthSystem = GetComponent<PlayerHealthSystem>();
        playerRgBd = GetComponent<Rigidbody2D>();
        movements = new TheBoarderPlayerMovements();
        playerBody = GetComponent<CapsuleCollider2D>();
        capsuleColliderSize = slopeChecker.GetComponent<CapsuleCollider2D>().size;
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Move();
        slopeCheck();
        playerDeath();
    }

    private void Move()
    {
        movements.Player.Enable();
        Vector2 playerDirection = movements.Player.Movement.ReadValue<Vector2>();
        float xspeed = playerDirection.x * x_axis_move_speed;
        Vector2 newForce = (new Vector2(xspeed, playerRgBd.velocity.y ));
        Debug.Log(newForce);
        playerRgBd.AddForce(newForce);

        // playerRgBd.velocity = new Vector2(xspeed, playerRgBd.velocity.y *  slopeNormalPerpendicular.y);

   

        // if(playerBody.IsTouchingLayers(LayerMask.GetMask("Ground")) && !isOnSlope){
        //     playerRgBd.AddForce(new Vector2(xspeed, playerRgBd.velocity.y));
        // }else if(playerBody.IsTouchingLayers(LayerMask.GetMask("Ground")) && isOnSlope){
        //     // playerRgBd.velocity =  new Vector2(playerDirection.x * x_axis_move_speed * slopeNormalPerpendicular.x * -1, playerRgBd.velocity.y * slopeNormalPerpendicular.y * -1);
        //      playerRgBd.AddForce(new Vector2(playerDirection.x * x_axis_move_speed * slopeNormalPerpendicular.x * -1, playerRgBd.velocity.y * slopeNormalPerpendicular.y * -1));
        // }else if(!playerBody.IsTouchingLayers(LayerMask.GetMask("Ground"))){
        //     playerRgBd.velocity =  new Vector2(playerDirection.x * x_axis_move_speed, playerRgBd.velocity.y);
        // }


        if(xspeed<0 && facingRight){
            flipSprite();
        }else if(xspeed > 0 && !facingRight){
            flipSprite();
        }
    }

    private void slopeCheck(){
        Vector2 checkPos = transform.position - new Vector3(0.0f, capsuleColliderSize.y/2);
        slopeCheckVertical(checkPos);
    }

    private void slopeCheckHorizontal(Vector2 checkPosition){

    }

    private void slopeCheckVertical(Vector2 checkPosition){
        RaycastHit2D hit = Physics2D.Raycast(checkPosition, Vector2.down, slopeCheckDistance, LayerMask.GetMask("Ground"));
        if(hit){

            slopeNormalPerpendicular = Vector2.Perpendicular(hit.normal).normalized;
            slopeDownAngle = Vector2.Angle(hit.normal, Vector2.up);

            if(slopeDownAngle != slopeDownAngleOld){
                 isOnSlope = true;
            }

            slopeDownAngleOld = slopeDownAngle;
            Debug.Log("is on slope --> " +isOnSlope);
            Debug.DrawRay(hit.point, slopeNormalPerpendicular, Color.red);
            Debug.DrawRay(hit.point, hit.normal, Color.green);
            Debug.Log(hit.point + " " +hit.normal + " " +hit.collider.gameObject.tag  + " " + slopeDownAngle);
        }
    }


    public void Jump(InputAction.CallbackContext context){
        
        if(context.performed && playerBody.IsTouchingLayers(LayerMask.GetMask("Platform","Ground", "ClimbableIce"))){
            // Debug.Log("Jump " + context);
            playerRgBd.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            
        }
    }
    

    void flipSprite(){
        transform.localScale = new Vector3(-1 * transform.localScale.x, transform.localScale.y, transform.localScale.z);
        facingRight = !facingRight;
        UpdateCamera updateCamera = gameObject.GetComponent<UpdateCamera>();
        if(facingRight){
            updateCamera.UpdateDirection(screex_value_right);
        }else{
            updateCamera.UpdateDirection(screex_value_left);
        }
        
    }

    void playerDeath(){
        if(playerBody.IsTouchingLayers(LayerMask.GetMask("Hazard"))){
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            playerHealthSystem.playerDeath();
        }
    }



}
