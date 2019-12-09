using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Text scoreText = GetComponent<Text>();
        scoreText.text = "Your Score: " + PlayerPrefs.GetInt("points");
    }
}
