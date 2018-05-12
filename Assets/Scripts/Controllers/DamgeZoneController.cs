using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamgeZoneController : MonoBehaviour
{

  public float waitTimeInSeconds = 1;
  public float increaseScaleSize = 5;

  // Use this for initialization
  void Start()
  {
    StartCoroutine(IncreaseDamageZoneSize());
  }

  private IEnumerator IncreaseDamageZoneSize()
  {
    while (true)
    {
      yield return new WaitForSeconds(waitTimeInSeconds);

      int scaleDirection = Random.Range(0, 1);
      Debug.Log("Update Size");
      Vector3 currentScale = transform.localScale;
      Vector3 currentPosition = transform.localPosition;

      if (scaleDirection == 0)
      {
        currentScale.y += increaseScaleSize;
        float currentY = currentPosition.y;
        currentY -= increaseScaleSize / 2;
        currentPosition.y = currentY;
      }
      else
      {
        //currentScale.x += increaseScaleSize;
      }
      transform.localPosition = currentPosition;
      transform.localScale = currentScale;
    }
  }
}
