using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
using UnityEngine.UI;
using System.Runtime.CompilerServices;

public class DebugDisplay : MonoBehaviour
{

    [SerializeField] private Text text;
    private StringBuilder builder = new StringBuilder();
    private string[] ignore = new string[] { "[OVR" };


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
        builder.Clear();
        if(ignore.Length > 0 )
        {
            for (int i = 0; i< ignore.Length; i++)
            {
                if (ignore[i] != string.Empty && logString.Contains(ignore[i]))
                    return;
            }
        }

        builder.Append(logString);
        builder.Append(Environment.NewLine);

        text.text += builder.ToString();
        //text.text += logString + "\n";
        AdjustText(text);
        Debug.Log("Debug:" + logString);

    }

    private void AdjustText(Text t)
    {
        TextGenerator generator = t.cachedTextGenerator;
        var settings = t.GetGenerationSettings(t.rectTransform.rect.size);
        //text‚ð•`‰æ
        generator.Populate(t.text,settings);

        int countVisible = generator.characterCountVisible;
        if(countVisible == 0 || t.text.Length <= countVisible)
        {
            return;
        }

        int truncatedCount = t.text.Length - countVisible;
        var lines = t.text.Split("\n");

        foreach(string line in lines)
        {
            t.text = t.text.Remove(0, line.Length + 1);
            truncatedCount -= (line.Length+1);
            if(truncatedCount <= 0) 
            {
                break;
            }
        }
    }
}
