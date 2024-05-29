using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleViewManager : MonoBehaviour
{
    private void Start()
    {
        PlayerController playerController = GameObject.FindWithTag(("Player")).GetComponent<PlayerController>();
        
        playerController.TitleStart();
    }
}
