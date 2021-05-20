using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rb2d;
    private int score = 0;

    public Text scoreText;
    public Text winText;
    public float speed = 10;

    private void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        winText.text = "";
        SetScoreText();
    }

    // Gets called before physics are applied every frame
    void FixedUpdate() {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        Vector2 move = new Vector2(moveX, moveY);
        rb2d.AddForce(move * this.speed);
    }

    // Called when player hits something
    private void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.CompareTag("PickUp")) {
            this.score += 1;
            coll.gameObject.SetActive(false);
            SetScoreText();
        }
    }

    void SetScoreText() {
        scoreText.text = "Count: " + score.ToString();
        if (score >= 8) {
            winText.text = "You Win!";
        }
    }
}
