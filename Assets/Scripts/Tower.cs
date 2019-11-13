using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform rotatedElement;
    [SerializeField] Transform enemy;
    ParticleSystem particleSystem;

    [SerializeField] float maxDistance = 20f;

    bool isShooting = false;

    void Start()
    {
        particleSystem = GetComponentInChildren<ParticleSystem>();
    }

    void Update()
    {
        if (enemy != null)
        {
            if (InDistance())
            {
                rotatedElement.LookAt(enemy);
                ChangeEmission(true);
            }
            else
            {
                ChangeEmission(false);
            }
        }
        
    }

    private void ChangeEmission(bool emit)
    {
        ParticleSystem.EmissionModule emissionModule = particleSystem.emission;
        emissionModule.enabled = emit;
    }

    private bool InDistance()
    {
        float distance = Vector3.Distance(gameObject.transform.position, enemy.position);
        if (distance > maxDistance)
            return false;
        else
            return true;
    }
}
