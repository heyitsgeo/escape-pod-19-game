namespace Assets.Scripts.Controllers
{
  using UnityEngine;

  public class FollowCamera : MonoBehaviour
  {
    public Transform player;
    public Vector3 offset;

    protected void Update()
    {
      transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z);
    }
  }
}
