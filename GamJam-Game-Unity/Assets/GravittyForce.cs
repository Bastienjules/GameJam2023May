using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravittyForce : MonoBehaviour
{
    public float gravityY = 10;

    private void Update()
    {
        Physics.gravity = new Vector3(0, - gravityY, 0);
    }

}
