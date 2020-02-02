using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodThoughtTutorial : MonoBehaviour
{
    public GoodThought goodThought;

    public Transform origin;

    public Transform pos;

    public int attachedFrames = 60;
    int frames = 0;
    GoodThought thought;

    public GameObject nextTutorial;

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnEnable()
    {
        thought = GameObject.Instantiate(goodThought, pos.position, Quaternion.identity);
        thought.origin = origin;
        thought.radius = 6;
        thought.speed = 0.5f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (thought.attached)
        {
            frames++;
        }
        if (frames > attachedFrames)
        {

            Destroy(thought.gameObject);

            if (nextTutorial)
            {
                nextTutorial.SetActive(true);
                gameObject.SetActive(false);
            } else {
                GameObject.FindObjectOfType<GameManager>().SetLevel("IntroScene");
            }
        }
    }
}
