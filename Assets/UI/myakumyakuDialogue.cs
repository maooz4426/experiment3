using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class myakumyakuDialogue : MonoBehaviour
{
    public NPCConversation myConversation;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            ConversationManager.Instance.StartConversation(myConversation);
        }
    }
}
