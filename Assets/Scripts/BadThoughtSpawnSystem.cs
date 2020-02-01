using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadThoughtSpawnSystem : MonoBehaviour
{
    public GameObject badThoughtObject;
    public float radius = 6f;
    public float coolDownSpawn = 1f;
    public int maxThoughts = 10;
    private int currentThoughts = 0;
    private bool canSpawn = false;
    private float coolDownCountDown = 0f;
    private Queue<GameObject> thoughtsPool;
 
    void Start()
    {
        thoughtsPool = new Queue<GameObject>();
        StartCoroutine(CoolDown());
    }

    // Update is called once per frame
    void Update()
    {
        if ( canSpawn )
        {
           
            GameObject badThought = GetThought();
            if (badThought !=null)
            {
                var angle = Random.Range(0f, 1f) * Mathf.PI * 2;
                var x = Mathf.Cos(angle) * radius;
                var y = Mathf.Sin(angle) * radius;
                badThought.transform.position = new Vector3(x, y);
                badThought.SetActive(true);
            }
            canSpawn = false;
            StartCoroutine(CoolDown());
        }

    }

    private GameObject GetThought()
    {
        if (thoughtsPool.Count == 0 && currentThoughts < maxThoughts)
        {
            GameObject thoughtToPool = GameObject.Instantiate(badThoughtObject, transform);
            thoughtToPool.SetActive(false);
            thoughtsPool.Enqueue(thoughtToPool);
            currentThoughts++;
        }
        if (thoughtsPool.Count == 0)
        {
            return null;
        }
        return thoughtsPool.Dequeue();
    }
    private IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(coolDownSpawn);
        canSpawn = true;
    }

    public void BackToPool(GameObject gameObjectToPool)
    {
        gameObjectToPool.SetActive(false);
        thoughtsPool.Enqueue(gameObjectToPool);
    }
}
