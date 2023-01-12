using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GrappleRayCast : MonoBehaviour
{
    //*******************This script is a component to RayPoint, a child of Player*******************************

    public float rayCastLength = 100f;

    public RaycastHit2D ray;
    Vector3 mousePosition; //position of the mouse
    Vector3 worldPosition; //mousePosition converted to worldPosition format
    LayerMask groundLayer; //Used in Raycast to only register hits with the ground layer


    private void Start() {
        groundLayer = LayerMask.GetMask("Ground");
    }


    void Update()
    {
        mousePosition = Mouse.current.position.ReadValue(); // gets mouse cursor coordinates
        worldPosition = Camera.main.ScreenToWorldPoint(mousePosition); // converts mouse coordinates to world point coordinates vector3
        ray = Physics2D.Raycast(transform.position, worldPosition - transform.position, rayCastLength, groundLayer); //cast ray in direction of mouse

       // Debug.DrawRay(transform.position, worldPosition - transform.position, Color.green, 1.5f);
       
    }
}
