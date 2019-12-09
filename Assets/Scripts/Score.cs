using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int points = 0;

    Text scoreText;
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
