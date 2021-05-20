using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour {
    public GameObject blockPrefab;
    private Vector2 gridSize;

    [Range(0,1)]
    public float scale = 1;
    public int offsetX;
    public int offsetY;

    [Range(0,2)]
    public float gridSpacing;
    public bool generateMap = true;
    public int seed;

    [Range(1,2)]
    public float amplitude;

    private float blockWidth;
    private float blockHeight;
    private GameObject block;
    private Vector3 worldOffset;

    private enum terrain {deepwater = -2, water=-1, sand=0, grass=1, mountain=2};

    void Start() {
        System.Random prng = new System.Random(seed);
        offsetX += prng.Next(-1000, 1000);
        offsetY += prng.Next(-1000, 1000);

        // Get map offset so blocks spawn starting in bottom left corner
        worldOffset = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, 0f)) + new Vector3(0.5f, 0.5f, 0f);
        worldOffset.z = 0f;

        MakeGrid();
    }

    private void FixedUpdate() {
        // Use arrow keys to scroll over the map
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) {

            GameObject[] blocks = GameObject.FindGameObjectsWithTag("Grid");
            foreach(GameObject deadBlock in blocks) {
                Destroy(deadBlock);
            }

            offsetX += Mathf.CeilToInt(Input.GetAxisRaw("Horizontal"));
            offsetY += Mathf.CeilToInt(Input.GetAxisRaw("Vertical"));
            MakeGrid();
        }
    }

    public void MakeGrid() {
        // Change the size of the blocks
        blockPrefab.transform.localScale = new Vector3(scale, scale, scale);

        // Get new block width and height
        blockWidth = (float)blockPrefab.GetComponent<SpriteRenderer>().bounds.size.x;
        blockHeight = (float)blockPrefab.GetComponent<SpriteRenderer>().bounds.size.y;

        // Calculate the number of blocks you can fit on screen
        RectTransform map = GetComponent<RectTransform>();
        gridSize.x = Mathf.Ceil(map.rect.width / ((blockWidth + gridSpacing )* 50));
        gridSize.y = Mathf.Ceil(map.rect.height / ((blockHeight + gridSpacing) * 50 ));


        for (int x = 0; x < gridSize.x; x++) {
            for (int y = 0; y < gridSize.y; y++) {
                Vector3 blockPos = new Vector3(x * (blockWidth + gridSpacing), y * (blockWidth + gridSpacing), 0) + worldOffset;
                block = (GameObject)Instantiate(blockPrefab, blockPos, Quaternion.identity, this.transform);
                block.name = "GRID-" + x + "-" + y;
                if (generateMap == true) {
                    block = NoiseMap(block, x, y);
                }
            }
        }
    }

    private GameObject NoiseMap(GameObject block, int x, int y) {
        float sampleX = (x + offsetX) / (float)gridSize.x ;
        float sampleY = (y + offsetY) / (float)gridSize.y;

        float perlin = Mathf.PerlinNoise(sampleX, sampleY) * amplitude;

        if (perlin > 0.75) {
            block.GetComponent<GridSquare>().SetGridType((int)terrain.mountain);
        } else if (perlin > 0.50) {
            block.GetComponent<GridSquare>().SetGridType((int)terrain.grass);
        } else if(perlin >0.4){
            block.GetComponent<GridSquare>().SetGridType((int)terrain.sand);
        } else if (perlin > 0.2) {
            block.GetComponent<GridSquare>().SetGridType((int)terrain.water);
        } else {
            block.GetComponent<GridSquare>().SetGridType((int)terrain.deepwater);
        }
        return block;
    }

}
