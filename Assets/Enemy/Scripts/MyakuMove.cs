using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MyakuMove : MonoBehaviour
{
    // Animator コンポーネント
    private Animator animator;
    // 設定したフラグの名前
    private const string key_isWalk = "isWalk";
    private const string key_isAttack = "isAttack";
    private const string key_isDamaged00 = "isDamaged00";
    private const string key_isDamaged01 = "isDamaged01";

    private CharacterController characterController;

    //Player
    private GameObject player;

    //状態を管理
    private enum EnemyState
    {
        Chase,
        Wait,
        Attack,
        Attacked,
    }
    private EnemyState state;

    [SerializeField]private float speed = 10;

    private void Start()
    {
        
        this.animator = GetComponentInChildren<Animator>();
        characterController = this.GetComponent<CharacterController>();
        player = GameObject.FindWithTag("Player");
        this.state = EnemyState.Chase;
        this.animator.SetBool(key_isWalk, true);
        this.transform.rotation = Quaternion.LookRotation(player.transform.position);
    }

    private void Update()
    {
        Vector3 targetInterval = player.transform.position - this.transform.position;
        Vector3 targetDirection = targetInterval.normalized;
        
        switch (state) { 
            case EnemyState.Chase:
                this.animator.SetBool(key_isWalk, true);
                this.transform.rotation = Quaternion.LookRotation(targetDirection);
                characterController.Move(targetDirection * speed * Time.deltaTime);
                
                if (targetInterval.magnitude < 5)
                {
                    //this.animator.SetBool(key_isWalk, true);
                    state = EnemyState.Wait;

                }
                break;
            case EnemyState.Wait:
                this.animator.SetBool(key_isWalk, false);
                if (targetInterval.magnitude > 5)
                {
                    //this.animator.SetBool(key_isWalk, true);
                    state = EnemyState.Chase;

                }
                break;
        }


    }

}
