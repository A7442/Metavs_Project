using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator animator;
    Rigidbody2D _rigidbody;

    public float flapForce = 6.0f;
    public float forwardSpeed = 3.0f;
    public bool isDead = false;
    float deathCooldown = 0f;

    bool isFlap = false;

    public bool godMode = false;

    GameManager1 gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager1.Instance;
        animator = GetComponentInChildren<Animator>();//하위 오브젝트에 있는 컴포넌트 가져오기
        _rigidbody = GetComponent<Rigidbody2D>();//get component : 플레이어에 있는 컴포넌트 가져오기

        if(animator == null)
        {
            Debug.LogError("Not Founded Animator");
        }
        if (_rigidbody == null)
        {
            Debug.LogError("Not Founded Rigidbody");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameStart)
        {
            if (isDead)
            {
                if (deathCooldown <= 0)
                {
                    if (Input.GetKeyDown(KeyCode.R) || Input.GetMouseButtonDown(0))
                    {
                        gameManager.RestartGame();
                    }
                }
                else
                {
                    deathCooldown -= Time.deltaTime;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))//0번은 좌클릭, 1번은 우클릭, 2번은 휠클릭,3,4번은 뒤로가기 앞으로가기
                {
                    isFlap = true;
                }
            }
        }
        else
        {
            transform.position = Vector3.zero;
            _rigidbody.velocity = Vector3.zero;
        }
    }
    private void FixedUpdate()
    {
        if (gameManager.isGameStart)
        {
            if (isDead) return;

            Vector3 velocity = _rigidbody.velocity;
            velocity.x = forwardSpeed;
            if (isFlap)
            {
                velocity.y += flapForce;
                isFlap = false;
            }
            _rigidbody.velocity = velocity;
            float angle = Mathf.Clamp((_rigidbody.velocity.y * 10), -90, 90);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        else
        {
            _rigidbody.velocity = Vector3.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (godMode) return;
        if (isDead == true) return;

        isDead = true;
        deathCooldown = 1.0f;

        animator.SetInteger("isDie", 1);
        gameManager.GameOver();
    }
}
