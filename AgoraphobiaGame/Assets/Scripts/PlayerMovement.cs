using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float baseSpeed = 1;
    public float sprintSpeed = 2;
    private float moveSpeed = 1;

    public Transform orientation;

    private float horizontalInput;
    private float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    private Globals globals;

    private CloseEyes closeEyes;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        moveSpeed = baseSpeed;
        globals = GameObject.FindGameObjectWithTag("GameController").GetComponent<Globals>();
        closeEyes = GameObject.FindGameObjectWithTag("GameController").GetComponent<CloseEyes>();
    }

    void Update()
    {
        // speed cap
        Vector3 flatVelocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);

        if (flatVelocity.magnitude > moveSpeed)
        {
            Vector3 velocityLimit = flatVelocity.normalized * moveSpeed;
            rb.velocity = new Vector3(velocityLimit.x, rb.velocity.y, velocityLimit.z);
        }

        // sprinting
        if (Input.GetAxisRaw("Sprint") > 0)
        {
            moveSpeed = sprintSpeed;
        }
        else
        {
            moveSpeed = baseSpeed;
        }

        // calling the CloseEyes function and setting all necessary variables
        if (Input.GetAxisRaw("CloseEyes") > 0)
        {
            if (globals.realWorld)
            {
                globals.realPos = transform.position;
                globals.realRot = transform.GetChild(0).eulerAngles;
            }
            else
            {
                globals.imaginePos = transform.position;
                globals.imagineRot = transform.GetChild(0).eulerAngles;
            }
            closeEyes.Eyes();
        }
    }

    private void FixedUpdate()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        rb.AddForce(moveDirection.normalized * moveSpeed, ForceMode.Force);
    }
}
