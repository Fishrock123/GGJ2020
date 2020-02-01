using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysicsTrigger : MonoBehaviour
{
    Rigidbody2D body;
    public Transform attachmentPoint;
    public PlayerTrain train;
    public GoodThought lastThought;

    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out body);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate ()
    {
        transform.localPosition = Vector3.zero;
        body.position = transform.position;
        body.rotation = 0;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Break();

        GoodThought thought;
        other.TryGetComponent(out thought);

        if (thought == null)
        {
            Debug.LogError("Thought behavior not found!");
            return;
        }

        if (thought.attached)
        {
            return;
        }

        thought.train = train;
        if (lastThought)
        {
            thought.previous = lastThought;
            lastThought.next = thought;
            thought.AttachTo(lastThought.attachmentBack);
        } else {
            thought.AttachTo(attachmentPoint);
        }
        lastThought = thought;
    }
}
