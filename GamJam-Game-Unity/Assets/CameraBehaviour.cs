using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public float followSpeed;
    public bool canRot = false;
    Transform target;

    [Header("Rotation")]
    public float rotSpeed;
    public float resetRotSpeed;
    float elapsed;
    Quaternion originalRotation;

    // Start is called before the first frame update
    void Start()
    {
        originalRotation = transform.rotation;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        transform.position = target.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(canRot == true)
        {
            Rotate();
        }
    }

    private void FixedUpdate()
    {
        FollowTarget();
    }

    void FollowTarget()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, followSpeed * Time.fixedDeltaTime);
    }


    void Rotate()
    {
        if (Input.GetAxis("Mouse X") > 0)
        {
            transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime);
        }

        if (Input.GetAxis("Mouse X") < 0)
        {
            transform.Rotate(-Vector3.up * rotSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Mouse2))
        {
            elapsed += Time.deltaTime / resetRotSpeed;
            transform.rotation = Quaternion.Slerp(transform.rotation, originalRotation, resetRotSpeed);
        }

        else
        {
            elapsed = 0;
        }
    }
}
