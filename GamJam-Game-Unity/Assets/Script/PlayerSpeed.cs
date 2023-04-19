using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpeed : MonoBehaviour
{
    public float walkSpeed, runSpeed, shieldSpeed;

    PlayerGroundDetector groundDetector;
    PlayerMovement playerMovementTest;

    public KeyCode speedKey = KeyCode.LeftShift;
    bool shieldMove;
    // Start is called before the first frame update
    void Start()
    {
        groundDetector = GetComponent<PlayerGroundDetector>();
        playerMovementTest = GetComponent<PlayerMovement>();

    }

    // Update is called once per frame
    void Update()
    {

        shieldMove = GetComponent<PlayerShield>().shieldOn;

        if (shieldMove == false)
        {
            if (Input.GetKey(speedKey))
            {
                playerMovementTest.speed = runSpeed;
            }

            else
            {
                playerMovementTest.speed = walkSpeed;
            }
        }

        else
        {
            playerMovementTest.speed = shieldSpeed;
        }
    }
}
