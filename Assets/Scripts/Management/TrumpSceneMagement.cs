using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrumpSceneMagement : MonoBehaviour
{
    GameManager gameManager;
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();

        if (gameManager == null)
        {
            Debug.LogAssertion("Game Manager was not loaded in Trump Scene!");
        }
    }
    public void LoadScene(string name)
    {
        gameManager.SetLevel(name);
    }
}
