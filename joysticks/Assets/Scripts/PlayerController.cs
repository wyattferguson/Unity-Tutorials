using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private float speed = 1000f;
    private Rigidbody2D rbPlayer;
    private Vector2 screenTop;
    private Vector2 screenBottom;
    private float shipHeight;
    private float shipWidth;
    

    void Start () {
        rbPlayer = GetComponent<Rigidbody2D>();
        screenBottom = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        screenTop = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        shipHeight = transform.localScale.y / 2;
        shipWidth = transform.localScale.x / 2;
    }
	

	void Update () {
        // Left Stick Movement
        float moveY = Input.GetAxisRaw("Vertical");
        float moveX = Input.GetAxisRaw("Horizontal");

        // Right Stick Movement
        float gunY = Input.GetAxisRaw("RightStickY");
        float gunX = Input.GetAxisRaw("RightStickX");

        // Player Position
        float shipY = transform.position.y;
        float shipX = transform.position.x;

        // Top & Bottom Screen Collision Detection
        if (shipY > screenTop.y - shipHeight && moveY > 0) {
            moveY = 0;
        }else if (shipY < screenBottom.y + shipHeight && moveY < 0) {
            moveY= 0;
        }

        // Right & Left Screen Collision Detection
        if (shipX > screenTop.x - shipWidth && moveX > 0) {
            moveX = 0;
        }else if (shipX < screenBottom.x + shipWidth && moveX< 0) {
            moveX = 0;
        }

        // Rotate Gun
        float gunAngle = Mathf.Atan2(gunX, gunY) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, gunAngle);

        // Move Player
        rbPlayer.velocity = new Vector3(moveX, moveY, 0) * speed * Time.deltaTime;
    }
}
