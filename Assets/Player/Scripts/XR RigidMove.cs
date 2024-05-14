using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

public class XRRigidMove : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private InputActionProperty moveStick;




    private void Awake()
    {

        rb = GetComponent<Rigidbody>();

        // var actionAsset = interactionManager.GetComponent<InputActionManager>().m_ActionAssets;
        // var gameplayActionMap = actionAsset.FindActionMap("XRI LeftHand Locomotion");
        // moveAction = gameplayActionMap.FindAction("Move");
        // var playerInput = this.GetComponent<PlayerInput>();
        // moveAction = playerInput.actions["Move"];
    }

    private void FixedUpdate()
    {
        var moveAction = moveStick.action;
        // moveActionから入力値を取得し、使用する
        Vector2 input = moveAction.ReadValue<Vector2>();
        Debug.Log("Input Vector: " + input);
        // Vector2 input = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);

        Vector3 move = new Vector3(input.x, 0, input.y);

        rb.velocity += move * 0.5f;
        //Debug.Log(rb.velocity);

        // if (OVRInput.GetDown(OVRInput.RawButton.A))
        // {
        //     rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);

        //     Debug.Log("jump");
        // }

    }


}
