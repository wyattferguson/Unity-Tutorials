using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroids : MonoBehaviour {

    public GameObject astroidPrefab;

    private GameObject[] astroids;

    private int maxAstroids = 40;
    private float spawnRate = 1f;
    private float spawnDelay = 0f;
    private float minSpawnY = -4f;
    private float maxSpawnY = 4f;
    private float spawnX = 12.0f;
    private int recentAstroid = 0;

    private float scaleMin = 0.10f;
    private float scaleMax = 1.0f;
    private int rotateMin = 0;
    private int rotateMax = 359;

	// Use this for initialization
	void Start () {
        Vector2 startPos = new Vector2(20, 20);
        astroids = new GameObject[maxAstroids];
        for (int i = 0; i < maxAstroids; i++) {
            astroids[i] = (GameObject)Instantiate(astroidPrefab, startPos, Quaternion.identity);
        }
        
    }
	
	// Update is called once per frame
	void Update () {
        spawnDelay += Time.deltaTime;
        if (spawnDelay >= spawnRate) {
            spawnDelay = 0;
            float spawnY = Random.Range(minSpawnY, maxSpawnY);
            float adjScale = Random.Range(scaleMin, scaleMax);
            float adjRotation = Random.Range(rotateMin,rotateMax);

            astroids[recentAstroid].transform.position = new Vector2(spawnX, spawnY); // set spawn position
            astroids[recentAstroid].transform.localScale = new Vector3(adjScale, adjScale, 1); // change astroid scale so they all look unique
            astroids[recentAstroid].transform.Rotate(0, 0, adjRotation); // rotate astroid to give each one a distinct pattern

            recentAstroid++;

            if (recentAstroid >= maxAstroids) {
                recentAstroid = 0;
            }
        }
    }
}
