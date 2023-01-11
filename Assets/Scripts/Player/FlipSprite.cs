using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipSprite : MonoBehaviour
{
    //To get moveinput vector2 from PlayerMovementBasic Script
    PlayerMovementBasic playerMovementBasic;

    //To flip spriteRenderer
    SpriteRenderer spriteRenderer;



    // Start is called before the first frame update
    void Start()
    {
        playerMovementBasic = GetComponent<PlayerMovementBasic>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if(playerMovementBasic.moveInput.x>0)
        {
            //walking right

           Vector3 flipRight = new Vector3(1f, 1f, 1f);
           transform.localScale = flipRight;
           // spriteRenderer.flipX = false;
        }
        if(playerMovementBasic.moveInput.x<0)
        {
            //walking left

           // spriteRenderer.flipX = true;
           Vector3 flipLeft = new Vector3(-1f, 1f, 1f);
           transform.localScale = flipLeft;
        }
    }
}
