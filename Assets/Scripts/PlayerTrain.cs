using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrain : MonoBehaviour
{
    public Transform origin;

    public float rotation = 0; // degrees around origin
    public float radius = 2;

    public float speed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {

    }
    void Update () {

        Vector3 left = new Vector3(origin.position.x - radius, origin.position.y, origin.position.z);

        Debug.DrawRay(left, left + left, Color.green);

        Vector3 right = new Vector3(origin.position.x + radius, origin.position.y, origin.position.z);

        Debug.DrawRay(right, right + right, Color.red);

        // // The center of the arc
        // float center = (originLeft.position + originRight.position) * 0.5;
        // // move the center a bit downwards to make the arc vertical
        // center -= Vector3(0,1,0);

        // // Interpolate over the arc relative to center
        // float riseRelCenter = sunrise.position - center;
        // float setRelCenter = sunset.position - center;
        rotation += Time.deltaTime * speed;
        rotation = rotation % 1;

        Vector3 xform = Vector3.Slerp(left, right, rotation);

        transform.position = new Vector3(xform.x, xform.z, xform.y);
        // transform.position += center;
 }
}
