using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlayerController))]

public class PlayerControllerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        if (target is PlayerController)
        {
            GUILayout.Label("���̃X�N���v�g�̓L�����N�^�[�̐ݒ���s���܂��B");
            

            //�C���X�y�N�^�[�̕\��
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
            GUILayout.Label("���̃X�N���v�g�͓G�̐ݒ���s���܂��B");
           

            //�C���X�y�N�^�[�̕\��
            DrawDefaultInspector();
        }
    }
}
