using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField] Transform prefab;
    [SerializeField] float spawnTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while(true)
        {
            Instantiate(prefab, gameObject.transform);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
