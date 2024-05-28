using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RightWeaponController : MonoBehaviour
{
    [Header("weapon")]
    //�g�������o�^���邽�߂̃��X�g
    private List<GameObject> weapons = new List<GameObject> ();

    //�E�R���g���[���[��prefab
    [SerializeField] private GameObject rightController;
    //����prefab
    [SerializeField] private GameObject sord;
    //�e��prefab
    [SerializeField] private GameObject gun;
    //icepick��prefab
    [SerializeField] private GameObject icePick;
    //�������Ă�weapon
    private GameObject currentWeapon;
    //�E�R���g���[���[�̈ʒu
    private Transform parent;
    //��x�������������̕���ɕύX�ł���悤��
    private bool changeable = true;
    //�������ւ��̂��߂�count
    private int weaponCnt = 0;

    private void Awake()
    {
        //�����o�^
        weapons.Add(rightController);
        weapons.Add(sord);
        weapons.Add(gun);
        weapons.Add (icePick);
        parent = this.transform;
        //���߂͉E�R���g���[���[��\��
        currentWeapon = Instantiate(rightController, parent);
    }

    private void Update()
    {
        if (CheckView())
        {
            ChangeWeapon();
        }
    }

    //View��gameview�������畐��ύX�s����悤��
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

    public void ChangeWeapon()
    {
        //Debug.Log(changeable);
        //�E���w�̃g���K�[���グ���瓮��
        if (OVRInput.Get(OVRInput.Button.SecondaryHandTrigger)&&changeable)
        {
            Debug.Log(weaponCnt);
            changeable = false;
         
            //�E�R���g���[���[���폜
            Destroy(currentWeapon);
            //���𐶐�
            currentWeapon = Instantiate(weapons[weaponCnt], parent);
            Debug.Log("change");
            weaponCnt++;
          

        }else if (OVRInput.GetUp(OVRInput.Button.SecondaryHandTrigger))
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
    
    public void StartVibration(float frequency, float amplitude, float duration, OVRInput.Controller controller)
    {
        StartCoroutine(Vibrate(frequency, amplitude, duration, controller));
    }
    private IEnumerator Vibrate(float frequency, float amplitude, float duration, OVRInput.Controller controller)
    {
        OVRInput.SetControllerVibration(frequency, amplitude, controller);
        yield return new WaitForSeconds(duration);
        OVRInput.SetControllerVibration(0, 0, controller); // バイブレーションを停止
    }
}
