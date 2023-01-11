using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GrappleRayCast : MonoBehaviour
{
    RaycastHit2D ray;
    Vector3 mousePosition; //position of mouse
    Vector3 worldPosition; //mousePosition converted to worldPosition format


    void Start()
    {
        Ray2D ray2 = new Ray2D(transform.position, transform.forward);

    }


    void Update()
    {
        //    worldPos = mainCam.ScreenToWorldPoint(Mouse.current.position);

        mousePosition = Mouse.current.position.ReadValue(); // gets mouse cursor coordinates
        worldPosition = Camera.main.ScreenToWorldPoint(mousePosition); // converts mouse coordinates to world point coordinates vector3
        ray = Physics2D.Raycast(transform.position, worldPosition - transform.position, 10f); //cast ray in direction of mouse

        //Debug.DrawRay(ray.origin, ray.direction* 100, Color.green, 100f);
    if(ray.collider != null)
    {
        Debug.Log(ray.collider.name);
    }

        //Debug.Log(worldPosition - transform.position);
    }
}
