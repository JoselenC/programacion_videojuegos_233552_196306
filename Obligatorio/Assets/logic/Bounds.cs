using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Bounds
{
    public float xmin, xmax, ymin, ymax;

    public Bounds(float a, float b, float c, float d)
    {
        xmin = a;
        xmax = b;
        ymin = c;
        ymax = d;
    }
    
    
}
