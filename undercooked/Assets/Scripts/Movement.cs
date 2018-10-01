using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    private Quaternion rotationDirection;
    private InputManager input;
    // Use this for initialization
    void Start () {
       input = GetComponent<InputManager>();
    }
	
	// Update is called once per frame
	void Update () {
        UpdateMovement();
	}

    void UpdateMovement()
    {
        InputManager input = GetComponent<InputManager>();
        Vector3 movement = new Vector3(input.getHorizontal(), input.getVertical(), 0);
        transform.position += movement * 5 * Time.deltaTime;
        transform.rotation = rotationDirection;
    }
}
