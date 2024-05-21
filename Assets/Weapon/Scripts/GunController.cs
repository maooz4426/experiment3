using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [Header("GunComponent")]
    //弾のprefab
    [SerializeField] private GameObject bullet;
    //銃口
    [SerializeField] private GameObject gunTip;
    //銃口のposition把握
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
        //右のトリガー押されたら
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            Debug.Log("shot");
            
            //弾のインスタンス作成
            GameObject bulletInstance = Instantiate(bullet,gunTipPosition,Quaternion.identity);

            //Debug.Log(bulletInstance.transform.position);
            //Debug.Log(gunTipPosition);

            //勢いをつける
            bulletInstance.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 50));
        }
    }
}
