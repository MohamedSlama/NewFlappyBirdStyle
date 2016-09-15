using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class coinny : MonoBehaviour {

    float Scoring;
    /*void Start()
    {
        highScore = PlayerPrefs.GetInt("Scoring", 0);
    }
    void OnDestroy()
    {
        PlayerPrefs.SetInt("Scoring", Scoring);
    }*/

    public float Temp;
    void FixedUpdate()
    {
        Temp -= Time.deltaTime;
        if (Temp <= 0)
        {
            SceneManager.LoadScene("Scene");
        }
    }
}
