using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : BaseController
{
    private Camera camera;
    private float delay = 0.3f;
    private float nextTime = 0f;

    protected override void Start()
    {
        base.Start();
        camera = Camera.main;
    }

    protected override void FixedUpdate()
    {
        Jumping();
        base.FixedUpdate();
    }
    void OnMove(InputValue inputValue)
    {
        movementDirection = inputValue.Get<Vector2>();
        movementDirection = movementDirection.normalized;
    }

    private void Jumping()
    {
        if(Input.GetKey(KeyCode.Space) && nextTime >= delay)
        {
            isJumping = true;
            nextTime = 0f;

        }
        nextTime += Time.deltaTime;
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }

    void OnInteraction()
    {
        
    }
}
