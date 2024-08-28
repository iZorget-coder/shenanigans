using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    [Header("Player Movement")]
    private Rigidbody rb;
    public Transform orientation;
    public float moveSpeed = 200f;

    public GameObject cam;
    private float horizontalInput;
    private float verticalInput;
    public Vector2 playerRotation;

    private Vector3 moveDirection;

    public Animator animator;
    public BoxCollider playerBox;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        Cursor.lockState = CursorLockMode.Locked;
        playerBox = GetComponent<BoxCollider>();    
    }

    void Update()
    {
        PlayerInput();
        RotatePlayer();
    }

    void PlayerInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void RotatePlayer()
    {
        // Rotating the player and the camera
        playerRotation.x -= Input.GetAxis("Mouse Y");
        playerRotation.y += Input.GetAxis("Mouse X");

        // Clamp the vertical rotation (X-axis)
        playerRotation.x = Mathf.Clamp(playerRotation.x, -90f, 90f);

        // Rotate the player (Y-axis)
        transform.localRotation = Quaternion.Euler(0f, playerRotation.y, 0f);

        // Rotate the camera (X-axis only)
        if (playerRotation.x < 90f)
        {
            cam.transform.localRotation = Quaternion.Euler(playerRotation.x, 0f, 0f);
        }
        
    }

    void MovePlayer()
    {
        animator.SetFloat("speed", verticalInput);
        if(verticalInput != 0f)
        {
            playerBox.size = new Vector3(playerBox.size.x, 1.690556f, playerBox.size.z);
        } else
        {
            playerBox.size = new Vector3(playerBox.size.x, 2.23f,playerBox.size.z);
        }
      

        // Calculate movement direction based on input
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        
        moveDirection.Normalize(); // Normalize to ensure consistent speed in all directions

        // Set the player's velocity based on input
        rb.velocity = moveDirection * moveSpeed * Time.fixedDeltaTime * 100f;
       
    }
}
