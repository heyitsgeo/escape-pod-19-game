namespace Assets.Scripts.Controllers
{
  using System;
  using System.Collections;
  using System.Collections.Generic;
  using UnityEngine;
  using UnityEngine.UI;
  using UnityEngine.SceneManagement;
  using Assets.Scripts.Models;

  public class LevelSelection : MonoBehaviour
  {
    public Canvas canvas;

    public Button UnlockedPrefab;
    public Button LockedPrefab;

    public List<LevelModel> Levels;

    public int buttonPadding = 10;
    public int firstButtonLeftEdge = 250;

    // Use this for initialization
    void Start()
    {
      int levelCount = 0;
      foreach (LevelModel level in Levels)
      {

        Button newButton = level.Locked ? (Button)Instantiate(LockedPrefab) : (Button)Instantiate(UnlockedPrefab);
        RectTransform buttonTransform = newButton.GetComponent<RectTransform>();

        float buttonWidth = buttonTransform.rect.width;

        // Disabled button if locked.
        if (level.Locked)
        {
          newButton.enabled = false;
        }

        newButton.transform.SetParent(canvas.transform, false);

        buttonTransform.anchorMax = new Vector2(0, 0.5f);
        buttonTransform.anchorMin = new Vector2(0, 0.5f);
        buttonTransform.anchoredPosition = new Vector2((firstButtonLeftEdge + ((buttonWidth + buttonPadding) * levelCount)), 0);
        //newButton.transform.position = new Vector3(100, transform.position.y, transform.position.z);
        newButton.GetComponentInChildren<Text>().text = level.LevelName;

        newButton.onClick.AddListener(delegate { LoadLevel(level.SceneName); });

        levelCount++;
      }
    }

    // Update is called once per frame
    void LoadLevel(string sceneName)
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
