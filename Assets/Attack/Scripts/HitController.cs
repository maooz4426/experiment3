using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitController : MonoBehaviour
{

    

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            Debug.Log("hit");
        }
    }
}
