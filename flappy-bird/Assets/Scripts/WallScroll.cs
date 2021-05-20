using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScroll : MonoBehaviour {

    private Rigidbody2D rbWall;
    

    // Use this for initialization
    void Start () {
        // move walls toward bird
        rbWall = GetComponent<Rigidbody2D>();
        rbWall.velocity = new Vector2(GameController.instance.scrollSpeed, 0);
    }

}
