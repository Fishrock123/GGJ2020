using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BadThoughtCollision : MonoBehaviour
{
    [System.Serializable]
    public class BadThoughtEvent : UnityEvent<GameObject> { };

    public BadThoughtEvent badThoughtEvent;

    [SerializeField]
    private AudioSource trumpAudioSource;
    [SerializeField]
    private AudioClip[] trumpAudioClips;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("FACE"))
        {
            badThoughtEvent.Invoke(gameObject);
        }

        GoodThought otherThought;
        collision.TryGetComponent(out otherThought);
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

        int randomAudioClip = UnityEngine.Random.Range(0, trumpAudioClips.Length - 1);
        GameObject.FindObjectOfType<GameManager>().PlayAudioClip(trumpAudioClips[randomAudioClip]);

        LifeManager lifeManager;
        GameObject.Find("LifeManager").TryGetComponent(out lifeManager);
        if (lifeManager == null)
        {
            Debug.LogError("Healtfh not found");
        }
        lifeManager.addLife();

        BadThoughtsSpawnSystem tss;
        GameObject.Find("BadThoughtSpawnSystem").TryGetComponent(out tss);

        if (tss == null)
        {
            Debug.LogError("Tried to return bad thought to spawner but could not find spawner");
        }

        tss.BackToPool(gameObject);
    }
}
