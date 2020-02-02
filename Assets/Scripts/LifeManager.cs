using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    [SerializeField]
    private int liveCounter = 10;
    
    public void subtractLife()
    {
       
        liveCounter--;
        if (liveCounter == 0)
        {
            Debug.Log("Game Over");
        }
    }
}
