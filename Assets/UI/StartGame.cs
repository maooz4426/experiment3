using UnityEngine;

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
