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
    //�Y�����镶����𖳎�����
    [SerializeField]private string[] ignore = new string[] { "[OVR" };


    private void Update()
    {
        //Debug.Log(OVRInput.Get(OVRInput.RawButton.LIndexTrigger));
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

        //�������镶���񂪂�������s��
        if(ignore.Length > 0 )
        {
            for (int i = 0; i< ignore.Length; i++)
            {   //�������镶����log�ɂӂ��܂�Ă���return���Ď��̃��O�Ɉڍs
                if (ignore[i] != string.Empty && logString.Contains(ignore[i]))
                    return;
            }
        }

        builder.Append(string.Format("[{0}:{1:D3}]", DateTime.Now.ToLongTimeString(), DateTime.Now.Millisecond));
        //�������ǉ�
        builder.Append(logString);
        //���s��ǉ�
        builder.Append(Environment.NewLine);

        text.text += builder.ToString();
        text.color = Color.white;
        //text.text += logString + "\n";
        AdjustText(text);
        //Debug.Log("Debug:" + logString);

    }

    private void AdjustText(Text t)
    {
        //�e�L�X�g�`��ɕK�v�ȃR���|�[�l���g���擾
        TextGenerator generator = t.cachedTextGenerator;
        var settings = t.GetGenerationSettings(t.rectTransform.rect.size);
        //text��`��
        generator.Populate(t.text,settings);

        //�����񂪂ǂ̂��炢�����邩�c��
        int countVisible = generator.characterCountVisible;

        //�����񂪌������炻�̂��Ƃ̏����𖳎�
        if(countVisible == 0 || t.text.Length <= countVisible)
        {
            return;
        }

        //���؂�镶�����c��
        int truncatedCount = t.text.Length - countVisible;
        var lines = t.text.Split("\n");

        foreach(string line in lines)
        {
            //��ԏ�̍s�̕�����i���s�܂ށj���擾
            t.text = t.text.Remove(0, line.Length + 1);
            //�����������������
            truncatedCount -= (line.Length+1);
            //�S�������I�������I��
            if(truncatedCount <= 0) 
            {
                break;
            }
        }
    }
}
