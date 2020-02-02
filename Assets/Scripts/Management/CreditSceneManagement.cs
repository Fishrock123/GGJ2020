using System.Collections;
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            gameManager.SetLevel("IntroScene");
        }
    }
}
