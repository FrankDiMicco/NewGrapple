using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{

    LineRenderer lineRenderer;
    SpringJoint2D springJoint;

    GrappleRayCast grappleRayCast;
    RaycastHit2D ray;

    Transform grappleStart;

    void Start()
    {
        grappleRayCast = GetComponentInChildren<GrappleRayCast>();
        lineRenderer = GetComponent<LineRenderer>();
        springJoint = GetComponent<SpringJoint2D>();
        grappleStart = GetComponentInChildren<Transform>();
        lineRenderer.enabled = false;
        
    }


    void Update()
    {
        ray = grappleRayCast.ray;
        if(ray.collider == null)
        {
            lineRenderer.enabled = false;
        }
        else
        {
            //Debug.Log("Grapple to " + ray.collider.name);
            lineRenderer.SetPosition(0, grappleStart.position); //line renderer start point
            lineRenderer.SetPosition(1, ray.point);       // line renderer second point
        }
    }

    //Gets called from PlayerMovementBasics when left mouse is clicked
    public void ShootGrapple()
    {
        lineRenderer.enabled = true;
    }

    public void StopGrapple()
    {
        lineRenderer.enabled = false;
    }
}
