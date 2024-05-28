using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class selectAnswer : MonoBehaviour
{
    public TextMeshProUGUI myakumyakuText;
    [SerializeField] public GameObject answers;
    [SerializeField] public GameObject fin;

    private void Start()
    {
        fin.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One) || Input.GetKey(KeyCode.Return))
        {
            myakumyakuText.text = "Thank you. I will make the 2025 Osaka Expo a great success for everyone!";
            UpdateDisplay();
        }
        else if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            myakumyakuText.text = "You humans hate me after all! Enough, I'm going to destroy them all!";
            UpdateDisplay();
        }
    }

    void UpdateDisplay()
    {
        Destroy(answers);
        fin.SetActive(true);
    }
}
