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
    private EnemyController enemyController;
    [SerializeField] private float hit = 10f;
    [SerializeField] private float power = 10f;


private void Start()
    {
        gunTipPosition = gunTip.transform.position;
        hitController = bullet.GetComponent<HitController>();
        enemyController = GameObject.Find(name).GetComponent<EnemyController>();
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
            Debug.Log("shot");

            //�e�̃C���X�^���X�쐬
            GameObject bulletInstance = Instantiate(bullet,gunTipPosition,Quaternion.identity);

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
            enemyController.DecreaseHp(hit);
            Debug.Log(enemyController.GetHp());
            hitController.ChangeHitChecked();
        }
    }

    
}
