using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
     private float _bounceForce = 130f;
     private float _bounceRadius = 100f;

    public void Break()
    {
        PlatformSegment2[] platformSegment2 = GetComponentsInChildren<PlatformSegment2>();
        foreach (var segment in platformSegment2)
        {
            segment.Bounce(_bounceForce,transform.position,_bounceRadius);
        }
    }
}
