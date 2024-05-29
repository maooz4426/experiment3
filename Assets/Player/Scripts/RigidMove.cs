using System;
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
    [SerializeField] private GameObject cameraRig;

    private PlayerInputAction inputActions;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        inputActions = new PlayerInputAction();

    }

    private void FixedUpdate()
    {
        //元々のコード
        // Vector2 input = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick) ;
        
        // InputActionのMoveアクションの入力を取得
        Vector2 input = inputActions.Game.Move.ReadValue<Vector2>();
        
        Vector3 forward = cameraRig.transform.forward;
        forward.Normalize();
        Vector3 right = cameraRig.transform.right;
        right.Normalize();

        Vector3 move = (forward * input.y + right * input.x) * 0.5f;
        
        rb.velocity +=move;
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

    private void OnEnable()
    {
        inputActions.Enable();
    }
    
    private void OnDisable()
    {
        inputActions.Disable();
    }

   
}
