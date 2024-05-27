using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AddEnemyParameterToSkinnedMeshRender : MonoBehaviour
{
    [MenuItem("Tools/Add EnemyParameter to Children MeshRender")]
    static void AddColliders()
    {
        // �e�I�u�W�F�N�g���擾
        GameObject parentObject = Selection.activeGameObject;

        //�e�����Ȃ��ꍇ�͌x��
        if (parentObject == null)
        {
            Debug.LogWarning("No game object selected.");
            return;
        }

        // �q�I�u�W�F�N�g�̐e�I�u�W�F�N�g�ɂ���MeshFilter���擾
        SkinnedMeshRenderer[] meshRenders = parentObject.GetComponentsInChildren<SkinnedMeshRenderer>();

        // �q�e�I�u�W�F�N�g��MeshCollider��ǉ�
        foreach (SkinnedMeshRenderer meshRender in meshRenders)
        {
            meshRender.gameObject.tag = "EnemyBody";
            MeshCollider meshCollider;

            meshCollider = meshRender.gameObject.GetComponent<MeshCollider>();

            if (meshCollider == null)
            {
                meshCollider = meshRender.gameObject.AddComponent<MeshCollider>();
                meshCollider.sharedMesh = meshRender.sharedMesh;
            }

            Rigidbody rigid = meshRender.gameObject.GetComponent<Rigidbody>();

            if (rigid != null)
            {
                DestroyImmediate(rigid);
            }

            meshCollider.sharedMesh = meshRender.sharedMesh; // meshfilter�Ɋ�Â��Ă��郁�b�V����meshcollider�ɐݒ�
            meshCollider.convex = true;
            meshCollider.isTrigger = true;
        }
    }
}
