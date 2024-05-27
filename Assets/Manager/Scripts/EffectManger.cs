using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManger : MonoBehaviour
{
    [SerializeField] private GameObject blood;
    [SerializeField] private float disapper=3f;

    public void OnBlood(Vector3 position)
    {
        GameObject bloodInstance = Instantiate(blood,position, Quaternion.LookRotation(Vector3.back));

        Destroy(bloodInstance,disapper);
    }
}
