using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float hp = 100;

    public float GetHp()
    {
        return hp;
    }

    public void DecreaseHp(float damage)
    {
        VibrationController.instance.StartVibration(1.0f, 1.0f, 0.5f, OVRInput.Controller.LTouch);
        hp -= damage;
    }

    public void ResetController()
    {
        RightWeaponController rightController = GameObject.Find("RightWeaponController").GetComponent<RightWeaponController>();
        
        rightController.ResetController();
    }
}
