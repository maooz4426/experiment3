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
    //該当する文字列を無視する
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

        //無視する文字列があったら行う
        if(ignore.Length > 0 )
        {
            for (int i = 0; i< ignore.Length; i++)
            {   //無視する文字列がlogにふくまれてたらreturnして次のログに移行
                if (ignore[i] != string.Empty && logString.Contains(ignore[i]))
                    return;
            }
        }

        builder.Append(string.Format("[{0}:{1:D3}]", DateTime.Now.ToLongTimeString(), DateTime.Now.Millisecond));
        //文字列を追加
        builder.Append(logString);
        //改行を追加
        builder.Append(Environment.NewLine);

        text.text += builder.ToString();
        text.color = Color.white;
        //text.text += logString + "\n";
        AdjustText(text);
        //Debug.Log("Debug:" + logString);

    }

    private void AdjustText(Text t)
    {
        //テキスト描画に必要なコンポーネント等取得
        TextGenerator generator = t.cachedTextGenerator;
        var settings = t.GetGenerationSettings(t.rectTransform.rect.size);
        //textを描画
        generator.Populate(t.text,settings);

        //文字列がどのくらい見えるか把握
        int countVisible = generator.characterCountVisible;

        //文字列が見えたらそのあとの処理を無視
        if(countVisible == 0 || t.text.Length <= countVisible)
        {
            return;
        }

        //見切れる文字列を把握
        int truncatedCount = t.text.Length - countVisible;
        var lines = t.text.Split("\n");

        foreach(string line in lines)
        {
            //一番上の行の文字列（改行含む）を取得
            t.text = t.text.Remove(0, line.Length + 1);
            //消した文字列を引く
            truncatedCount -= (line.Length+1);
            //全部消し終わったら終了
            if(truncatedCount <= 0) 
            {
                break;
            }
        }
    }
}
