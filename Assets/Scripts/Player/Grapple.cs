using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{

    bool isGrappling = false;
    
    LineRenderer lineRenderer;
    SpringJoint2D springJoint;

    GrappleRayCast grappleRayCast; //To get RayCast2D data from GrappleRayCast script
    RaycastHit2D ray; //To store RayCast2D data from GrappleRayCast script

    Transform grappleStart; //To get position of starting point (near hand) of grapple rope

    void Start()
    {
        grappleRayCast = GetComponentInChildren<GrappleRayCast>();
        lineRenderer = GetComponent<LineRenderer>();
        springJoint = GetComponent<SpringJoint2D>();
        grappleStart = GetComponentInChildren<Transform>();
        lineRenderer.enabled = false;
        springJoint.enabled = false;

        
    }


    void Update()
    {
        ray = grappleRayCast.ray;
        lineRenderer.SetPosition(0, grappleStart.position); //line renderer start point





 //           if(hit.distance<lengthOfRope){
 //               playerSpringJoint.distance = hit.distance;  //if grapple distance is to playform, make rope short
 //           } else{
//                playerSpringJoint.distance = lengthOfRope;  //make distance joint length to full length of rope
 //           }


    }

    //Gets called from PlayerMovementBasics when left mouse is clicked
    public void ShootGrapple(RaycastHit2D ray)
    {
        if(isGrappling == false && ray.collider != null)
        {
            lineRenderer.SetPosition(1, ray.point);       // line renderer second point
            lineRenderer.enabled = true; 
            springJoint.enabled = true;
            springJoint.connectedBody = GameObject.Find(ray.collider.name).GetComponent<Rigidbody2D>();
            springJoint.anchor = transform.position;
            isGrappling = true;
        }



    }

    public void StopGrapple()
    {
        lineRenderer.enabled = false;
        springJoint.enabled = false;
        isGrappling = false;
    }
}
