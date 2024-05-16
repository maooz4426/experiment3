using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightWeaponController : MonoBehaviour
{

    [SerializeField] private GameObject rightController;
    [SerializeField] private GameObject sord;

    private GameObject currentWeapon;
    private Transform parent;

    private void Awake()
    {
        parent = this.transform;
        currentWeapon = Instantiate(rightController, parent);
    }

    private void FixedUpdate()
    {
        ChangeWeapon();
    }

    public void ChangeWeapon()
    {
        if (OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))
        {
                      
            Destroy(currentWeapon);
            currentWeapon = Instantiate(sord,parent);
            Debug.Log("change");
        }
    }
}
