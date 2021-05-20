using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnController : MonoBehaviour {

    public GameObject wallPrefab;

    private GameObject[] walls;
    private Vector2 startPosition = new Vector2(20, 20); // Spawn columns offscreen

    private int wallPoolSize = 10;
    private float spawnRate = 2f;
    private float spawnDelay = 0f;
    private float spawnX = 10f;
    private float colMin = -0;
    private float colMax = -5.5f;
    private int leadWall = 0;

    void Start () {
        // Create instances of walls
        this.walls = new GameObject[this.wallPoolSize];
        for(int i = 0; i < this.wallPoolSize; i++) {
            this.walls[i] = (GameObject)Instantiate(this.wallPrefab, this.startPosition, Quaternion.identity);
        }
        
    }
	
	// Update is called once per frame
	void Update () {

        // spawn in new wall after enough time has passed
        this.spawnDelay += Time.deltaTime;
        if(this.spawnDelay >= this.spawnRate) {
            this.spawnDelay = 0;
            float spawnY = Random.Range(this.colMin, this.colMax);
            this.walls[this.leadWall].transform.position = new Vector2(this.spawnX, spawnY);

            this.leadWall++;

            if (this.leadWall >= this.wallPoolSize) {
                this.leadWall = 0;
            }
        }

        
    }

}
