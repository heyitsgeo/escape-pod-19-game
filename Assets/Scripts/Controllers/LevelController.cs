namespace Assets.Scripts.Controllers
{
    using Assets.Scripts.Models;
    using System;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.SceneManagement;

    public class LevelController : MonoBehaviour
    {
        [SerializeField]
        private Canvas _canvas;

        [SerializeField]
        private Button _unlockedPrefab;

        [SerializeField]
        private Button _lockedPrefab;

        [SerializeField]
        public List<LevelModel> _levels;

        public int buttonPadding = 10;
        public int firstButtonLeftEdge = 250;

        // Use this for initialization
        protected void Start()
        {
            int levelCount = 0;
            foreach (LevelModel level in _levels)
            {
                Button newButton = level.Locked ? (Button)Instantiate(_lockedPrefab) : (Button)Instantiate(_unlockedPrefab);
                RectTransform buttonTransform = newButton.GetComponent<RectTransform>();

                float buttonWidth = buttonTransform.rect.width;

                // Disabled button if locked.
                if (level.Locked)
                {
                    newButton.enabled = false;
                }

                newButton.transform.SetParent(_canvas.transform, false);

                buttonTransform.anchorMax = new Vector2(0, 0.5f);
                buttonTransform.anchorMin = new Vector2(0, 0.5f);
                buttonTransform.anchoredPosition = new Vector2((firstButtonLeftEdge + ((buttonWidth + buttonPadding) * levelCount)), 0);
                newButton.GetComponentInChildren<Text>().text = level.LevelName;

                newButton.onClick.AddListener(delegate { LoadLevel(level.SceneName); });

                levelCount++;
            }
        }

        // Update is called once per frame
        protected void LoadLevel(string sceneName)
        {
            try
            {
                SceneManager.LoadScene(sceneName);
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }
        }
    }
}
