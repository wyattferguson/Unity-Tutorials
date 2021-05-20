using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour {

    private Rigidbody2D rbBall;
    private float speed = 5f;
    private Vector2 screenBottom;
    private Vector2 screenTop;

    public Text scoreBoard;
    public int playerScore = 0;
    public int cpuScore = 0;

	// Use this for initialization
	void Start () {
		scoreBoard = GameObject.Find("ScoreText").GetComponent<Text>();
        rbBall = GetComponent<Rigidbody2D>();

        screenBottom = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        screenTop = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        Debug.Log(screenTop - screenBottom);
        this.ResetBall();
	}
	
	// Update is called once per frame
	void Update () {
		// Player scores 
		if(transform.position.x < screenBottom.x){
			this.playerScore+=1; 
			this.ResetBall();
		}

		// CPU Scores
		if(transform.position.x > screenTop.x){
			this.cpuScore+=1;   
			this.ResetBall();
        }
	}

	private void ResetBall(){
        // Center ball
        float posY = Random.Range(screenBottom.y, screenTop.y);
		transform.position = new Vector2(0,posY);

        // Give random direction
        float xDir = Random.Range(0, 2) == 0 ? -1 : 1;
        float yDir = Random.Range(0, 2) == 0 ? -1 : 1;
        
        rbBall.velocity = new Vector2(xDir, yDir) * speed;

        // Update scoreboard
        scoreBoard.text = this.playerScore + " - " + this.cpuScore;
	}
}
