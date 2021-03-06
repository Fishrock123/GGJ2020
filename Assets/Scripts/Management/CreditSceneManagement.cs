﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditSceneManagement : MonoBehaviour
{
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();

        if (gameManager == null)
        {
            Debug.LogError("Game Manager was not loaded in for Main Menu Button!");
        }
    }


    public void LoadScene(string scene)
    {
        gameManager.SetLevel(scene);
    }

    public void PlayAudioClip(AudioClip clip)
    {
        gameManager.PlayAudioClip(clip);
    }
}
