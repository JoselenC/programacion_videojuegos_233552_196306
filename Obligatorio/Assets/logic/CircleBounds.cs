using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBounds : MonoBehaviour
{
    [SerializeField]
    public float radius;
                                               
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform. position, radius);
    }
    
    public bool Collides(CircleBounds b)
    {
        float r = radius + b.radius;
        float distX = transform.position.x - b.transform.position.x;
        float distY = transform.position.y - b.transform.position.y;
        
        if (Mathf.Abs(distX) > r)
            return false;
        if (Mathf.Abs(distY) > r)
            return false;
        
        var distanceSqr = (distX * distX) + (distY * distY);
        return distanceSqr < r * r;
    }
    
}
