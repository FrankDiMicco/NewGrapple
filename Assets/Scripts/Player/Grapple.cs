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
        
    }

    // Update is called once per frame
    void Update()
    {
        ray = grappleRayCast.ray;
        if(ray.collider != null)
        {
            Debug.Log("Grapple to " + ray.collider.name);
            lineRenderer.SetPosition(0, grappleStart.position); //line renderer start point
            lineRenderer.SetPosition(1, ray.point);       // line renderer second point
        }
    }
}
