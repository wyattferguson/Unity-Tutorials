using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rbPlayer;
    private Animator anim;
    public float speed = 3f;
    public float jumpForce = 3f;
    private bool isDead = false;
    private bool isGrounded = true;

    // Use this for initialization
    void Start () {
        rbPlayer = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}

    private void OnCollisionEnter2D(Collision2D collision) {
        isGrounded = true;
        anim.SetBool("isJumping", false);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Enemy") {
            Debug.Log("Enemy");
            isDead = true;
        } else {
            Debug.Log("Item");
        }
        isGrounded = true;

    }

    // Update is called once per frame
    void FixedUpdate() {
        
        if (Input.GetButton("Horizontal")) {
            float move = Input.GetAxis("Horizontal") * Time.deltaTime * this.speed;
            transform.Translate(move * Vector2.right);
            anim.SetFloat("speed", 1);
            //Debug.Log(shipY + " " + this.screenTop.y + " " + this.screenBottom.y);
        } else {
            anim.SetFloat("speed", 0);
        }
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true) {
            rbPlayer.AddForce(new Vector2(0.0f, 2.0f) * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            anim.SetBool("isJumping", true);
        } else {
            anim.SetBool("isJumping", false);
        }
    }
}
