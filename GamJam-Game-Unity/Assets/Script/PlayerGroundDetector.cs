using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundDetector : MonoBehaviour
{
    public Transform groundObj;
    public LayerMask groundLayer;
    public float XZsizeBox, Yheight;
    public bool isGrounded;
    Vector3 size;

    KeyCode jumpKey;

    void Start()
    {
        size = new Vector3(XZsizeBox, Yheight, XZsizeBox);
        jumpKey = GetComponent<PlayerJump>().jumpKey;
    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckBox(groundObj.position, size / 2, Quaternion.identity, groundLayer);

        if(isGrounded == true && !Input.GetKey(jumpKey))
        {
            GetComponent<PlayerJump>().isJumping = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(groundObj.position, size);
    }
}
