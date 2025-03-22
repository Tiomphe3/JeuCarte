using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSeparator : MonoBehaviour
{
    
    void Start()
    {
        LineRenderer line = GetComponent<LineRenderer>();
        line.positionCount = 2;
        line.SetPosition(0, new Vector3(4, 0, 0));
        line.SetPosition(1, new Vector3(4, 4, 0));
        line.startWidth = 0.1f;
        line.endWidth = 0.1f;
        line.material = new Material(Shader.Find("Sprites/Default"));
        line.startColor = Color.white;
        line.endColor = Color.white;    
    }

    
}
