using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeOfMove
{
    FourDirectionMove
}

public class PlayerMovementTest : MonoBehaviour
{
    public TypeOfMove typeOfMove;
    public float speed;
    float Xmove;
    float Zmove;

    Vector3 moveDir;

    bool isGrounded, isJumping;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = GetComponent<GroundDetector>().isGrounded;
        isJumping = GetComponent<GroundDetector>().isJumping;

        Xmove = Input.GetAxisRaw("Horizontal");
        Zmove = Input.GetAxisRaw("Vertical");

        moveDir = new Vector3(Xmove, 0, Zmove).normalized;

        switch (typeOfMove)
        {
            case TypeOfMove.FourDirectionMove:
                FourDirectionMove();
                break;
        }
    }


    void FourDirectionMove()
    {
        if(moveDir.magnitude >0 && isGrounded == true)
        {
            transform.Translate(moveDir.normalized * speed * Time.deltaTime, Space.World);
        }

        else
        {
            transform.Translate(Vector3.zero);
        }
    }

}
