using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidMove : MonoBehaviour
{
    private Rigidbody rb;

    private void Awake()
    {

        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector2 input = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick) ;

        Vector3 move = new Vector3(input.x, 0, input.y);

        rb.velocity += move  *0.5f;
        //Debug.Log(rb.velocity);

        if (OVRInput.GetDown(OVRInput.RawButton.A))
        {
            rb.AddForce(new Vector3 (0,5,0),ForceMode.Impulse);

            Debug.Log("jump");
        }
        
    }
}
