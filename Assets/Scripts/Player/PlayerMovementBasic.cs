using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovementBasic : MonoBehaviour
{

//Basic lateral movement and jump.  Uses Input System, and box cast with layerMask
//Must have Jump action in Player Input
//Gravity scale is set to 2 in player ridgedbody
//Enhanced fall (ie increase gravity at top of jump to fall faster) - use fall multiplier
//Variable jump height
//Must add “Press and Release” interaction to “Jump” action in Input Manager

    public Vector2 moveInput;
    Rigidbody2D rb;
    public float fallMultiplier = -0.3f;

    [SerializeField] float moveSpeed = 6;
    [SerializeField] float jumpForce = 12;
    [SerializeField] Vector3 boxSize;
    [SerializeField] float boxOffset;
    [SerializeField] LayerMask layerMask;

    void Start()
    {
         rb = GetComponent<Rigidbody2D>();
    }

    void Update() {

    }

    void FixedUpdate() {
        Walk(); 
        EnhanceJumpFall();
    }

    public void OnMove(InputValue value){
        moveInput = value.Get<Vector2>();
        //Debug.Log(moveInput);
    }

    public bool GroundCheck(){
        if(Physics2D.BoxCast(transform.position, boxSize,0, -transform.up, boxOffset, layerMask))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
   
    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position - transform.up * boxOffset, boxSize);
    }

    void Walk(){
        Vector2 playerVelocity = new Vector2(moveInput.x *moveSpeed, rb.velocity.y);
        rb.velocity = playerVelocity; 
    }

    void OnJump(InputValue value){

        if(GroundCheck())
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }

        if(!GroundCheck() && !value.isPressed && !FallingCheck())
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
        
    }

    void EnhanceJumpFall(){
        if(rb.velocity.y < 0){
            Vector2 temp = rb.velocity;
            temp.y += fallMultiplier;
            rb.velocity = temp;
        }
    }

    bool FallingCheck(){
        if(rb.velocity.y < 0)
        {
            return true;
        }       
        else
        {
            return false;
        }
    }

}
