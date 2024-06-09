using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    private EnemyController enemyController;
    [SerializeField] private float hit = 10f;
    [SerializeField] private float power = 10f;

    [SerializeField] private GameObject flash;
    
    
    //バイブレーション用
    private RightWeaponController weaponController;

    [SerializeField] private AudioClip sound;
    private AudioSource audioSource;


private void Start()
    {
        gunTipPosition = gunTip.transform.position;
        hitController = bullet.GetComponent<HitController>();
        enemyController = GameObject.Find(name).GetComponent<EnemyController>();
        weaponController = GameObject.Find("RightWeaponController").GetComponent<RightWeaponController>();

        audioSource = this.AddComponent<AudioSource>();
        audioSource.clip = sound;
        audioSource.loop = false;


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

            audioSource.Play();
            
            Debug.Log("shot");

            //OVRInput.SetControllerVibration(0.1f, 0.1f, OVRInput.Controller.RTouch);

            //yield return new WaitForSeconds(0.5f);
            //OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);


            VibrationController.instance.StartVibration(1.0f, 1.0f, 0.5f, OVRInput.Controller.RTouch);
            //�e�̃C���X�^���X�쐬
            GameObject bulletInstance = Instantiate(bullet,gunTipPosition,Quaternion.LookRotation(gunTip.transform.forward));

            //Debug.Log(bulletInstance.transform.position);
            //Debug.Log(gunTipPosition);

            //����������
            bulletInstance.GetComponent<Rigidbody>().AddForce(gunTip.transform.forward*power);
            Destroy(bulletInstance, 2f);
            Debug.Log(gunTip.transform.forward);

                  
        }
    }
}
