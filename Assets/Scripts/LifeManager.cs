using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    [SerializeField]
    private int lifeCounter = 10;
    [SerializeField]
    private int lifeLimit = 20;
    
    public void subtractLife()
    {

        lifeCounter--;
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
        }
        if (lifeCounter == lifeLimit)
        {
            Debug.Log("WIN");
        }
    }
}
