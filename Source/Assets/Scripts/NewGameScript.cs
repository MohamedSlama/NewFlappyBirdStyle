using UnityEngine;
using System.Collections;

public class NewGameScript : MonoBehaviour {

    public void MainMenu()
    {
        Application.LoadLevel(0);
    }

    public void PlayGame()
    {
        Application.LoadLevel(1);
    }
    public void HowToPlay()
    {
        Application.LoadLevel(2);
    }
}
