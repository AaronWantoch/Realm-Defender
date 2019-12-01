using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField] Transform prefab;

    [SerializeField] float spawnDecreaseTime = 0.1f;
    [SerializeField] float spawnTime = 3f;
    [SerializeField] float spawnMinTime = 1.75f;

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
            Instantiate(prefab, gameObject.transform);
            yield return new WaitForSeconds(spawnTime);

            enemySpawnSound.Play();

            DecreaseSpawnTime();
        }
    }

    private void DecreaseSpawnTime()
    {
        if (spawnTime > spawnMinTime)
        {
            spawnTime -= spawnDecreaseTime;
        }
    }
}
