using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManagement : MonoBehaviour
{
    GameManager gameManager;

    public AudioClip backAudioClip;

    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();

        if (gameManager == null)
        {
            Debug.LogAssertion("Game Manager was not loaded in GameOver Scene!");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            gameManager.PlayAudioClip(backAudioClip);
            gameManager.SetLevel("IntroScene");
        }
    }
}
