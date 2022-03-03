using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
 TheBoarderPlayerMovements movements;
    bool canClimb = false;
    Rigidbody2D playerBody;
    // Start is called before the first frame update
    void Start()
    {
        movements = new TheBoarderPlayerMovements();
    }

    // Update is called once per frame
    void Update()
    {
        climbIce();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Player Detected");
        if(other.tag == "Player" && other.name =="Player"){
            canClimb = true;
            playerBody = other.GetComponent<Rigidbody2D>();
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
            // playerBody = other.GetComponent<Rigidbody2D>();
        }
    }
}
