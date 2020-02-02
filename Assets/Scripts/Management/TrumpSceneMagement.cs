using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrumpSceneMagement : MonoBehaviour
{

    public AudioSource failureAudio;
    public AudioSource successAudio;

    GameManager gameManager;
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();

        if (gameManager == null)
        {
            Debug.LogAssertion("Game Manager was not loaded in Trump Scene!");
        }
    }

    public void Failure(string nextScene)
    {
        StartCoroutine(EndRoutine(nextScene, failureAudio));
    }

    public void Success(string nextScene)
    {
        StartCoroutine(EndRoutine(nextScene, successAudio));
    }

    IEnumerator EndRoutine(string nextScene, AudioSource audio)
    {
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        while(audio.isPlaying)
        {
            yield return 0;
        }
        LoadScene(nextScene);
    }

    public void LoadScene(string name)
    {
        gameManager.SetLevel(name);
    }
}
