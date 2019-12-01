using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] Text healthText;
    [SerializeField] ParticleSystem baseDamageParticle;

    [SerializeField] int health = 10;

    AudioSource loseHealthSoundFX;

    private void Start()
    {
        healthText.text = health.ToString();
        loseHealthSoundFX = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        LoseHealth();

        Enemy enemy = other.GetComponentInParent<Enemy>();
        DestroyEnemy(enemy);

        EndGame();
    }

    private void LoseHealth()
    {
        health--; //todo why is this first and then enemy destroy when he hits point
        healthText.text = health.ToString();

        loseHealthSoundFX.Play();
    }

    private void DestroyEnemy(Enemy enemy)
    {
        ParticleSystem particleObject =
                    Instantiate(baseDamageParticle, enemy.transform.position, Quaternion.identity);

        float destroyDelay = particleObject.main.duration;
        Destroy(particleObject.gameObject, destroyDelay);

        enemy.DestroyEnemy();
    }

    private void EndGame()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
