using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int health = 3;
    [SerializeField] int pointsForKill = 5;
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] float height = 6f;
    
    [SerializeField] ParticleSystem hitParticle;
    [SerializeField] ParticleSystem deathParticle;

    [SerializeField] AudioClip hitSoundFX;
    [SerializeField] AudioClip destroyedSoundFX;

    AudioSource audioSource;

    PathFinder pathFinder;
    Score score;

    void Start()
    {
        pathFinder = FindObjectOfType<PathFinder>();
        score = FindObjectOfType<Score>();
        audioSource = GetComponent<AudioSource>();

        StartCoroutine(FollowPath());
    }
 
    IEnumerator FollowPath()
    {
        foreach (Waypoint waypoint in pathFinder.GetPath())
        {
            gameObject.transform.position = waypoint.transform.position
                + new Vector3(0, height, 0);
            yield return new WaitForSeconds(moveSpeed);
        }
    }

    void OnParticleCollision(GameObject other)
    {
        health--;
        hitParticle.Play();

        if(health<=0)
        {
            score.IncreaseScore(pointsForKill);
            DestroyEnemy();
        }
        else
        {
            audioSource.PlayOneShot(hitSoundFX);
        }
    }

    public void DestroyEnemy()
    {
        ParticleSystem particleObject =
                       Instantiate(deathParticle, transform.position, Quaternion.identity);
        float destroyDelay = particleObject.main.duration;
        Destroy(particleObject.gameObject, destroyDelay);

        AudioSource.
            PlayClipAtPoint(destroyedSoundFX,Camera.main.transform.position);

        Destroy(gameObject);
    }
}
