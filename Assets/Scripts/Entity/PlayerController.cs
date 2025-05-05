using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : BaseController
{
    private Camera camera;

    protected override void Start()
    {
        base.Start();
        camera = Camera.main;
    }

    void OnMove(InputValue inputValue)
    {
        movementDirection = inputValue.Get<Vector2>();
        movementDirection = movementDirection.normalized;
    }

    void OnJump()
    {
        isJumping = true;
    }

    void OnInteraction()
    {
        if (this.transform.position == Vector3.zero)
        {
            Debug.Log("Interaction with the object");
        }
    }
}
