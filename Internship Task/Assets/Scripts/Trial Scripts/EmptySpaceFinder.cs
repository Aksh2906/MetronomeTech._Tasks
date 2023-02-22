using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptySpaceFinder : MonoBehaviour
{
    public float raycastDistance = 5f;
    public float emptySpaceRadius = 2f;
    
    private Vector3 emptySpacePosition = Vector3.zero;
    private Vector3 emptySpaceDirection = Vector3.zero;
    
    void Update()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance))
        {
            emptySpacePosition = hit.point + hit.normal * emptySpaceRadius;
            emptySpaceDirection = hit.normal;
        }
        else
        {
            emptySpacePosition = transform.position + transform.forward * raycastDistance;
            emptySpaceDirection = transform.forward;
        }
    }
    
    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(emptySpacePosition, emptySpaceRadius);
        Gizmos.DrawLine(transform.position, emptySpacePosition);
    }
}

