using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingViewManager : MonoBehaviour
{
    private Rigidbody rb;

    private void Start()
    {
        Destroy(GameObject.Find("Terrain(Clone)"));
        GameObject player = GameObject.FindWithTag("Player");
        rb = player.GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezeAll;

        Vector3 position = this.transform.position;
        position.x += 489;
        position.y += 195;
        position.z += -600;

        player.transform.position = position;
    }
}
