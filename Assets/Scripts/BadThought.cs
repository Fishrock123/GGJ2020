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

    void OnTriggerEnter2D(Collider2D other)
    {

        GoodThought otherThought;
        other.TryGetComponent(out otherThought);
        if (otherThought == null)
        {
            return;
        }

        // We hit a good thought
        if (otherThought.attached == false)
        {
            return;
        }

        // It is attached, so destroy the bad thought.

        ThoughtsSpawnSystem tss;
        GameObject.Find("BadThoughtSpawnSystem").TryGetComponent(out tss);

        if (tss == null)
        {
            Debug.LogError("Tried to return bad thought to spawner but could not find spawner");
        }

        tss.BackToPool(gameObject);
    }
}
