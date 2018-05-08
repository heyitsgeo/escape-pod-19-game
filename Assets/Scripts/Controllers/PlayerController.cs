namespace Assets.Scripts.Controllers
{
    using Assets.Scripts.Models;
    using UnityEngine;

    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private PlayerModel _player;

        public PlayerController()
        {
            _player = new PlayerModel();
        }

        protected void Start()
        {
            //_player.PlayerSpeed = 5;
            //_player.FacingRight = false;
            //_player.FacingUp = false;
        }

        // Update is called once per frame
        protected void FixedUpdate()
        {
            // Lock rotation. This prevents player from dragging against object and spinning.
            GetComponent<Rigidbody2D>().freezeRotation = true;
            // Zero out velocity to prevent player from sliding.
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            float moveVertical = Input.GetAxis("Vertical");
            float moveHorizontal = Input.GetAxis("Horizontal");

            if (moveVertical > 0 || moveVertical < 0)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, moveVertical * _player.PlayerSpeed);

                if (moveVertical > 0 && !_player.FacingUp)
                {
                    transform.rotation = Quaternion.Euler(new Vector3(0, 0, -180));
                    _player.FacingUp = true;
                }
                else if (moveVertical < 0 && _player.FacingUp)
                {
                    transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                    _player.FacingUp = false;
                }
            }

            if (moveHorizontal > 0 || moveHorizontal < 0)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(moveHorizontal * _player.PlayerSpeed, GetComponent<Rigidbody2D>().velocity.y);

                if (moveHorizontal > 0 && !_player.FacingRight)
                {
                    transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
                    _player.FacingRight = true;
                }
                else if (moveHorizontal < 0 && _player.FacingRight)
                {
                    transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90));
                    _player.FacingRight = false;
                }
            }
        }
    }
}