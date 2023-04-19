using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeOfMove
{
    FourDirectionMove, freeDirectionMove
}

public class PlayerMovement : MonoBehaviour
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
                TurnPlayerBody();
                FourDirectionMove();
                break;

            case TypeOfMove.freeDirectionMove:
                FreeDirectionMove();
                break;
        }
    }

    void FourDirectionMove()
    {


        isGrounded = GetComponent<PlayerGroundDetector>().isGrounded;
        isJumping = GetComponent<PlayerJump>().isJumping;

        
        if (isGrounded == true || isGrounded == false && isJumping == true)
        {
            if (forward == true)
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
            }

            if (back == true)
            {
                transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);
            }

            if (left == true)
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
            }

            if (right == true)
            {
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
        if (Input.GetKey(KeyCode.Z) && back == false && left == false && right == false)
        {
            forward = true;
            body.transform.localEulerAngles = new Vector3(0, 0, 0);
        }

        if (Input.GetKey(KeyCode.S) && forward == false && left == false && right == false)
        {
            back = true;
            body.transform.localEulerAngles = new Vector3(0, 180, 0);

        }

        if (Input.GetKey(KeyCode.Q) && back == false && forward == false && right == false)
        {
            left = true;
            body.transform.localEulerAngles = new Vector3(0, -90, 0);
        }

        if (Input.GetKey(KeyCode.D) && back == false && left == false && forward == false)
        {
            right = true;
            body.transform.localEulerAngles = new Vector3(0, 90, 0);
        }


        if (Input.GetKeyUp(KeyCode.Z))
        {
            forward = false;
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            back = false;
        }

        if (Input.GetKeyUp(KeyCode.Q))
        {
            left = false;
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            right = false;
        }
    }

    void FreeDirectionMove ()
    {
        isGrounded = GetComponent<PlayerGroundDetector>().isGrounded;
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
