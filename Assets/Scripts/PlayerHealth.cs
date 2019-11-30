﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] Text healthText;

    [SerializeField] int health = 10;

    AudioSource loseHealthSoundFX;

    private void Start()
    {
        healthText.text = health.ToString();
        loseHealthSoundFX = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        health--; //todo why is this first and then enemy destroy when he hits point
        healthText.text = health.ToString();

        loseHealthSoundFX.Play();

        if(health<=0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
