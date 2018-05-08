namespace Assets.Scripts.Controllers
{
    using System;
    using UnityEngine;
    using UnityEngine.SceneManagement;
    using UnityEngine.UI;

    public class MainMenuController : MonoBehaviour
    {
        [SerializeField]
        private Button _startButton, _quitButton;

        [SerializeField]
        private string _levelScene;

        protected void Start()
        {
            Button start = _startButton.GetComponent<Button>();
            Button quit = _quitButton.GetComponent<Button>();

            // Call start button handler on click
            start.onClick.AddListener(LoadLevelsScene);

            // Call quit button handle on click
            quit.onClick.AddListener(QuitGame);
        }

        protected void LoadLevelsScene()
        {
            try
            {
                Debug.Log("Load Levels");
                SceneManager.LoadScene(_levelScene);
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }
        }

        protected void QuitGame()
        {
            Debug.Log("Quit Game");
            Application.Quit();
        }
    }
}
