using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationLogic : MonoBehaviour
{

    PlayerMovementBasic playerMovementBasic;
    Animator animator;


    void Start()
    {
        playerMovementBasic = GetComponent<PlayerMovementBasic>(); 
        animator = GetComponent<Animator>();  
    }

    void Update()
    {
        if(playerMovementBasic.moveInput.x > 0 || playerMovementBasic.moveInput.x < 0){
            animator.SetBool("isRunning", true);
        } 
        else{
            animator.SetBool("isRunning", false);
        }

        if(playerMovementBasic.GroundCheck())
        {
            animator.SetBool("isJumping", false);
        }
        else
        {
            animator.SetBool("isJumping", true);
        }
        
    }


}
