using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroSceneManager : MonoBehaviour
{
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();

        if (gameManager == null)
        {
            Debug.LogAssertion("Game Manager was not loaded in Intro Scene!");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadScene(string name)
    {
        gameManager.SetLevel(name);
    }
}
