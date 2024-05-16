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

        parent = this.transform;
        //���߂͉E�R���g���[���[��\��
        currentWeapon = Instantiate(rightController, parent);
    }

    private void Update()
    {
        ChangeWeapon();
    }

    public void ChangeWeapon()
    {
        //Debug.Log(changeable);
        //�E���w�̃g���K�[���グ���瓮��
        if (OVRInput.Get(OVRInput.Button.SecondaryHandTrigger)&&changeable)
        {
            Debug.Log(weaponCnt);
            changeable = false;
            if(weaponCnt == 0)
            {
                //�E�R���g���[���[���폜
                Destroy(currentWeapon);
                //���𐶐�
                currentWeapon = Instantiate(sord, parent);
                Debug.Log("change");
                weaponCnt++;
            }
            else if(weaponCnt == 1)
            {
                //�����폜
                Destroy(currentWeapon);
                //�R���g���[���[�𐶐�
                currentWeapon = Instantiate(rightController, parent);
                Debug.Log("change");
                weaponCnt++;
            }else if(weaponCnt == 2)
            {
                Destroy(currentWeapon);
                currentWeapon = Instantiate(gun, parent);
                weaponCnt++;
            }

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
}
