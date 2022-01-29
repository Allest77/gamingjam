using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {
    //Publics
    public float speed = 8f, jumpHeight = 3.2f, jumpForce = 20, gravity = -20.0f;
    public bool isGrounded = true;
    //public SoundManager jump;

    //Privates
    Rigidbody rb;
    private Vector3 direction;

    void Start() {
        //GetComponents
        rb = GetComponent<Rigidbody>();
        //jump = GameObject.FindObjectOfType<SoundManager>();
    }

    void Update() {
        //Move horizontally.
        float hInput = Input.GetAxis("Horizontal");
        direction.x = hInput * speed;

        //Jump input.
        if (Input.GetButtonDown("Jump") && isGrounded) {
            direction.y = (jumpHeight * jumpForce);
            Debug.Log("Jumping");
        }

        //Tells the game to multiply player's gravity on the y-axis, whenever they aren't grounded.
        if (!isGrounded) {
            direction.y += gravity * Time.deltaTime;
        }
    }

    //To prevent infinite jumping while hugging a wall:
    void OnCollisionEnter(Collision hit) {
        if (hit.gameObject.CompareTag("Wall")) {
            isGrounded = false;
        }
        else {
            isGrounded = true;
        }
    }
}
