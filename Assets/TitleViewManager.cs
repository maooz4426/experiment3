using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleViewManager : MonoBehaviour
{
    private void Start()
    {
        GameObject player = GameObject.FindWithTag(("Player"));
        player.transform.position = new Vector3(0, 0, -15);
        PlayerController playerController = player.GetComponent<PlayerController>();
        
        playerController.TitleStart();
    }
}
