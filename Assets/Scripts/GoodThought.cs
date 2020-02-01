using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodThought : MonoBehaviour
{
    public Vector3 origin;
    
    public float rotation = 0; // degrees around origin
    public float radius = 6;

    public float speed = 0.1f;
    public float speedToCenter = 0.1f;
    void Start()
    {
        
        
    }

    void Update()
    {
        radius = Mathf.Lerp(radius, 0, speedToCenter*Time.deltaTime);
        Vector3 left = new Vector3(origin.x - radius, origin.y, origin.z);
        Vector3 right = new Vector3(origin.x + radius, origin.y, origin.z);
        rotation += Time.deltaTime * speed;
        rotation = rotation % 2;

        Vector3 xform;
        if (rotation > 1)
        {
            xform = Vector3.Slerp(right, left, rotation - 1);
        }
        else
        {
            xform = Vector3.Slerp(left, right, rotation);
        }

        if (rotation > 1)
        {
            transform.position = new Vector3(xform.x, -xform.z, xform.y);
        }
        else
        {
            transform.position = new Vector3(xform.x, xform.z, xform.y);
        }
    }
}
