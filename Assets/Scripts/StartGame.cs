using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    GameObject tutorialPanel;

    [SerializeField] AudioSource music;

    void Start()
    {
        tutorialPanel = this.gameObject;

        Time.timeScale = 0;
        tutorialPanel.SetActive(true);
    }

    public void DisableTutorial()
    {
        Time.timeScale = 1;
        tutorialPanel.SetActive(false);
        music.Play();
    }
}
