using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AddEnemyParameterToSkinnedMeshRender : MonoBehaviour
{
    [MenuItem("Tools/Add EnemyParameter to Children MeshRender")]
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
        SkinnedMeshRenderer[] meshRenders = parentObject.GetComponentsInChildren<SkinnedMeshRenderer>();

        // 子親オブジェクトにMeshColliderを追加
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

            meshCollider.sharedMesh = meshRender.sharedMesh; // meshfilterに基づいているメッシュをmeshcolliderに設定
            meshCollider.convex = true;
            meshCollider.isTrigger = true;
        }
    }
}
