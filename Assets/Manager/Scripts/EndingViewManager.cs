using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

public class EndingViewManager : MonoBehaviour
{
    private Rigidbody rb;

    private PlayerController playerController;

    [SerializeField] private GameObject TitleView;

    [SerializeField] private PlayerInputAction inputActions;

    private void Awake()
    {
        inputActions = new PlayerInputAction();
    }

    private void Start()
    {
        Destroy(GameObject.Find("Terrain(Clone)"));

        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        playerController.ResetController();
        
        GameObject player = GameObject.FindWithTag("Player");
        rb = player.GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezeAll;

        Vector3 position = this.transform.position;
        position.x += 489;
        position.y += 195;
        position.z += -600;

        player.transform.position = position;
    }
    
    private void OnEnable()
    {
        // アクションマップを有効にする
        inputActions.Enable();

        // Restartアクションにリスナーを追加
        inputActions.End.Restart.performed += OnRestart;
    }

    private void OnDisable()
    {
        // リスナーを削除し、アクションマップを無効にする
        inputActions.End.Restart.performed -= OnRestart;
        inputActions.Disable();
    }
    
    // Restartアクションが実行されたときに呼ばれるメソッド
    private void OnRestart(InputAction.CallbackContext context)
    {
        Instantiate (TitleView);
    }
    private void Update()
    {
        
    }

   
}
