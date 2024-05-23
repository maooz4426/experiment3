using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //シーンの管理をします

public class changeScene : MonoBehaviour
{
    [SerializeField] public GameObject titleView;
    [SerializeField] public GameObject gameView;

    private void FixedUpdate()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.B))
        {
            titleView.SetActive(false);
            gameView.SetActive(true);
        }
    }
}
