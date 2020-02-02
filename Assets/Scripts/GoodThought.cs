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
    public List<Sprite> sprites;

    public SpriteRenderer Renderer;
    private Vector3 directionToTarget;

    private void OnEnable()
    {
        Vector3 target = new Vector2(Random.Range(0, 10), Random.Range(0, 10));
        directionToTarget = target - transform.position;
        directionToTarget = directionToTarget.normalized;
        Renderer.sprite = sprites[Random.Range(0, sprites.Count - 1)];
    }

    void FixedUpdate()
    {
        if (attached)
        {
            transform.up = targetAnchor.position - transform.position;
            transform.position = targetAnchor.position - (transform.up * attachmentFront.localPosition.magnitude);
            return;
        }
        transform.Translate(directionToTarget * Time.deltaTime * speed);

        
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
