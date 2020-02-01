using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadThought : MonoBehaviour
{
    public Transform target;
    public float speed = 0.001f;
    private Vector3 directionToTarget;
    void Start()
    {
        directionToTarget = target.position - transform.position;
        directionToTarget = directionToTarget.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(directionToTarget * speed * Time.deltaTime);
    }
}
