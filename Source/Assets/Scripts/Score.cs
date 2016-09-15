using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    static int score;        // The player's score.
    static int highScore;
    static int scoring;

    Text text;                      // Reference to the Text component.


    static public void AddPoint()
    {

        score++;

        if (score > highScore)
        {
            highScore = score;
        }
    }
    void Start()
    {

        highScore = PlayerPrefs.GetInt("highScore", 0);
        scoring = PlayerPrefs.GetInt("scoring", 0);
    }
    void OnDestroy()
    {
        
        PlayerPrefs.SetInt("highScore", highScore);
        PlayerPrefs.SetInt("scoring", scoring);
    }
    void Awake()
    {
        // Set up the reference.
        text = GetComponent<Text>();

        // Reset the score.
        score = 0;
    }


    void Update()
    {
        // Set the displayed text to be the word "Score" followed by the score value.
        text.text = "Score: " + score + "\nHigh Score: " + highScore;
    }
}
