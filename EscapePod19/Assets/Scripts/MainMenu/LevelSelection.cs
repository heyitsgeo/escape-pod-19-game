using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour {

    public Canvas canvas;
    public Button levels_UnlockedPrefab, levels_LockedPrefab;
    public List<Level> levels_levels;
    public int buttonPadding = 10;
    public int firstButtonLeftEdge = 250;

	// Use this for initialization
	void Start () {
        int levelCount = 0;
        foreach(Level level in levels_levels) {

            Button newButton = level.locked ? (Button)Instantiate(levels_LockedPrefab) : (Button)Instantiate(levels_UnlockedPrefab);
            RectTransform buttonTransform = newButton.GetComponent<RectTransform>();

            float buttonWidth = buttonTransform.rect.width;

            // Disabled button if locked.
            if (level.locked) {
                newButton.enabled = false;
            }

            newButton.transform.SetParent(canvas.transform, false);

            buttonTransform.anchorMax = new Vector2(0, 0.5f);
            buttonTransform.anchorMin = new Vector2(0, 0.5f);
            buttonTransform.anchoredPosition = new Vector2((firstButtonLeftEdge + ((buttonWidth + buttonPadding) * levelCount)), 0);
            //newButton.transform.position = new Vector3(100, transform.position.y, transform.position.z);
            newButton.GetComponentInChildren<Text>().text = level.levelName;

            newButton.onClick.AddListener(delegate { LoadLevel(level.sceneName); });

            levelCount++;
        }
	}
	
	// Update is called once per frame
	void LoadLevel (string sceneName) {
        try {
            SceneManager.LoadScene(sceneName);
        }
        catch(Exception e) {
            Debug.Log(e);
        }
	}
}
