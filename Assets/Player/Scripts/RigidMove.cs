using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class RigidMove : MonoBehaviour
{
    private Rigidbody rb;
    [Header("JumpParameter")]
    [SerializeField] private float jumpPower = 5f;
    [SerializeField] private float groundCheckDistance = 0.2f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float radius = 0.3f;
    private RaycastHit hit;

    private void Awake()
    {

        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector2 input = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick) ;

        Vector3 move = new Vector3(input.x, 0, input.y);

        rb.velocity += move  *0.5f;
       // print(rb.velocity);

        

        if (OVRInput.GetDown(OVRInput.RawButton.A))
        {
            if (IsCheckGround())
            {
                rb.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);

                print("jump");
            }
        }
        
    }

    private bool IsCheckGround()
    {
        bool grounded = Physics.SphereCast(this.transform.position, radius, Vector3.down, out hit, groundCheckDistance, groundLayer);
        print(grounded);
        return grounded;
    }
}
