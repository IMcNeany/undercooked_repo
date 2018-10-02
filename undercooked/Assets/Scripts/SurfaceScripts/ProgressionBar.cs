using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressionBar : MonoBehaviour {

    float progress = 0;
    Transform progressBar;
    SpriteRenderer barColour;
    // Use this for initialization
    void Start () {
        progressBar = this.gameObject.transform.GetChild(0);
        barColour = progressBar.GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
		if(progress > 0.9)
        {
          barColour.color = Color.green;
        }
        else
        {
            barColour.color = Color.red;
            progressBar.localScale = new Vector3(progress, 0.9f, 1.0f);
        }
	}

    public void CalculateProgress(float number,float total)
    {
        //progress calculation left in 0. not percentage
        progress = number / total;

    }
}
