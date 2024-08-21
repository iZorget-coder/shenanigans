using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public PlayerInput input;
    InputAction action;
    [SerializeField] float playerSpeed = 5;
    void Start()
    {
        input = GetComponent<PlayerInput>();
        action = input.actions.FindAction("Move");

    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }
    public void MovePlayer()
    {
        Vector2 direction = action.ReadValue<Vector2>();
        transform.position += new Vector3(direction.x, 0, direction.y)  * playerSpeed * Time.deltaTime;
    }
}
