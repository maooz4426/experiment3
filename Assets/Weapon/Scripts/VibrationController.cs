using System.Collections;
using UnityEngine;

public class VibrationController : MonoBehaviour
{
    public static VibrationController instance;

    private void Awake()
    {
        instance = this;
    }

    public void StartVibration(float frequency, float amplitude, float duration, OVRInput.Controller controller)
    {
        StartCoroutine(Vibrate(frequency, amplitude, duration, controller));
    }

    private IEnumerator Vibrate(float frequency, float amplitude, float duration, OVRInput.Controller controller)
    {
        OVRInput.SetControllerVibration(frequency, amplitude, controller);
        yield return new WaitForSeconds(duration);
        OVRInput.SetControllerVibration(0, 0, controller); // バイブレーションを停止
    }

    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            StartVibration(1.0f, 1.0f, 0.5f, OVRInput.Controller.RTouch);
        }
    }
}