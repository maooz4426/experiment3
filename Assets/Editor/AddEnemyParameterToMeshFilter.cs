using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AddEnemyParameterToMeshFilter : MonoBehaviour
{
    [MenuItem("Tools/Add EnemyParameter to Children MeshFilter")]
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
            meshFilter.gameObject.tag = "EnemyBody";
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


//using System.Collections;
//using System.Collections.Generic;
//using UnityEditor;
//using UnityEngine;

//public class AddEnemyParameterToMeshFilter : MonoBehaviour
//{
//    [MenuItem("Tools/Add EnemyParameter to Children")]
//    static void AddColliders()
//    {
//        // �I�������I�u�W�F�N�g���擾
//        GameObject parentObject = Selection.activeGameObject;

//        //�I�����ĂȂ�������I��
//        if (parentObject == null)
//        {
//            Debug.LogWarning("No game object selected.");
//            return;
//        }

//        // �e�I�u�W�F�N�g�̎q�I�u�W�F�N�g�ɂ���MeshFileter���擾
//        MeshFilter[] meshFilters = parentObject.GetComponentsInChildren<MeshFilter>();

//        // �e�q�I�u�W�F�N�g��MeshCollider��ǉ�
//        foreach (MeshFilter meshFilter in meshFilters)
//        {
//            meshFilter.gameObject.tag = "EnemyBody";
//               MeshCollider meshCollider;

//               meshCollider = meshFilter.gameObject.GetComponent<MeshCollider>();

//                if (meshCollider == null)
//                {
//                    meshCollider = meshFilter.gameObject.AddComponent<MeshCollider>();
//                    meshCollider.sharedMesh = meshFilter.sharedMesh;
//                }


//            Rigidbody rigid = meshFilter.gameObject.GetComponent<Rigidbody>();

//            //if (rigid == null)
//            //{
//            //    rigid = meshFilter.gameObject.AddComponent<Rigidbody>();
//            //}
//            if(rigid != null)
//            {
//                DestroyImmediate(rigid);
//            }

//            rigid.useGravity = false;
//            meshCollider.sharedMesh = meshFilter.sharedMesh;//meshfilter�ɂ��Ă��郁�b�V����meshcollider��t���Ă��܂��B
//                meshCollider.convex = true;
//                meshCollider.isTrigger = true;


//        }


//    }
//}


