using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    protected Rigidbody2D _rigidbody;

    [SerializeField] private SpriteRenderer chracterRenderer;
    
    protected Vector2 movementDirection = Vector2.zero;
    public Vector2 MovementDirection{ get { return movementDirection; } }

    protected AnimationHandler animationHandler;

    protected bool isJumping = false;
    protected bool isInteracting = false;

    [SerializeField] private float interactDistance = 1.0f;
    [SerializeField] private LayerMask interactLayer;

    private Canvas canvas;

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        animationHandler = GetComponent<AnimationHandler>();
    }

    protected virtual void Start()
    {
        
    }

    protected virtual void Update()
    {   
        Rotate(movementDirection);
        Interact();
    }

    protected virtual void FixedUpdate()
    {
        Movement(movementDirection);
        Jump();
    }

    private void Movement(Vector2 direction)
    {
        _rigidbody.velocity = new Vector3(direction.x, direction.y, 0) * 5f;
        animationHandler.Move(direction);
    }

    private void Jump()
    {
        if (isJumping == true)
        {
            animationHandler.Jump();
            isJumping = false;
        }
        else
        {
            return;
        }
    }

    private void Rotate(Vector2 direction)
    {
        if (direction != Vector2.zero)
        {
            float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            bool isLeft = Mathf.Abs(rotZ) > 90.0f;

            chracterRenderer.flipX = isLeft;
        }
    }

    private void Interact()
    {
        Vector2 direction = transform.up;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, interactDistance, interactLayer);
        if (hit.collider!= null)
        {
            Transform hittransform = hit.collider.transform;
            canvas = hittransform.GetComponentInChildren<Canvas>(true);
            if (canvas != null)
            {
                canvas.gameObject.SetActive(true);
            }

            if (isInteracting)
            {
                Debug.Log("øπ¿Ã~");
                isInteracting = false;
            }
        }
        else
        {
            if (canvas == null)
            {
                return;
            }
            canvas.gameObject.SetActive(false);
        }
    }
}
