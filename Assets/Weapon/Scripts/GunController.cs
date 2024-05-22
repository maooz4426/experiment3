using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [Header("GunComponent")]
    //�e��prefab
    [SerializeField] private GameObject bullet;
    //�e��
    [SerializeField] private GameObject gunTip;
    //�e����position�c��
    private Vector3 gunTipPosition;

    private void Awake()
    {
        gunTipPosition = gunTip.transform.position;

    }       

    private void Update()
    {
        gunTipPosition = gunTip.transform.position;
        Shot();
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
            bulletInstance.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 50));
        }
    }
}
