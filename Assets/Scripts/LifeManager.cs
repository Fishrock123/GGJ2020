using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    [SerializeField]
    private int lifeCounter = 10;
    [SerializeField]
    private int lifeLimit = 20;
    [SerializeField]
    private Image healthBarFilling;

    private void Awake()
    {
        healthBarFilling.fillAmount = (float)lifeCounter/ (float)lifeLimit;
    }
    public void subtractLife()
    {

        lifeCounter--;
        healthBarFilling.fillAmount = (float)lifeCounter / (float)lifeLimit;
        if (lifeCounter == 0)
        {
            Debug.Log("Game Over");
        }
    }

    public void addLife()
    {
        if (lifeCounter < lifeLimit)
        {
            lifeCounter++;
            healthBarFilling.fillAmount = (float)lifeCounter / (float)lifeLimit;
        }
        if (lifeCounter == lifeLimit)
        {
            Debug.Log("WIN");
        }
    }
}
