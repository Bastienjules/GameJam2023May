using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("X"))
        {
            Debug.Log("X");
        }

        if (Input.GetButton("Y"))
        {
            Debug.Log("Y");
        }

        if (Input.GetButton("B"))
        {
            Debug.Log("B");
        }

        if (Input.GetButton("LB"))
        {
            Debug.Log("LB");
        }

        if (Input.GetButton("RB"))
        {
            Debug.Log("RB");
        }

        if (Input.GetButton("START"))
        {
            Debug.Log("START");
        }

        if (Input.GetButton("SELECT"))
        {
            Debug.Log("SELECT");
        }

        if (Input.GetButton("L"))
        {
            Debug.Log("L");
        }

        if (Input.GetButton("R"))
        {
            Debug.Log("R");
        }

        // L
        if (Input.GetAxisRaw("L-H") > 0)
        {
            Debug.Log("L RIGHT");
        }

        if (Input.GetAxisRaw("L-H") < 0)
        {
            Debug.Log("L LEFT");
        }

        if (Input.GetAxisRaw("L-V") > 0)
        {
            Debug.Log("L UP");
        }

        if (Input.GetAxisRaw("L-V") < 0)
        {
            Debug.Log("L DOWN");
        }

        // R
        if (Input.GetAxisRaw("R-H") > 0)
        {
            Debug.Log("R RIGHT");
        }

        if (Input.GetAxisRaw("L-H") < 0)
        {
            Debug.Log("R LEFT");
        }

        if (Input.GetAxisRaw("R-V") > 0)
        {
            Debug.Log("R UP");
        }

        if (Input.GetAxisRaw("R-V") < 0)
        {
            Debug.Log("R DOWN");
        }

        // DPAD
        if (Input.GetAxisRaw("D-PAD-H") > 0)
        {
            Debug.Log("D-PAD-H RIGHT");
        }

        if (Input.GetAxisRaw("D-PAD-H") < 0)
        {
            Debug.Log("D-PAD-H LEFT");
        }

        if (Input.GetAxisRaw("D-PAD-V") > 0)
        {
            Debug.Log("D-PAD-V UP");
        }

        if (Input.GetAxisRaw("D-PAD-V") < 0)
        {
            Debug.Log("D-PAD-V DOWN");
        }

        // TRIGGER

    }
}
