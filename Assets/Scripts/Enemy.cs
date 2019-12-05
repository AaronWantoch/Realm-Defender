using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 2f;
    public Tower affectedBy;

    // Start is called before the first frame update
    [SerializeField] int health = 3;
    [SerializeField] int pointsForKill = 5;
    [SerializeField] float height = 6f;
    
    [SerializeField] ParticleSystem hitParticle;
    [SerializeField] ParticleSystem deathParticle;

    [SerializeField] AudioClip hitSoundFX;
    [SerializeField] AudioClip destroyedSoundFX;

    float basicSpeed;

    AudioSource audioSource;
    PathFinder pathFinder;
    Score score;
    Material basicMaterial;
    Waypoint waypointOnNow;
    

    void Start()
    {
        pathFinder = FindObjectOfType<PathFinder>();
        score = FindObjectOfType<Score>();
        audioSource = GetComponent<AudioSource>();

        MeshRenderer meshRenderer = GetComponentInChildren<MeshRenderer>();
        basicMaterial = meshRenderer.material;
        basicSpeed = moveSpeed;

        StartCoroutine(FollowPath());
    }
 
    IEnumerator FollowPath()
    {
        foreach (Waypoint waypoint in pathFinder.GetPath())
        {
            if(!waypoint.isEnemyOn)
            {
                waypointOnNow = waypoint;
                gameObject.transform.position = waypoint.transform.position
                + new Vector3(0, height, 0);
                waypoint.isEnemyOn = true;
            }
            
            yield return new WaitForSeconds(moveSpeed);

            waypoint.isEnemyOn = false;
        }
    }

    void OnParticleCollision(GameObject other)
    {
        Tower tower = other.GetComponentInParent<Tower>();

        DecreaseEnemyHealth(tower.damageDealt);
        IsEnemyDead();

        if (tower != affectedBy)
        {
            tower.AdditionalEffect(this);
        }
        
    }

    private void IsEnemyDead()
    {
        if (health <= 0)
        {
            score.IncreaseScore(pointsForKill);
            DestroyEnemy();
        }
        else
        {
            audioSource.PlayOneShot(hitSoundFX);
        }
    }

    public void DecreaseEnemyHealth(int damage)
    {
        health-= damage;
        hitParticle.Play(); 
    }

    public void DestroyEnemy()
    {
        ParticleSystem particleObject =
                       Instantiate(deathParticle, transform.position, Quaternion.identity);
        float destroyDelay = particleObject.main.duration;
        Destroy(particleObject.gameObject, destroyDelay);

        AudioSource.
            PlayClipAtPoint(destroyedSoundFX,Camera.main.transform.position);
        waypointOnNow.isEnemyOn = false;

        Destroy(gameObject);
    }

    public void ClearEffect()
    {
        MeshRenderer meshRenderer = GetComponentInChildren<MeshRenderer>();
        meshRenderer.material = basicMaterial;

        moveSpeed = basicSpeed;
        affectedBy = null;
    }
}
