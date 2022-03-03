using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D playerRgBd;
    TheBoarderPlayerMovements movements;
    CapsuleCollider2D playerBody;
    
    bool facingRight = true;
    [SerializeField] float x_axis_move_speed = 1f;
    [SerializeField] float jumpForce = 5f;

    Vector2 moveInput;
    // Start is called before the first frame update
    private void Awake()
    {
        playerRgBd = GetComponent<Rigidbody2D>();
        movements = new TheBoarderPlayerMovements();
        playerBody = GetComponent<CapsuleCollider2D>();
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Move();
        playerDeath();
    }

    private void Move()
    {
        movements.Player.Enable();
        Vector2 playerDirection = movements.Player.Movement.ReadValue<Vector2>();
        float xspeed = playerDirection.x * x_axis_move_speed;
        playerRgBd.AddForce(new Vector2(xspeed, playerRgBd.velocity.y));
        if(xspeed<0 && facingRight){
            flipSprite();
        }else if(xspeed > 0 && !facingRight){
            flipSprite();
        }
    }


    public void Jump(InputAction.CallbackContext context){
        // Debug.Log("Jump " + context);
        if(context.performed && playerBody.IsTouchingLayers(LayerMask.GetMask("Platform","Ground", "ClimbableIce"))){
            // Debug.Log("Jump " + context);
            playerRgBd.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            
        }
    }
    

    void flipSprite(){
        transform.localScale = new Vector3(-1 * transform.localScale.x, transform.localScale.y, transform.localScale.z);
        facingRight = !facingRight;
    }

    void playerDeath(){
        if(playerBody.IsTouchingLayers(LayerMask.GetMask("Hazard"))){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }



}
