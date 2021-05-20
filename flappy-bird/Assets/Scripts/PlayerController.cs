using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    private float lift = 150.0f;
    private Rigidbody2D bird;
    private Animator anim;

	// Use this for initialization
	void Start () {
        bird = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}

    // Gets called before physics are applied every frame
    void FixedUpdate() {
        if (!GameController.instance.dead) {
            if (Input.GetButton("Vertical")) {
                bird.velocity = Vector2.zero;
                bird.AddForce(new Vector2(0, this.lift));
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D coll) {
        anim.SetBool("Crash", true);
        GameController.instance.BirdDied();

    }

    private void OnTriggerEnter2D(Collider2D coll) {
        GameController.instance.BirdScored();
    }
}
