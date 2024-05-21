using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [Header("GunComponent")]
    //íeÇÃprefab
    [SerializeField] private GameObject bullet;
    //èeå˚
    [SerializeField] private GameObject gunTip;
    //èeå˚ÇÃpositionîcà¨
    private Vector3 gunTipPosition;
    private HitController hitController;
    private EnemyController enemyController;
    [SerializeField] private float hit = 10f;

    private void Awake()
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
        //âEÇÃÉgÉäÉKÅ[âüÇ≥ÇÍÇΩÇÁ
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            Debug.Log("shot");
            
            //íeÇÃÉCÉìÉXÉ^ÉìÉXçÏê¨
            GameObject bulletInstance = Instantiate(bullet,gunTipPosition,Quaternion.identity);

            //Debug.Log(bulletInstance.transform.position);
            //Debug.Log(gunTipPosition);

            //ê®Ç¢ÇÇ¬ÇØÇÈ
            bulletInstance.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 50));
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
