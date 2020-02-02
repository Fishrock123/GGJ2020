using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class IntroSceneManager : MonoBehaviour
{
    GameManager gameManager;

    public int listIndex = 0;

    public float listNavCooldownTime = 0.7f;
    float listNavCooldown = 0;

    public List<Button> buttons;

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
        listNavCooldown += Time.deltaTime;
    }

    public void LoadScene(string name)
    {
        gameManager.SetLevel(name);
    }

    public void ListNavigate(InputAction.CallbackContext context)
    {
        if (listNavCooldown < listNavCooldownTime)
        {
            return;
        }
        listNavCooldown = 0;

        listIndex += Mathf.RoundToInt(context.ReadValue<Vector2>().y);
        Debug.Log(listIndex);
        if (listIndex < 0)
        {
            listIndex = buttons.Count -1;
        }
        else if (listIndex >= buttons.Count)
        {
            listIndex = 0;
        }
        buttons[listIndex].Select();
    }

    public void ListConfirm(InputAction.CallbackContext context)
    {
        buttons[listIndex].onClick.Invoke();
    }

    public void PlayAudioClip(AudioClip clip)
    {
        gameManager.PlayAudioClip(clip);
    }
}
