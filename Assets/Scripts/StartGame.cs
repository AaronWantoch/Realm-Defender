using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    GameObject tutorialPanel;

    private void Start()
    {

        tutorialPanel = this.gameObject;
    }

    public void DisableTutorial()
    {
        tutorialPanel.SetActive(false);
    }
}
