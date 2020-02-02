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

    public bool attached = false;

    public PlayerTrain train;
    public GoodThought previous;
    public GoodThought next;

    public Transform attachmentFront;
    public Transform attachmentBack;
    // Start is called before the first frame update
    public Transform targetAnchor;

    public GameObject trainGFX;

    public AudioSource attachSFX;
    public AudioSource detatchSFX;

    public List<Sprite> sprites;

    public SpriteRenderer renderer;

    void Start()
    {
        renderer.sprite = sprites[Random.Range(0, sprites.Count - 1)];
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
