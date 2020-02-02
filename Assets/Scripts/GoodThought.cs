using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodThought : MonoBehaviour
{
    public Transform origin;
    public float rotation = 0; // degrees around origin
    public float radius = 6;

    public float speed = 0.1f;
    public float speedToCenter = 0.1f;

    public bool attached = false;

    public PlayerTrain train;
    public GoodThought previous;
    public GoodThought next;

    public Transform attachmentFront;
    public Transform attachmentBack;

    public Transform targetAnchor;

    public GameObject trainGFX;
    public Vector3 left;
    public Vector3 right;

    public AudioSource attachSFX;
    public AudioSource detatchSFX;

    private void OnEnable()
    {
        left = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Vector3 distanceToCenter = left - Vector3.zero;
        radius = distanceToCenter.x;
        //dirToCenter.Normalize();
        right = new Vector3(distanceToCenter.x*-1, distanceToCenter.y*-1, transform.position.z);
    }

    void FixedUpdate()
    {
        if (attached)
        {
            transform.up = targetAnchor.position - transform.position;
            transform.position = targetAnchor.position - (transform.up * attachmentFront.localPosition.magnitude);
            return;
        }

        radius = Mathf.Lerp(radius, 0, speedToCenter*Time.deltaTime);
        
        rotation += Time.deltaTime * speed;
        rotation = rotation % 2;

        Vector3 xform;
        if (rotation > 1)
        {
            xform = Vector3.Slerp(right, left, rotation - 1);
            transform.position = new Vector3(xform.x, -xform.z, xform.y);
        }
        else
        {
            xform = Vector3.Slerp(left, right, rotation);
            transform.position = new Vector3(xform.x, xform.z, xform.y);
        }
    }

    public void AttachTo(Transform anchor)
    {
        targetAnchor = anchor;
        attached = true;
        trainGFX.SetActive(true);
        attachSFX.Play();
    }

    public void Detatch()
    {
        targetAnchor = null;
        attached = false;
        trainGFX.SetActive(false);
        detatchSFX.Play();
    }

    public void ReAttachTo(Transform anchor)
    {
        targetAnchor = anchor;
    }
}
