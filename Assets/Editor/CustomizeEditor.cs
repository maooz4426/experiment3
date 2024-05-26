using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlayerController))]

public class PlayerControllerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        if (target is PlayerController)
        {
            GUILayout.Label("このスクリプトはキャラクターの設定を行います。");
            

            //インスペクターの表示
            DrawDefaultInspector();
        }
    }
}

[CustomEditor(typeof(EnemyController))]
public class EnemyControllerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        if (target is EnemyController)
        {
            GUILayout.Label("このスクリプトは敵の設定を行います。");
           

            //インスペクターの表示
            DrawDefaultInspector();
        }
    }
}
