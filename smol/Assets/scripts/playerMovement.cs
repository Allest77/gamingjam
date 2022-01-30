using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {
    //Publics
    public float speed = 8f, jumpHeight = 3.2f, jumpForce = 20, gravity = -20.0f;
    public bool isGrounded = true;
    public GameObject phase1;
    public GameObject phase2;

    //Privates
    Rigidbody rb;
    private bool switched;

    void Start() {
        //GetComponents
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        //Move horizontally.
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(hInput, 0.0f, vInput);
        rb.MovePosition(transform.position + movement * Time.deltaTime * speed);

        
    }

    private void Update()
    {
        //Jump input.
        if ((Input.GetButtonDown("Jump") && isGrounded) || (Input.GetButtonDown("Switch") && isGrounded))
        {
            isGrounded = false;
            GetComponent<Rigidbody>().AddForce(transform.TransformDirection(Vector3.up) * jumpHeight * jumpForce);
            Debug.Log("Jumping");
        }

        if (Input.GetButtonDown("Fire3") && !switched)
        {
            phase1.SetActive(false);
            phase2.SetActive(true);
            switched = true;
        }
        else if(Input.GetButtonDown("Fire3") && switched)
        {
            phase1.SetActive(true);
            phase2.SetActive(false);
            switched = false;
        }

        if (Input.GetButtonDown("Switch"))
        {
            gravity = gravity * -1;
            jumpHeight = jumpHeight * -1;
            jumpForce = jumpForce * -1;
            gameObject.transform.localScale = new Vector3(1, gameObject.transform.localScale.y * -1, 1);
            Physics.gravity = new Vector3(0, Physics.gravity.y * -1, 0);
        }

        //Tells the game to multiply player's gravity on the y-axis, whenever they aren't grounded.
        if (Input.GetButtonUp("Jump") && !isGrounded)
        {
            GetComponent<Rigidbody>().AddForce(transform.TransformDirection(Vector3.down) * gravity);
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
