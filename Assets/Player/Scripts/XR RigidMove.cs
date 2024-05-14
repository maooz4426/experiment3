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
    [Header("ControllerInput")]
    [SerializeField] private InputActionProperty moveStick;
    [SerializeField] private InputActionProperty jumpButton;

    [Header("MoveParameter")] [SerializeField]
    private float speed = 10f;
    private Rigidbody rb;
    
    [Header("JumpParameter")]
    [SerializeField]private float groundCheckDistance = 0.2f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float radius = 0.3f;
    private RaycastHit hit;





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
        var jumpAction = jumpButton.action;
        
        // moveActionから入力値を取得し、使用する
        Vector2 input = moveAction.ReadValue<Vector2>();
        // Debug.Log("Input Vector: " + input);
        
        //jumpActionからの入力を受け取る
        if (jumpAction.IsPressed()&&CheckGrounded())
        {
            // jumped = true;
            rb.AddForce(new Vector3(0,1,0),ForceMode.Impulse);
            Debug.Log("Jump");
        }

        Vector3 move = new Vector3(input.x, 0, input.y);

        rb.velocity += move * (speed * 0.01f);
        
        

    }

    private bool CheckGrounded()
    {
        bool debug = Physics.SphereCast(this.transform.position, radius, Vector3.down, out hit, groundCheckDistance, groundLayer);
        Debug.Log(debug);
        return debug;
    }
    

    // private void Grounded(Collision collision)
    // {
    //     Debug.Log(collision.gameObject);
    // }


}
