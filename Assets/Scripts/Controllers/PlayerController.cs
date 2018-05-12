namespace Assets.Scripts.Controllers
{
    using Assets.Scripts.Models;
    using UnityEngine;
    using UnityEngine.EventSystems;

    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private PlayerModel _player;

        private int stayCount = 0;

        public PlayerController()
        {
            _player = new PlayerModel();
        }

        [SerializeField]
        private bool characterHitItem;

        [SerializeField]
        private InventoryController _inventoryController;

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


        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "DamageZone")
            {
                stayCount += 1;
                Debug.Log(stayCount);
            }
            if (collision.CompareTag("AirTank"))
            {
                var item = collision.gameObject;
                var airTankItem = new ItemModel()
                {
                    sprite = item.GetComponent<SpriteRenderer>().sprite,
                    name = "Air Tank"
                };
                _inventoryController.AddItem(airTankItem);
                collision.gameObject.SetActive(false);
            }
        }
    }
}