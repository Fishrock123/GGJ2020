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

    public UnityEngine.Events.UnityEvent endGame;
    public UnityEngine.Events.UnityEvent loseGame;

    private void Start()
    {
        setHealthBar((float)lifeCounter / (float)lifeLimit);
    }
    public void subtractLife()
    {

        lifeCounter--;
        setHealthBar((float)lifeCounter / (float)lifeLimit);
        if (lifeCounter == 0)
        {
            Time.timeScale = 0;
            loseGame.Invoke();
        }
    }

    public void addLife()
    {
        if (lifeCounter < lifeLimit)
        {
            lifeCounter++;
            setHealthBar((float)lifeCounter / (float)lifeLimit);
        }
        if (lifeCounter == lifeLimit)
        {
            endGame.Invoke();
        }
    }

    private void setHealthBar(float amount)
    {
        healthBarFilling.fillAmount = amount;
    }
}
