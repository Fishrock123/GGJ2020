using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadThought : MonoBehaviour
{
    public float speed = 0.001f;
    private Vector3 directionToTarget;
    private void OnEnable()
    {
        directionToTarget = Vector3.zero - transform.position;
        directionToTarget = directionToTarget.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(directionToTarget * speed * Time.deltaTime);
    }
}
