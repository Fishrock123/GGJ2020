using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThoughtsSpawnSystem : MonoBehaviour
{
    public GameObject ThoughtPrefab;
    public float radius = 6f;
    public float coolDownSpawn = 1f;
    public int maxThoughts = 10;
    private int currentThoughts = 0;
    private bool canSpawn = false;
    public float initialDelay = 10;
    private static Queue<GameObject> thoughtsPool;

    void Start()
    {
        thoughtsPool = new Queue<GameObject>();
        StartCoroutine(CoolDown(initialDelay));
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawn)
        {

            GameObject thought = GetThought();
            if (thought != null)
            {
                var angle = Random.Range(0f, 1f) * Mathf.PI * 2;
                var x = Mathf.Cos(angle) * radius;
                var y = Mathf.Sin(angle) * radius;
                thought.transform.position = new Vector3(x, y);
                thought.SetActive(true);
                canSpawn = false;
                StartCoroutine(CoolDown(coolDownSpawn));
            }
        }

    }

    private GameObject GetThought()
    {
        if (thoughtsPool.Count == 0 && currentThoughts < maxThoughts)
        {
            GameObject thoughtToPool = Instantiate(ThoughtPrefab, transform);
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
    private IEnumerator CoolDown(float delay)
    {
        yield return new WaitForSeconds(delay);
        canSpawn = true;
    }

    public void BackToPool(GameObject gameObjectToPool)
    {
        gameObjectToPool.SetActive(false);
        thoughtsPool.Enqueue(gameObjectToPool);
    }
}
