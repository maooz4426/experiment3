using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AddMeshCollider : MonoBehaviour
{


    [MenuItem("Tools/Add Mesh Colliders to Children")]
    static void AddColliders()
    {
        // 選択したオブジェクトを取得
        GameObject parentObject = Selection.activeGameObject;

        if (parentObject == null)
        {
            Debug.LogWarning("No game object selected.");
            return;
        }

        // 親オブジェクトの子オブジェクトを取得
        MeshFilter[] meshFilters = parentObject.GetComponentsInChildren<MeshFilter>();

        // 各子オブジェクトにMeshColliderを追加
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


