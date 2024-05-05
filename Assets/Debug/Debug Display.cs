using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
using UnityEngine.UI;

public class DebugDisplay : MonoBehaviour
{

    [SerializeField] private Text text;

    private void Update()
    {
        Debug.Log(OVRInput.Get(OVRInput.RawButton.LIndexTrigger));
    }

    void OnEnable()
    {
        Application.logMessageReceived += HandleLog;

    }

    void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
    }

    void HandleLog(string logString,string stackTrace,LogType type)
    {
        text.text = logString + "\n";
        Debug.Log("Debug:" + logString);

    }
}
