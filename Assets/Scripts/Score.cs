using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    Text scoreText;
    int points = 0;

    private void Start()
    {
        scoreText = GetComponent<Text>();
    }

    public void IncreaseScore(int pointsForEnemy)
    {
        points += pointsForEnemy;
        scoreText.text = points.ToString();
    }   
}
