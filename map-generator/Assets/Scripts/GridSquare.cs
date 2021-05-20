using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSquare : MonoBehaviour {
    private int status = 0;
    private bool selected = false;
    private SpriteRenderer gridColor;

    private Color grass = new Color(0.1058651f, 0.5754717f, 0.185575f,1f);
    private Color sand = new Color(0.6538216f, 0.6698113f, 0.2685564f, 1f);
    private Color water = new Color(0.1058823f, 0.2690988f, 0.5764706f,1f);
    private Color mountain = new Color(0.1742168f, 0.2735849f, 0.1907782f, 1f);
    private Color highlight = new Color(0.5764706f, 0.1058823f, 0.5612412f, 1f);
    private Color deepwater = new Color(0.04258634f, 0.1366434f, 0.3113208f, 1f);

    public void Awake() {
        gridColor = GetComponent<SpriteRenderer>();
    }

    public void SetGridType(int trigger) {
        status = trigger;
        SetColor();
    }

    private void OnMouseDown() {
        selected = !selected;
        SetColor();
        
    }

    private void SetColor() {
        if (selected == false) {
            if (status == -1) {
                gridColor.color = water;
            }else if(status == 0) {
                gridColor.color = sand;
            } else if(status == 1){
                gridColor.color = grass;
            } else if (status == -2) {
                gridColor.color = deepwater;
            } else {
                gridColor.color = mountain;
            }
        } else {
            gridColor.color = highlight;
        }


    }
}
