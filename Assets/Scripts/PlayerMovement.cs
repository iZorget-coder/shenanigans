using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public PlayerInput input;
    InputAction action;
    [SerializeField] float playerSpeed = 5f;
    public Vector2 playerRotation;
    GameObject playerCamera;
    public float mouseSensitivity = 5f;
    void Start()

        ///
    {
        input = GetComponent<PlayerInput>();
        action = input.actions.FindAction("Move");
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera");

       Cursor.lockState = CursorLockMode.Locked;  
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }
    public void MovePlayer()
    {
        Vector2 direction = (action.ReadValue<Vector2>());
        transform.position += new Vector3(direction.x, 0, direction.y) * playerSpeed * Time.deltaTime;

        playerRotation.x += Input.GetAxis("Mouse Y"); ;
        playerRotation.y += Input.GetAxis("Mouse X") ;
        transform.localRotation = Quaternion.Euler(0, playerRotation.y, 0);
        playerCamera.transform.localRotation = Quaternion.Euler( playerRotation.x, playerRotation.y, 0);


    }
}
