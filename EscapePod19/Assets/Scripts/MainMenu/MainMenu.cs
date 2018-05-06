using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public Button menu_StartButton, menu_QuitButton;
    public string menu_levelSceneName;

	// Use this for initialization
	void Start () {
        Button start = menu_StartButton.GetComponent<Button>();
        Button quit = menu_QuitButton.GetComponent<Button>();

        // Call start button handler on click
        start.onClick.AddListener(LoadLevelsScene);

        // Call quit button handle on click
        quit.onClick.AddListener(QuitGame);
	}
	
	// Update is called once per frame
	void LoadLevelsScene () {
        try
        {
            Debug.Log("Load Levels");
            SceneManager.LoadScene(menu_levelSceneName);
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
	}

    void QuitGame () {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
