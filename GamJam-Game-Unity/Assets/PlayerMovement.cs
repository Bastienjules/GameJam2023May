using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MovementType
{
    FourDirection, MultiDirection 
}

public class PlayerMovement : MonoBehaviour
{
    public MovementType movementType;
    bool fourdir, multidir;

    bool move = false;
    float speed;
    public float walkSpeed, runSpeed, shieldSpeed;
    public Transform Body;

    [Header("GroundDetection")]
    public Transform groundBox;
    public LayerMask groundLayer;
    public float groundBoxSize = 1;
    public float groundBoxHeight = 0.5f;
    Vector3 groundDetectionRadius;
    bool isGrounded;


    [Header("Sield")]
    public KeyCode shieldKey = KeyCode.Mouse1;
    bool shieldMove = false;
    public GameObject shield;

    [Header("PlayerRot")]
    Transform theCam;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    [Header("Jump")]
    public KeyCode jumpKey = KeyCode.Space;
    public bool isJumping;
    public float jumpForce;

    Rigidbody rb;
    void Start()
    {

        theCam = Camera.main.transform;

        switch (movementType)
        {
            case MovementType.FourDirection:
                fourdir = true;
                break;
            case MovementType.MultiDirection:
                multidir = true;
                theCam.GetComponentInParent<CameraBehaviour>().canRot = true;
                break;
        }

        rb = GetComponent<Rigidbody>();

        shield.SetActive(false);

    }


    void Update()
    {
        GroundDetection();
        ChangeSpeed();
        ShieldBehaviour();
    }

    private void FixedUpdate()
    {
        if (fourdir == true)
        {
            FourDirMovement();
        }

        if (multidir == true)
        {
            MultiDirMovement();
        }

        Jump();
    }

    void FourDirMovement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        if (moveZ > 0)
        {
            Body.transform.localEulerAngles = new Vector3(0, 0, 0);
        }

        if (moveZ < 0)
        {
            Body.transform.localEulerAngles = new Vector3(0, 180, 0);
        }

        if (moveX < 0)
        {
            Body.transform.localEulerAngles = new Vector3(0, -90, 0);
        }

        if (moveX > 0)
        {
            Body.transform.localEulerAngles = new Vector3(0, 90, 0);
        }

        Vector3 moveDir = new Vector3(moveX, transform.position.y, moveZ).normalized;

        if(isGrounded == true || isGrounded == false && isJumping == true)
        {
            if (moveDir.magnitude > 0)
            {
                //rb.velocity = moveDir * speed;
                transform.Translate(moveDir.normalized * speed * Time.fixedDeltaTime);
                move = true;
            }

            else
            {
                rb.velocity = Vector3.zero;
                move = false;
            }
        }

        else
        {
            NoMove();
        }
    }

    void MultiDirMovement()
    {
        float moveX = 0f;
        float moveZ = 0f;
        if (Input.GetKey(KeyCode.Z))
        {
            moveZ = +1f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            moveZ = -1f;

        }

        if (Input.GetKey(KeyCode.Q))
        {
            moveX = -1f;

        }

        if (Input.GetKey(KeyCode.D))
        {
            moveX = +1f;

        }

        Vector3 direction = new Vector3(moveX, 0, moveZ).normalized;

        bool isIdle = moveX == 0 && moveZ == 0;
        if (isIdle || isGrounded == false)
        {
            move = false;
            NoMove();
        }

        if (direction.magnitude >= 0.1f)
        {
            move = true;
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + theCam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

                if (isGrounded == true)
                {
                    rb.velocity = moveDir.normalized * speed;
                }
            }

        }

    void GroundDetection()
    {
        groundDetectionRadius = new Vector3(groundBoxSize, groundBoxHeight, groundBoxSize);
        isGrounded = Physics.CheckBox(groundBox.position, groundDetectionRadius / 2, Quaternion.identity, groundLayer);

        if(isGrounded == true)
        {
            isJumping = false;
        }
    }

    void ChangeSpeed()
    {
        if(Input.GetKey(KeyCode.LeftShift) && move == true )
        {
            if(shieldMove == true)
            {
                speed = shieldSpeed;
            }

            else
            {
                speed = runSpeed;
            }
        }

        else 
        {
            if (shieldMove == true)
            {
                speed = shieldSpeed;
            }

            else
            {
                speed = walkSpeed;
            }
        }
    }

    void ShieldBehaviour()
    {
        if(Input.GetKey(KeyCode.Mouse1))
        {
            shieldMove = true;
            shield.SetActive(true);
        }

        else
        {
            shieldMove = false;
            shield.SetActive(false);
        }
    }

    void NoMove()
    {
        rb.velocity = new Vector3(0, rb.velocity.y, 0);
    }

    void Jump()
    {
        if (isGrounded == true && Input.GetKey(jumpKey))
        {
            isJumping = true;
            rb.AddForce( Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(groundBox.position, groundDetectionRadius);
    }
}
