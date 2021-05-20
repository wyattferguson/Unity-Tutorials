using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidScroll : MonoBehaviour {

    private Rigidbody2D rbAstroid;
    private int minSpeed = 1;
    private int maxSpeed = 15;


	// Use this for initialization
	void Start () {
        int speed = Random.Range(minSpeed, maxSpeed);
        rbAstroid = GetComponent<Rigidbody2D>();
        rbAstroid.velocity = new Vector2(-speed, 0);
	}
	
}
