using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TitleViewManager : MonoBehaviour
{
    private void Start()
    {
        GameObject player = GameObject.FindWithTag(("Player"));
        player.transform.position = new Vector3(this.transform.position.x,this.transform.position.y, this.transform.position.z - 15);
        PlayerController playerController = player.GetComponent<PlayerController>();

        Rigidbody rigidbody = player.GetComponent<Rigidbody>();

       //rigidbody.constraints = RigidbodyConstraints.None;
       //rigidbody.constraints = RigidbodyConstraints.FreezeRotation;

        playerController.TitleStart();

        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] enemybodies = GameObject.FindGameObjectsWithTag("EnemyBody");

        if (GameObject.FindWithTag("ground"))
        {
            Destroy(GameObject.FindWithTag("ground"));
        }

        if(enemys.Length > 0)
        {
            foreach (GameObject enemy in enemys)
            {
                Destroy(enemy);

            }
        }

        if (enemybodies.Length > 0)
        {
            foreach (GameObject body in enemybodies) {
                Destroy(body);

            }
        }
        
    }
}
