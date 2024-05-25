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

        //選択肢てなかったら終了
        if (parentObject == null)
        {
            Debug.LogWarning("No game object selected.");
            return;
        }

        // 親オブジェクトの子オブジェクトにあるMeshFileterを取得
        MeshFilter[] meshFilters = parentObject.GetComponentsInChildren<MeshFilter>();

        // 各子オブジェクトにMeshColliderを追加
        foreach (MeshFilter meshFilter in meshFilters)
        {
            meshFilter.gameObject.tag = "Enemy";
               MeshCollider meshCollider;
           
               meshCollider = meshFilter.gameObject.GetComponent<MeshCollider>();

                if (meshCollider == null)
                {
                    meshCollider = meshFilter.gameObject.AddComponent<MeshCollider>();
                    meshCollider.sharedMesh = meshFilter.sharedMesh;
                }


                meshCollider.sharedMesh = meshFilter.sharedMesh;//meshfilterについているメッシュをmeshcolliderを付けています。
                meshCollider.convex = true;
                meshCollider.isTrigger = true;
                
            
        }

       
    }
}


