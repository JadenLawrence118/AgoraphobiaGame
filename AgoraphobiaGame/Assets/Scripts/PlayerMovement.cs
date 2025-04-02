using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    private static PlayerMovement self;

    public float baseSpeed = 1;
    public float sprintSpeed = 2;
    public float baseWalkAudioPitch = 1;
    public float sprintWalkAudioPitch = 2;
    private float moveSpeed = 1;

    public Transform orientation;

    private float horizontalInput;
    private float verticalInput;

    private Vector3 moveDirection;

    private AudioSource footstepAudio;

    private Rigidbody rb;

    private Globals globals;

    private CloseEyes closeEyes;


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (self == null)
        {
            self = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        moveSpeed = baseSpeed;
        globals = GameObject.FindGameObjectWithTag("GameController").GetComponent<Globals>();
        closeEyes = GameObject.FindGameObjectWithTag("GameController").GetComponent<CloseEyes>();
        footstepAudio = GetComponent<AudioSource>();
        footstepAudio.enabled = false;
    }

    void Update()
    {
        // destroys if game is beaten. This allows for reset for play again
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            globals.eyesUI.SetActive(true);
            Destroy(globals.eyesUI);
            Destroy(gameObject);
        }

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
            footstepAudio.pitch = sprintWalkAudioPitch;
        }
        else
        {
            moveSpeed = baseSpeed;
            footstepAudio.pitch = baseWalkAudioPitch;
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

        // footstep audio
        if (horizontalInput != 0 || verticalInput != 0)
        {
            footstepAudio.enabled = true;
        }
        else
        {
            footstepAudio.enabled = false;
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
