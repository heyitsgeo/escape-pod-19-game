using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public int playerSpeed = 4;
    private bool p_facingUp = false;
    private bool p_facingRight = false;

	// Use this for initialization
    void Start () {}
	
	// Update is called once per frame
	void FixedUpdate () {
        // Zero out veloxity to prevent player from sliding.
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");

        if (moveVertical > 0 || moveVertical < 0) {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, moveVertical * playerSpeed);

            if (moveVertical > 0 && !p_facingUp) {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, -180));
                p_facingUp = true;
            } else if (moveVertical < 0 && p_facingUp) {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                p_facingUp = false;
            }
        }

        if (moveHorizontal > 0 || moveHorizontal < 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveHorizontal * playerSpeed, GetComponent<Rigidbody2D>().velocity.y);

            if (moveHorizontal > 0 && !p_facingRight)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
                p_facingRight = true;
            }
            else if (moveHorizontal < 0 && p_facingRight)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90));
                p_facingRight = false;
            }
        }
	}
}
