using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{

    public bool isGrappling = false;
    public float ropeLength = 10f;
    Rigidbody2D rb;
    
    LineRenderer lineRenderer;
    SpringJoint2D springJoint;

    GrappleRayCast grappleRayCast; //To get RayCast2D data from GrappleRayCast script
    RaycastHit2D ray; //To store RayCast2D data from GrappleRayCast script

    Transform grappleStart; //To get position of starting point (near hand) of grapple rope

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        grappleRayCast = GetComponentInChildren<GrappleRayCast>();
        lineRenderer = GetComponent<LineRenderer>();
        springJoint = GetComponent<SpringJoint2D>();
        //grappleStart = GetComponentInChildren<Transform>();
        grappleStart = GameObject.Find("RayPoint").transform;
        lineRenderer.enabled = false;
        springJoint.enabled = false; 
    }

    void Update()
    {
        ray = grappleRayCast.ray;
        lineRenderer.SetPosition(0, grappleStart.position); //line renderer start point to always stay with player


        if(isGrappling)
        {
            rb.gravityScale = 10;
            rb.mass = 100;
        }
        else{
            rb.gravityScale = 2;
        }

 //           if(hit.distance<ropeLength){
 //               springJoint.distance = hit.distance;  //if grapple distance is to playform, make rope short
 //           } else{
//                springJoint.distance = ropeLength;  //make distance joint length to full length of rope
 //           }


    }

    //Gets called from PlayerMovementBasics when left mouse is clicked
    public void ShootGrapple(RaycastHit2D ray)
    {
        if(isGrappling == false && ray.collider != null)
        {
            if(ray.distance<ropeLength)
            {
                lineRenderer.SetPosition(1, ray.point);       // line renderer second point
                lineRenderer.enabled = true; 
                springJoint.enabled = true;
               // springJoint.distance = 2f; //ray.distance;
                springJoint.connectedBody = GameObject.Find(ray.collider.name).GetComponent<Rigidbody2D>();
                springJoint.connectedAnchor = ray.point;
                isGrappling = true;             
            }


        }



    }

    public void StopGrapple()
    {
        lineRenderer.enabled = false;
        springJoint.enabled = false;
        isGrappling = false;
    }
}
