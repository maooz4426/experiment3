using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AddWeaponParameter : MonoBehaviour
{
    [MenuItem("Tools/Add WeaponParameter to Children MeshFilter")]
    static void AddColliders()
    {
        // 親オブジェクトを取得
        GameObject parentObject = Selection.activeGameObject;

        //親がいない場合は警告
        if (parentObject == null)
        {
            Debug.LogWarning("No game object selected.");
            return;
        }

        // 子オブジェクトの親オブジェクトにあるMeshFilterを取得
        MeshFilter[] meshFilters = parentObject.GetComponentsInChildren<MeshFilter>();

        // 子親オブジェクトにMeshColliderを追加
        foreach (MeshFilter meshFilter in meshFilters)
        {
            meshFilter.gameObject.tag = "weapon";
            MeshCollider meshCollider;

            meshCollider = meshFilter.gameObject.GetComponent<MeshCollider>();

            if (meshCollider == null)
            {
                meshCollider = meshFilter.gameObject.AddComponent<MeshCollider>();
                meshCollider.sharedMesh = meshFilter.sharedMesh;
            }

            Rigidbody rigid = meshFilter.gameObject.GetComponent<Rigidbody>();

            if (rigid != null)
            {
                DestroyImmediate(rigid);
            }

            meshCollider.sharedMesh = meshFilter.sharedMesh; // meshfilterに基づいているメッシュをmeshcolliderに設定
            meshCollider.convex = true;
            meshCollider.isTrigger = true;
        }
    }
}


