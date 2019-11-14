using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform rotatedElement;
    [SerializeField] float maxDistance = 20f;

    ParticleSystem particleSystem;
    Transform target;



    bool isShooting = false;

    void Start()
    {
        particleSystem = GetComponentInChildren<ParticleSystem>();
    }

    void Update()
    {
        TargetEnemy();
        ShootIfInDistance();
    }

    private void TargetEnemy()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();

        if(enemies.Length>0)
        {
            Transform closestEnemy = enemies[0].transform;

            foreach(Enemy enemy in enemies)
            {
                closestEnemy = FindClosestEnemy(enemy.transform, closestEnemy);
            }

            target = closestEnemy;
        }
    }

    private Transform FindClosestEnemy(Transform enemy, Transform closestEnemy)
    {
        if (Vector3.Distance(enemy.position, gameObject.transform.position)
           < Vector3.Distance(closestEnemy.position, gameObject.transform.position))
        {
            return enemy;
        }
        else
        {
            return closestEnemy;
        }
    }

    private void ShootIfInDistance()
    {
        if (target != null)
        {
            if (InDistance())
            {
                rotatedElement.LookAt(target);
                ChangeEmission(true);
            }
            else
            {
                ChangeEmission(false);
            }
        }
        else
        {
            ChangeEmission(false);
        }
    }

    private void ChangeEmission(bool emit)
    {
        ParticleSystem.EmissionModule emissionModule = particleSystem.emission;
        emissionModule.enabled = emit;
    }

    private bool InDistance()
    {
        float distance = Vector3.Distance(gameObject.transform.position, target.position);
        if (distance > maxDistance)
            return false;
        else
            return true;
    }
}
