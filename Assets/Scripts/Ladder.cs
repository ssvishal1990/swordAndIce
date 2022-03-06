using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
 TheBoarderPlayerMovements movements;
    bool canClimb = false;
    Rigidbody2D playerBody;
    PlayerAnimations playerAnimations;
    // Start is called before the first frame update
    void Start()
    {
        movements = new TheBoarderPlayerMovements();
        playerAnimations = FindObjectOfType<PlayerAnimations>();
    }

    // Update is called once per frame
    void Update()
    {
        climbIce();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.tag == "Player" && other.name =="Player"){
            canClimb = true;
            // Debug.Log("Player Detected");
            playerBody = other.GetComponent<Rigidbody2D>();
            // playerAnimations.SetClimbingState(canClimb);
        }
    }

    public void climbIce(){
        if(canClimb){
            movements.Player.Enable();
            Vector2 playerDirection = movements.Player.ClimbIce.ReadValue<Vector2>();
            // playerBody.AddForce(new Vector2(1f,10f));
            
            playerBody.velocity = new Vector2(playerBody.velocity.x, 5f * playerDirection.y);
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player"){
            canClimb = false;
            // playerAnimations.SetClimbingState(canClimb);
            // playerBody = other.GetComponent<Rigidbody2D>();
        }
    }
}
