using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    private float speed = 8f;
    public bool isPlayer;
    public Ball ball;
    private Rigidbody2D rbBall;

    void Start() {
        if (isPlayer == false) {
            rbBall = ball.GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    void Update () {
        float move = Input.GetAxis("Vertical");

        if (this.isPlayer) {
            move = Input.GetAxis("Vertical");
        } else {
            move = this.FollowBall();
        }

        move = move * Time.deltaTime * this.speed;
        transform.Translate(move * Vector2.up);
    }

    // AI Method that trys to mirror ball Y position
    private float FollowBall() {
        float move = 0f;
        if (rbBall.position.y < this.transform.position.y) {
            move = Random.Range(-0.75f, -0.2f); // give AI movement a bit variability
        } else {
            move = Random.Range(0.2f, 0.6f); // give AI movement a bit variability
        }
        return move;
    }

}
