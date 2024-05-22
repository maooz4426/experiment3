using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [Header("GunComponent")]
    //’e‚Ìprefab
    [SerializeField] private GameObject bullet;
    //eŒû
    [SerializeField] private GameObject gunTip;
    //eŒû‚Ìposition”cˆ¬
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
        //‰E‚ÌƒgƒŠƒK[‰Ÿ‚³‚ê‚½‚ç
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            Debug.Log("shot");
            
            //’e‚ÌƒCƒ“ƒXƒ^ƒ“ƒXì¬
            GameObject bulletInstance = Instantiate(bullet,gunTipPosition,Quaternion.identity);

            //Debug.Log(bulletInstance.transform.position);
            //Debug.Log(gunTipPosition);

            //¨‚¢‚ğ‚Â‚¯‚é
            bulletInstance.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 50));
        }
    }
}
