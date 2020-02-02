using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementTutorial : MonoBehaviour
{
    Vector2 direction = Vector2.zero;

    public int framesWanted = 60;
    int frames = 0;

    public GameObject nextTutorial;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (direction.magnitude > 0.5)
        {
            frames++;
        }

        if (frames > framesWanted)
        {
            nextTutorial.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    public void AdjustDirection(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();
    }
}
