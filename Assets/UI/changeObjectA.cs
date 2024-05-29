using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class changeObjectA : MonoBehaviour
{
    [SerializeField] private GameObject thisView;
    [SerializeField] private GameObject nextView;

    private PlayerInputAction inputActions;

    private void Start()
    {
        thisView = this.gameObject;//直節view取得
        inputActions = new PlayerInputAction();

        
    }

    private void OnEnable()
    {
        inputActions.Enable();
        inputActions.Title.Start.performed += OnChangeView;
    }

    private void OnDisable()
    {
        inputActions.End.Restart.performed -= OnChangeView;
        inputActions.Disable();
    }

    private void Update()
    {
        
        
        // if (OVRInput.GetDown(OVRInput.Button.One) || Input.GetKey(KeyCode.Return))
        // {
        //     // 条件式内のInput.GetKey(KeyCode.Return) は、開発中の動作確認のため
        //     Instantiate(nextView);
        //     Destroy(thisView);
        // }
        
    }

    private void OnChangeView(InputAction.CallbackContext context)
    {
        // 条件式内のInput.GetKey(KeyCode.Return) は、開発中の動作確認のため
        Instantiate(nextView);
        Destroy(thisView);
    }
    public void OnClick()
    {
        Instantiate(nextView);
        Destroy(thisView);
    }
}
