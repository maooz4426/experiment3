using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class RightWeaponController : MonoBehaviour
{
    [Header("weapon")]
    //weaponをリストに
    private List<GameObject> weapons = new List<GameObject> ();

    
    [SerializeField] private GameObject rightController;
    //剣のprefab
    [SerializeField] private GameObject sord;
    //銃のprefab
    [SerializeField] private GameObject gun;
    //icepickのprefab
    [SerializeField] private GameObject icePick;
    //現在のweaponを登録
    private GameObject currentWeapon;
    //親の位置を取得するために
    private Transform parent;
    //武器を変更できるように
    private bool changeable = true;
    //現在の武器の番号を把握
    private int weaponCnt = 0;

    private PlayerInputAction inputActions;

    private void Awake()
    {
        //武器を登録
        weapons.Add(rightController);
        weapons.Add(sord);
        weapons.Add(gun);
        weapons.Add (icePick);
        parent = this.transform;
        
        //コントローラー右のコントローラー
        currentWeapon = Instantiate(rightController, parent);

        inputActions = new PlayerInputAction();
    }

    // private void Update()
    // {
    //     if (CheckView())
    //     {
    //         ChangeWeapon();
    //     }
    // }

    //gameviewのが出ているか確認
    private bool CheckView()
    {
        GameObject Gameview = GameObject.FindWithTag("GameView");
        if (Gameview != null)
        {
            //Debug.Log("gameviewok");
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ChangeWeapon(InputAction.CallbackContext context)
    {
        
        //右コントローラーのグリップを押したら武器が入れ替わるように
        // if (OVRInput.Get(OVRInput.Button.SecondaryHandTrigger)&&changeable)
        if(context.performed&&changeable)
        {
            Debug.Log(weaponCnt);
            changeable = false;
         
            //�E�R���g���[���[���폜
            Destroy(currentWeapon);
            //���𐶐�
            currentWeapon = Instantiate(weapons[weaponCnt], parent);
            Debug.Log("change");
            weaponCnt++;
          

        }
        // else if (OVRInput.GetUp(OVRInput.Button.SecondaryHandTrigger))
        else if (context.canceled)
        {
            //�E���w�̃g���K�[���グ����ture��
            changeable=true;
            //cnt���Z�b�g
            if (weaponCnt == weapons.Count )
            {
                weaponCnt = 0;
            }
        }
   
    }

    public void ResetController()
    {
        Destroy((currentWeapon));
        Instantiate(rightController, parent);
    }
   
    private void OnEnable()
    {
        inputActions.Enable();
        inputActions.Game.SwitchWeapon.performed += ChangeWeapon;
        
        if (CheckView())
        {
            inputActions.Game.SwitchWeapon.performed += ChangeWeapon;
        }
    }

    private void OnDisable()
    {
        inputActions.Disable();
        inputActions.Game.SwitchWeapon.performed -= ChangeWeapon;
    }
}
