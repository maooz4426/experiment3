using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlayerController))]

public class PlayerControllerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        if (target is PlayerController)
        {
            GUILayout.Label("このコンポネントはキャラクターのステータス設定を行います。");
            

            //インスペクターの表示
            DrawDefaultInspector();
        }
    }
}

[CustomEditor(typeof(RigidMove))]
public class RigidMoveEditor : Editor
{
    public override void OnInspectorGUI()
    {
        if (target is RigidMove)
        {
            GUILayout.Label("このコンポネントはrigidbodyを使ったキャラクターの移動を行います。");
            

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
            GUILayout.Label("このコンポネントは敵の設定を行います。");
           

            //インスペクターの表示
            DrawDefaultInspector();
        }
    }
}

[CustomEditor(typeof(WeaponManager))]
public class WeaponManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        if (target is WeaponManager)
        {
            GUILayout.Label("このコンポネントは武器のステータス設定を行います。");
           

            //インスペクターの表示
            DrawDefaultInspector();
        }
    }
}


[CustomEditor(typeof(RightWeaponController))]
public class RightWeaponControllerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        if (target is RightWeaponController)
        {
            GUILayout.Label("このコンポネントは右コントローラーの武器の装着を行います。");
           

            //インスペクターの表示
            DrawDefaultInspector();
        }
    }
}
