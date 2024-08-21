using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    PlayerInput input;
    InputAction action;
    void Start()
    {
        input = GetComponent<PlayerInput>();
        action = input.actions.FindAction("Move");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
