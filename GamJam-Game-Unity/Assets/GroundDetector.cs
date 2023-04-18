using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public Transform groundObj;
    public LayerMask groundLayer;
    public float XZsizeBox, Yheight;
    public bool isGrounded, isJumping;
    Vector3 size;

    void Start()
    {
        size = new Vector3(XZsizeBox, Yheight, XZsizeBox);
    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckBox(groundObj.position, size / 2, Quaternion.identity, groundLayer);

        if(isGrounded == true)
        {
            isJumping = false;
        }

        else
        {
            isJumping = true;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(groundObj.position, size);
    }
}
