using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SordController : MonoBehaviour
{
    [SerializeField] AudioClip soundclip;
    AudioSource audioSource;

    private float shakeThreshold = 2.0f;
    private Vector3 previousAcceleration;

    private void Start()
    {
        audioSource = this.AddComponent<AudioSource>();
        audioSource.clip = soundclip;
        audioSource.loop = false;
    }

    private void Update()
    {
        Vector3 currentAcceleration = OVRInput.GetLocalControllerAcceleration(OVRInput.Controller.RTouch);

        Vector3 deltaAcceleration = currentAcceleration - previousAcceleration;

        if (deltaAcceleration.sqrMagnitude > shakeThreshold * shakeThreshold)
        {
            audioSource.Play();
        }
    }
}
