using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AddEnemyParameter : MonoBehaviour
{
    [MenuItem("Tools/Add EnemyParameter to Children")]
    static void AddColliders()
    {
        // �I�������I�u�W�F�N�g���擾
        GameObject parentObject = Selection.activeGameObject;

        //�I�����ĂȂ�������I��
        if (parentObject == null)
        {
            Debug.LogWarning("No game object selected.");
            return;
        }

        // �e�I�u�W�F�N�g�̎q�I�u�W�F�N�g�ɂ���MeshFileter���擾
        MeshFilter[] meshFilters = parentObject.GetComponentsInChildren<MeshFilter>();

        // �e�q�I�u�W�F�N�g��MeshCollider��ǉ�
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

            //if (rigid == null)
            //{
            //    rigid = meshFilter.gameObject.AddComponent<Rigidbody>();
            //}
            if(rigid != null)
            {
                DestroyImmediate(rigid);
            }
            
            rigid.useGravity = false;
            meshCollider.sharedMesh = meshFilter.sharedMesh;//meshfilter�ɂ��Ă��郁�b�V����meshcollider��t���Ă��܂��B
                meshCollider.convex = true;
                meshCollider.isTrigger = true;
                
            
        }

       
    }
}


