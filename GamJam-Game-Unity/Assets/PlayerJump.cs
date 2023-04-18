using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 10;
    public KeyCode jumpKey = KeyCode.Space;
    Rigidbody rb;
    public bool isJumping;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //CheckJump();
        if(Input.GetKeyDown(jumpKey))
        {
            Jump();
        }
    }

    void Jump()
    {
        isJumping = true;
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }


    void CheckJump()
    {
        if(rb.velocity.y >0)
        {
            isJumping = true;
        }

        else
        {
            isJumping = false;
        }
    }
}
