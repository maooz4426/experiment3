using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //シーンの管理をします

public class StartGame : MonoBehaviour
{
    [SerializeField] private GameObject titleView;
    [SerializeField] private GameObject gameView;

    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            Instantiate(gameView);
            Destroy(titleView);
        }
        
    }
    public void OnClick()
    {
        Instantiate(gameView);
        Destroy(titleView);
    }
}
