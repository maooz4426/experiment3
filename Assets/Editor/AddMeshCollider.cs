using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AddMeshCollider : MonoBehaviour
{


    [MenuItem("Tools/Add Mesh Colliders to Children")]
    static void AddColliders()
    {
        // �I�������I�u�W�F�N�g���擾
        GameObject parentObject = Selection.activeGameObject;

        if (parentObject == null)
        {
            Debug.LogWarning("No game object selected.");
            return;
        }

        // �e�I�u�W�F�N�g�̎q�I�u�W�F�N�g���擾
        MeshFilter[] meshFilters = parentObject.GetComponentsInChildren<MeshFilter>();

        // �e�q�I�u�W�F�N�g��MeshCollider��ǉ�
        foreach (MeshFilter meshFilter in meshFilters)
        {
            if (meshFilter.gameObject.GetComponent<MeshCollider>() == null)
            {
                MeshCollider meshCollider = meshFilter.gameObject.AddComponent<MeshCollider>();
                meshCollider.sharedMesh = meshFilter.sharedMesh;
            }
        }

        Debug.Log("MeshColliders added to all children with MeshFilter.");
    }
}


