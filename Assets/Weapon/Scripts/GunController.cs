using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [Header("GunComponent")]
    //�e��prefab
    [SerializeField]
    private GameObject bullet;

    //�e��
    [SerializeField] private GameObject gunTip;

    //�e����position�c��
    private Vector3 gunTipPosition;
    private HitController hitController;
    private EnemyParameterController enemyParameterController;
    [SerializeField] private float hit = 10f;
    [SerializeField] private float power = 10f;

    [SerializeField] private GameObject flash;
    
    
    //バイブレーション用
    private RightWeaponController weaponController;


private void Start()
    {
        gunTipPosition = gunTip.transform.position;
        hitController = bullet.GetComponent<HitController>();
        enemyParameterController = GameObject.Find(name).GetComponent<EnemyParameterController>();
        weaponController = GameObject.Find("RightWeaponController").GetComponent<RightWeaponController>();

    }       

    private void Update()
    {
        gunTipPosition = gunTip.transform.position;
        Shot();
        //bulletHit();
    }

    private void Shot()
    {
        //�E�̃g���K�[�����ꂽ��
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            flash.GetComponent<ParticleSystem>().Play();
            Debug.Log("shot");
            
            // VibrationController.instance.StartVibration(1.0f, 1.0f, 0.5f, OVRInput.Controller.RTouch);
            //�e�̃C���X�^���X�쐬
            GameObject bulletInstance = Instantiate(bullet,gunTipPosition,Quaternion.LookRotation(gunTip.transform.forward));

            //Debug.Log(bulletInstance.transform.position);
            //Debug.Log(gunTipPosition);

            //����������
            bulletInstance.GetComponent<Rigidbody>().AddForce(gunTip.transform.forward*power);
            Debug.Log(gunTip.transform.forward);

                  
        }

     

    }

    private void bulletHit()
    {
        
        if (hitController.CheckHit())
        {
            Debug.Log(hitController.CheckHit());
            enemyParameterController.DecreaseHp(hit);
            Debug.Log(enemyParameterController.GetHp());
            hitController.ChangeHitChecked();
        }
    }

    
}
