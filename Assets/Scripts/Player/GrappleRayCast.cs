using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GrappleRayCast : MonoBehaviour
{
    //This script is a component to RayPoint, a child of Player

    public RaycastHit2D ray;
    Vector3 mousePosition; //position of mouse
    Vector3 worldPosition; //mousePosition converted to worldPosition format

    void Update()
    {

        mousePosition = Mouse.current.position.ReadValue(); // gets mouse cursor coordinates
        worldPosition = Camera.main.ScreenToWorldPoint(mousePosition); // converts mouse coordinates to world point coordinates vector3
        ray = Physics2D.Raycast(transform.position, worldPosition - transform.position, 10f); //cast ray in direction of mouse

       //Vector3 forward = transform.TransformDirection(Vector3.forward) * 100;
       //Debug.DrawRay(transform.position, forward, Color.green, 1000f);
       

    }
}
