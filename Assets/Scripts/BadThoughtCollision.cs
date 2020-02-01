using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BadThoughtCollision : MonoBehaviour
{
    [System.Serializable]
    public class BadThoughtEvent : UnityEvent<GameObject> { };
   
    public BadThoughtEvent badThoughtEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("FACE"))
        {
            badThoughtEvent.Invoke(gameObject);
        }
    }
}
