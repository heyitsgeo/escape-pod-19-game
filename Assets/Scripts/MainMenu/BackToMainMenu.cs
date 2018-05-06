using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackToMainMenu : MonoBehaviour,
    IPointerClickHandler,
    IPointerEnterHandler
{
    private Text text;

	private void Awake()
	{
        text = this.GetComponent<Text>();
	}

    public void OnPointerEnter(PointerEventData eventData) {
        Debug.Log("Pointer Enter");
        Color textColor = text.color;
        textColor.a = 0.75f;
        text.color = textColor;
    }

	public void OnPointerClick(PointerEventData eventData)
    {
        try
        {
            SceneManager.LoadScene(0);
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }
}
