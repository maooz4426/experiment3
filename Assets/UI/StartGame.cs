using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] private GameObject thisView;
    [SerializeField] private GameObject nextView;

    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One) || Input.GetKey(KeyCode.Return))
        {
            // 条件式内のInput.GetKey(KeyCode.Return) は、開発中の動作確認のため
            Instantiate(nextView);
            Destroy(thisView);
        }
        
    }
    public void OnClick()
    {
        Instantiate(nextView);
        Destroy(thisView);
    }
}
