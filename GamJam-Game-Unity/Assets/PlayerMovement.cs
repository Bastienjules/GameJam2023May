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

    [Header("GroundDetection")]
    public Transform groundBox;
    public LayerMask groundLayer;
    public float groundBoxSize = 1;
    Vector3 groundDetectionRadius;
    bool isGrounded;


    [Header("Sield")]
    bool shieldMove = false;
    public GameObject shield;

    [Header("PlayerRot")]
    Transform theCam;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

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
                theCam.GetComponent<CameraBehaviour>().canRot = true;
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
            //MultiDirMovement();
        }
    }

    void FourDirMovement()
    {
        if(Input.GetKey(KeyCode.Z))
        {
            move = true;
            transform.localEulerAngles = new Vector3(0, 0, 0);
            if(isGrounded == true)
            {
                rb.velocity = Vector3.forward * speed;
            }

            else
            {
                NoMove();
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            move = true;
            transform.localEulerAngles = new Vector3(0, 180, 0);
            if (isGrounded == true)
            {
                rb.velocity = Vector3.back * speed;
            }

            else
            {
                NoMove();
            }
        }

        if (Input.GetKey(KeyCode.Q))
        {
            move = true;
            transform.localEulerAngles = new Vector3(0, -90, 0);
            if (isGrounded == true)
            {
                rb.velocity = Vector3.left * speed;
            }

            else
            {
                NoMove();
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            move = true;
            transform.localEulerAngles = new Vector3(0, 90, 0);
            if (isGrounded == true)
            {
                rb.velocity = Vector3.right * speed;
            }

            else
            {
                NoMove();
            }
        }

        if(move == true)
        {

        }

        else
        {

        }
    }

    void MultiDirMovement()
    {
        float moveZ = 0;
        float moveX = 0;

        if (Input.GetKey(KeyCode.Z))
        {
            moveZ += 1;
        }

        if (Input.GetKey(KeyCode.S))
        {
            moveZ -= 1;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            moveX -= 1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveX += 1;
        }

        Vector3 direction = new Vector3(moveX, transform.position.y, moveZ).normalized;

        if(isGrounded == true && direction.magnitude >0.1)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + theCam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            rb.velocity = direction * speed;
        }

        else
        {
            NoMove();
        }
    }

    void GroundDetection()
    {
        groundDetectionRadius = new Vector3(groundBoxSize, groundBoxSize, groundBoxSize);
        isGrounded = Physics.CheckBox(groundBox.position, groundDetectionRadius / 2, Quaternion.identity, groundLayer);
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
        rb.velocity = Vector3.zero;
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(groundBox.position, groundDetectionRadius);
    }
}
