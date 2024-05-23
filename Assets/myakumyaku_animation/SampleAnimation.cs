using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleAnimation : MonoBehaviour
{
    // Animator コンポーネント
    private Animator animator;

    // 設定したフラグの名前
    private const string key_isWalk = "isWalk";
    private const string key_isAttack = "isAttack";
    private const string key_isDamaged00 = "isDamaged00";
    private const string key_isDamaged01 = "isDamaged01";

    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) {
            this.animator.SetBool(key_isWalk, true);
        }
        else {
            this.animator.SetBool(key_isWalk, false);
        }

        if (Input.GetKey(KeyCode.A)) {
            this.animator.SetBool(key_isAttack, true);
        }
        else {
            this.animator.SetBool(key_isAttack, false);
        }

        if (Input.GetKey(KeyCode.S)) {
            this.animator.SetBool(key_isDamaged00, true);
        }
        else {
            this.animator.SetBool(key_isDamaged00, false);
        }

        if (Input.GetKey(KeyCode.D)) {
            this.animator.SetBool(key_isDamaged01, true);
        }
        else {
            this.animator.SetBool(key_isDamaged01, false);
        }
    }
}
