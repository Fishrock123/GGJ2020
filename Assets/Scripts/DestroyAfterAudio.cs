using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterAudio : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {
        TryGetComponent(out audioSource);
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            Debug.Log("Destroyed audio object");
            Destroy(gameObject);
        }
    }
}
