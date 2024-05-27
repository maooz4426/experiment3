using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MyakuController : MonoBehaviour
{
    // Animator コンポーネント
    private Animator animator;
    // 設定したフラグの名前
    private const string key_isWalk = "isWalk";
    private const string key_isAttack = "isAttack";
    private const string key_isDamaged00 = "isDamaged00";
    private const string key_isDamaged01 = "isDamaged01";

    private float timer = 0f;

    private CharacterController characterController;

    //Player
    private GameObject player;
    private MeshCollider[] colliders;

    //状態を管理
    private enum EnemyState
    {
        Chase,
        Wait,
        Attack,
        Damaged,
    }
    [SerializeField] private EnemyState state;

    [SerializeField]private float speed = 10;

    private void Start()
    {
        
        this.animator = GetComponentInChildren<Animator>();
        characterController = this.GetComponent<CharacterController>();
        player = GameObject.FindWithTag("Player");
        this.state = EnemyState.Wait;
        this.animator.SetBool(key_isWalk, true);

        colliders = this.GetComponentsInChildren<MeshCollider>();

        Vector3 targetInterval = player.transform.position - this.transform.position;
        Vector3 targetDirection = targetInterval.normalized;

        this.transform.rotation = Quaternion.LookRotation(new Vector3(0,0,targetDirection.z));
       
    }

    private void Update()
    {
        //this.transform.rotation = Quaternion.LookRotation(player.transform.position);
        Vector3 targetInterval = player.transform.position - this.transform.position;
        Vector3 targetDirection = targetInterval.normalized;
        AtackPlayer();
        
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
                    if (characterController.isGrounded)
                    {
                        state = EnemyState.Chase;
                    }                    
                    
                   //this.animator.SetBool(key_isWalk, true);                  

                }
                break;

            case EnemyState.Damaged:
                this.animator.SetBool(key_isDamaged00,true);
                timer += Time.deltaTime;
                Debug.Log(timer);
                if (timer > 3f)
                {
                    timer = 0;
                    state = EnemyState.Wait;
                }
                break;
            case EnemyState.Attack:
                this.animator.SetBool(key_isAttack,true);
                timer += Time.deltaTime;
                if(timer > 3f)
                {
                    timer = 0;
                    state = EnemyState.Wait;
                }

                break;

        }


    }

    private void AtackPlayer()
    {
        float r = Random.Range(0, 100);

        switch (r)
        {
            case 5:
                state = EnemyState.Attack;
                break;
        }
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "weapon")
        {
            state = EnemyState.Damaged;
        }
    }

}
