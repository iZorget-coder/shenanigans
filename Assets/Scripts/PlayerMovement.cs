using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class ThirdPersonMovenent : MonoBehaviour
{
    [Header("Player movement")]

    private Rigidbody rb;
    public Transform orientation;
    public float moveSpeed;

    public GameObject cam;
    float horizontalInput;
    float verticalInput;
    public Vector2 playerRotation;


    Vector3 moveDirection;


     void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }
    private void Update()
    {
        PlayerInput();
    }

    public void PlayerInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }
    public void FixedUpdate()
    {
            MovePlayer();
    }

    public void MovePlayer()
    {
        playerRotation.x += Input.GetAxis("Mouse Y");
        playerRotation.y += Input.GetAxis("Mouse X");

        transform.localRotation = Quaternion.Euler(0, playerRotation.y, 0);
        cam.transform.localRotation = Quaternion.Euler(playerRotation.x, playerRotation.y, 0);





        Quaternion camRotation = Quaternion.Euler(0f, cam.transform.eulerAngles.y, 0f);
        rb.MoveRotation(camRotation);

        // Calculate movement direction based on input
        Vector3 moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        moveDirection.Normalize(); // Normalize to ensure consistent speed in all directions

        // Apply force to move the player
        rb.AddForce(moveDirection * moveSpeed * 10f);
    }



}
