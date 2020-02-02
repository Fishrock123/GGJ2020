using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainHorn : MonoBehaviour
{

    public float hornDelay = 2;

    float elapsedSinceHorn = 0;

    public AudioSource hornSource;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!hornSource.isPlaying)
        {
            elapsedSinceHorn += Time.deltaTime;
        }
    }

    public void DoHorn()
    {
        if (elapsedSinceHorn > hornDelay)
        {
            elapsedSinceHorn = 0;
            hornSource.Play();
        }
    }
}
