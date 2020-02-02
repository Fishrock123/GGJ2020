using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioDelayedAction : MonoBehaviour
{
    public AudioSource audioSource;
    public UnityEvent delayedAction;

    public bool realtime = true;

    public bool single = true;

    public void TriggerAudioAction()
    {
        if (single && audioSource.isPlaying)
        {
            return;
        }
        StartCoroutine(AudioRoutine());
    }

    IEnumerator AudioRoutine()
    {
        audioSource.Play();
        // Debug.Log(audioSource.clip.length);
        if (realtime)
        {
            yield return new WaitForSecondsRealtime(audioSource.clip.length);
        }
        else
        {
            yield return new WaitForSeconds(audioSource.clip.length);
        }
        while(audioSource.isPlaying)
        {
            // Debug.Log("Waiting for audio source to finish");
            yield return 0;
        }
        // Debug.Log("??????");
        delayedAction.Invoke();
    }
}
