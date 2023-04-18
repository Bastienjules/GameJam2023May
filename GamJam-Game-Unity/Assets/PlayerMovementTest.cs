using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeOfMove
{
    FourDirectionMove, freeDirectionMove
}

public class PlayerMovementTest : MonoBehaviour
{
    public TypeOfMove typeOfMove;
    public float speed;
    public Transform body;
    float Xmove;
    float Zmove;

    Vector3 moveDir;

    bool isGrounded, isJumping;
    Rigidbody rb;

    public bool forward, back, left, right;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (typeOfMove)
        {
            case TypeOfMove.FourDirectionMove:
                FourDirectionMove();
                TurnPlayerBody();
                break;

            case TypeOfMove.freeDirectionMove:
                FreeDirectionMove();
                TurnPlayerBody();
                break;
        }
    }

    void FourDirectionMove()
    {


        isGrounded = GetComponent<GroundDetector>().isGrounded;
        isJumping = GetComponent<PlayerJump>().isJumping;

        
        if (isGrounded == true || isGrounded == false && isJumping == true)
        {
            if (Input.GetKey(KeyCode.Z))
            {
                forward = true;
                transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
            }

            if (Input.GetKey(KeyCode.S))
            {
                back = true;
                transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);
            }

            if (Input.GetKey(KeyCode.Q))
            {
                left = true;
                transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
            }

            if (Input.GetKey(KeyCode.D))
            {
                right = true;
                transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
            }
        }

        else
        {
            NoMove();
        }
    }

    void TurnPlayerBody()
    {
        if (Zmove > 0)
        {
            body.transform.localEulerAngles = new Vector3(0, 0, 0);
        }

        if (Zmove < 0)
        {
            body.transform.localEulerAngles = new Vector3(0, 180, 0);
        }

        if (Xmove < 0)
        {
            body.transform.localEulerAngles = new Vector3(0, -90, 0);
        }

        if (Xmove > 0)
        {
            body.transform.localEulerAngles = new Vector3(0, 90, 0);
        }
    }

    void FreeDirectionMove ()
    {
        isGrounded = GetComponent<GroundDetector>().isGrounded;
        isJumping = GetComponent<PlayerJump>().isJumping;

        Xmove = Input.GetAxis("Horizontal");
        Zmove = Input.GetAxis("Vertical");

        moveDir = new Vector3(Xmove, 0, Zmove).normalized;

        if (moveDir.magnitude > 0 && isGrounded == true || moveDir.magnitude > 0 && isGrounded == false && isJumping == true)
        {
            transform.Translate(moveDir.normalized * speed * Time.deltaTime, Space.World);
        }

        else
        {
            transform.Translate(Vector3.zero);
        }
    }

    void NoMove()
    {

        forward = false;
        back = false;
        left = false;
        right = false;
        transform.Translate(Vector3.zero);
    }

}
