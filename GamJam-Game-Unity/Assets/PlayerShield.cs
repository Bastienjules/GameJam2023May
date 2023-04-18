using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    public KeyCode shieldKey = KeyCode.Mouse1;
    public bool shieldOn;
    public GameObject shield;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(shieldKey))
        {
            shieldOn = true;
            shield.SetActive(true);
        }

        else
        {
            shieldOn = false;
            shield.SetActive(false);
        }
    }
}
