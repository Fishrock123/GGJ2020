using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalSceneManager : MonoBehaviour
{
    Color faded = Color.clear;

    public Image congrats;
    public Image blackfade;
    public Image credits;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(fadeCongratsToCredits());
    }

    IEnumerator fadeCongratsToCredits()
    {
        congrats.gameObject.SetActive(true);
        // yield return fadeImageIn(congrats, 2);
        yield return new WaitForSeconds(5);
        yield return fadeImageOut(congrats, 1.3f);
        congrats.gameObject.SetActive(true);
        credits.gameObject.SetActive(true);
        yield return fadeImageOut(blackfade, 1.3f);
    }

    IEnumerator fadeImageIn(Image image, float seconds)
    {
        Color originalColor = image.color;
        image.color = faded;

        float elapsed = 0;
        while (elapsed < seconds)
        {
            image.color = Color.Lerp(faded, originalColor, elapsed / seconds);
            yield return new WaitForSeconds(Time.deltaTime);
            elapsed += Time.deltaTime;
        }
    }

    IEnumerator fadeImageOut(Image image, float seconds)
    {
        Color originalColor = image.color;

        float elapsed = 0;
        while (elapsed < seconds)
        {
            image.color = Color.Lerp(originalColor, faded, elapsed / seconds);
            yield return new WaitForSeconds(Time.deltaTime);
            elapsed += Time.deltaTime;
        }

        image.color = faded;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
