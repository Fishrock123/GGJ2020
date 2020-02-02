using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCollision : MonoBehaviour
{
    public UnityEngine.Events.UnityEvent collisionEvent;
    [SerializeField]
    private Animator trumpAnimator;
    [SerializeField]
    private AudioSource trumpAudioSource;
    [SerializeField]
    private AudioClip[] trumpAudioClips;
    private bool playingSpeak = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("BadThought"))
        {
            StartCoroutine(PlaySound());
            collisionEvent.Invoke();
        }


    }

    private IEnumerator PlaySound()
    {
        int randomAudioClip = UnityEngine.Random.Range(0, trumpAudioClips.Length - 1);
        trumpAnimator.SetTrigger("speak");
        playingSpeak = true;
        trumpAudioSource.clip = trumpAudioClips[randomAudioClip];
        trumpAudioSource.Play();
        yield return new WaitForSeconds(trumpAudioSource.clip.length);
        playingSpeak = false;
        trumpAnimator.SetTrigger("backToIdle");
    }
}
