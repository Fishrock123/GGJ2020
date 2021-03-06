﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
    public float RespawnTime = 20;
    //public class RespawnEvent : UnityEvent<GameObject> { };

    public UnityEvent respawnEvent;
    private Vector3 directionToTarget;

    public GameObject outline;

    Rigidbody2D body;

    private void OnEnable()
    {
        TryGetComponent(out body);

        Vector3 target = new Vector2(Random.Range(0, 10), Random.Range(0, 10));
        directionToTarget = target - transform.position;
        directionToTarget = directionToTarget.normalized;
        Renderer.sprite = sprites[Random.Range(0, sprites.Count - 1)];
        StartCoroutine(Respawn());
    }

    void FixedUpdate()
    {
        body.velocity = Vector2.zero;

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
        outline.SetActive(false);
    }

    public void Detatch()
    {
        targetAnchor = null;
        attached = false;
        trainGFX.SetActive(false);
        detatchSFX.Play();
        outline.SetActive(true);
    }

    public void ReAttachTo(Transform anchor)
    {
        targetAnchor = anchor;
    }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(RespawnTime);
        if ( !attached)
        {
            respawnEvent.Invoke();
        }
    }

}
