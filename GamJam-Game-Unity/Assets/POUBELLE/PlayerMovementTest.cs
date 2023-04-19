using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementTest : MonoBehaviour
{
    public float speed;
    public Transform body;
    public bool forward, back, left, right;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
            FourDirectionMove();
    }

    void FourDirectionMove()
    {
        if (Input.GetKey(KeyCode.Z) && back == false && left == false && right == false)
        {
            forward = true;
        body.transform.localEulerAngles = new Vector3(0, 0, 0);
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.S) && forward == false && left == false && right == false)
        {
            back = true;
        body.transform.localEulerAngles = new Vector3(0, 180, 0);
        transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.Q) && back == false && forward == false && right == false)
        {
            left = true;
        body.transform.localEulerAngles = new Vector3(0, -90, 0);
        transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.D) && back == false && left == false && forward == false)
        {
            right = true;
        body.transform.localEulerAngles = new Vector3(0, 90, 0);
        transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
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

        else
        {
           // NoMove();
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
