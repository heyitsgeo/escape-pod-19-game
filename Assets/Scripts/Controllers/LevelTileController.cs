namespace Assets.Scripts.Controllers
{
  using System.Collections;
  using System.Collections.Generic;
  using UnityEngine;

  public class LevelTileController : MonoBehaviour
  {
    private GameObject Player;


    protected void Start()
    {
      Player = GameObject.FindGameObjectWithTag("Player");
      Color tempColor = GetComponent<SpriteRenderer>().color;
      tempColor.a = 0;
      GetComponent<SpriteRenderer>().color = tempColor;
    }

    protected void FixedUpdate()
    {
      Color tempColor = GetComponent<SpriteRenderer>().color;
      if (Vector2.Distance(transform.position, Player.transform.position) < 3)
      {
        tempColor.a = 1;
        GetComponent<SpriteRenderer>().color = tempColor;
      }
      else if (Vector2.Distance(transform.position, Player.transform.position) < 6)
      {
        tempColor.a = 0.5f;
        GetComponent<SpriteRenderer>().color = tempColor;
      }
      else
      {
        StartCoroutine(FadeTo(0.0f, 0.25f));
      }
      GetComponent<SpriteRenderer>().color = tempColor;
    }

    IEnumerator FadeTo(float aValue, float aTime)
    {
      SpriteRenderer _renderer = GetComponent<SpriteRenderer>();
      float alpha = _renderer.color.a;

      Color tempColor = _renderer.color;
      for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
      {
        tempColor.a = Mathf.Lerp(alpha, aValue, t);
        _renderer.color = tempColor;
        yield return null;
      }
    }
  }
}
