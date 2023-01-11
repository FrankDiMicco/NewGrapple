using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{

    LineRenderer lineRenderer;
    GrappleRayCast grappleRayCast;
    RaycastHit2D ray;

    void Start()
    {
        grappleRayCast = GetComponentInChildren<GrappleRayCast>();
        lineRenderer = GetComponent<LineRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        ray = grappleRayCast.ray;
        if(ray.collider != null)
        {
            Debug.Log("Grapple to " + ray.collider.name);
        }
    }
}
