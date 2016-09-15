using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript : MonoBehaviour {

    GameObject PauseMenu;
    bool pause;
    bool mute;
    public Text muteText;

	// Use this for initialization
	void Start () {
        pause = false;
        PauseMenu = GameObject.Find("PauseMenu");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause = !pause;
            Move.paused = true;
        }
        if (pause)
        {
            PauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
        else if (!pause)
        {
            PauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
        if (mute)
        {
            AudioListener.volume = 0;
            muteText.text = "UnMute";
        }
        else if (!mute)
        {
            AudioListener.volume =1;
            muteText.text = "Mute";
        }
	}

    public void Resume()
    {
        pause = false;
        Move.paused = false;
    }
    public void MainMenu()
    {
        Application.LoadLevel(0);
        Move.paused = false;
    }
    public void Mute()
    {
        mute = !mute;
    }
}
