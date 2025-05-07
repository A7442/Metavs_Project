using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine.Windows;

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

    UIManagerMain _uiManagerMain;
    public UIManagerMain UIManagerMain { get { return _uiManagerMain; } }
    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        animationHandler = GetComponent<AnimationHandler>();
        _uiManagerMain = FindAnyObjectByType<UIManagerMain>();
    }

    protected virtual void Start()
    {
        if(PlayerPosition.playerposition !=null)
        {
            transform.position = PlayerPosition.playerposition;
        }
        else
        {
            transform.position = new Vector2(0, 0);
        }
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
        //������ ���� �������� ���߿� layer�� ���� �ٸ��� ó���� �� �ֵ��� ������� �ߴ�.
        if (hit.collider!= null)
        {
            string layerName = LayerMask.LayerToName(hit.collider.gameObject.layer);
            Transform hittransform = hit.collider.transform;
            canvas = hittransform.GetComponentInChildren<Canvas>(true);
            if (canvas != null)
            {
                canvas.gameObject.SetActive(true);
            }
            string hitcollider = hit.collider.gameObject.name;
            string numberStr = new string(hitcollider.Where(char.IsDigit).ToArray());
            int number = int.Parse(numberStr);
            if (layerName == "Game")
            {
                if (isInteracting)
                {
                    if (number == 1)//���� ó�� ���ؼ� ���� if��
                    {
                        PlayerPosition.playerposition = transform.position;
                        SceneManager.LoadScene($"MiniGameScene{numberStr}");
                        isInteracting = false;
                    }
                    else
                    {
                        Debug.Log("�˼��մϴ� ���� ����ó���� ���޾�� �Ф�");
                        isInteracting = false;
                    }
                }
            }
            else if (layerName == "Board")
            {
                if (isInteracting)
                {
                    _uiManagerMain.SetBoard(number);
                    isInteracting = false;
                }
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
