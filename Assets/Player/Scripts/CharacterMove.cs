using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{

    private CharacterController controller;
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        Vector2 stickR = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick);

        Vector3 movePostiion = new Vector3(stickR.x,0, stickR.y);
        controller.Move(movePostiion);

      
    }
}
