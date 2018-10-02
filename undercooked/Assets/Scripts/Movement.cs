using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    private Quaternion rotationDirection;
    private InputManager input;
    private Rigidbody2D rb2d;
    private Vector2 movement;
    public float speed = 5.0f;

    // Use this for initialization
    void Start () {
       input = GetComponent<InputManager>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        UpdateMovement();
	}

    void UpdateMovement()
    {
        InputManager input = GetComponent<InputManager>();
        movement = new Vector2(input.getHorizontal() * speed, input.getVertical() * speed);
        if(movement == Vector2.zero)
        {
            rb2d.velocity = Vector2.zero;
        }
     //   transform.position += movement * 5 * Time.deltaTime;
        transform.rotation = rotationDirection;
    }

    private void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + movement * Time.fixedDeltaTime);
    }
}

