using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField] Transform prefab;
    [SerializeField] float spawnTime = 2f;

    AudioSource enemySpawnSound;

    // Start is called before the first frame update
    void Start()
    {
        enemySpawnSound = GetComponent<AudioSource>();
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while(true)
        {
            enemySpawnSound.Play();
            Instantiate(prefab, gameObject.transform);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
