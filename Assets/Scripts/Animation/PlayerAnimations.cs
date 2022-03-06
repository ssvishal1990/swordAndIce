using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    Animator playerAnimator;
    Rigidbody2D playerRB;

    CapsuleCollider2D playerBodyCollider;
    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerRB = GetComponent<Rigidbody2D>();
        playerBodyCollider = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        checkMovementAnimation();
        SetClimbingState();
        checkClimbPaused();
    }

    void checkMovementAnimation(){
        Debug.Log("Inside movement animation");
        if(playerRB.velocity.x != 0 && playerBodyCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))){
            playerAnimator.SetBool("IsRunning",true);
        }else{
            playerAnimator.SetBool("IsRunning",false);
        }
    }

    public void SetClimbingState(){
        // this.climbState = climbState;
        // Debug.Log("Inside Climb State  === " + climbState);
        // playerAnimator.SetBool("isClimbing",climbState);
    
        if(playerBodyCollider.IsTouchingLayers(LayerMask.GetMask("ClimbableIce"))){
            playerAnimator.SetBool("isClimbing",true);
        }else{
            playerAnimator.SetBool("isClimbing",false);
        }
    }

    void checkClimbPaused(){
        if(playerRB.velocity.y <= 0 && playerBodyCollider.IsTouchingLayers(LayerMask.GetMask("ClimbableIce"))){
            playerAnimator.SetBool("climbPause",true);
        }else{
            playerAnimator.SetBool("climbPause",false);
        }
    }

    public void setLightAttackCombatAnimation(int hitCounter){
        playerAnimator.SetInteger("LightAttackHit", hitCounter);
        playerAnimator.SetBool("noAttack",false);
        StartCoroutine(setNoAttack());
    }

    IEnumerator setNoAttack(){
        yield return new WaitForSecondsRealtime(2);
        playerAnimator.SetBool("noAttack",true);
        playerAnimator.SetInteger("LightAttackHit", -1);
    }
}
