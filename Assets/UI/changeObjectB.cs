using UnityEngine;

public class changeObjectB : MonoBehaviour
{
    [SerializeField] private GameObject thisView;
    [SerializeField] private GameObject nextView;

    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
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
