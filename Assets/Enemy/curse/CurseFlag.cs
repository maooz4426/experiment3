using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurseFlag : MonoBehaviour
{
    public bool ParticleFlag; //パーティクルが出てるかどうか(攻撃可能か)
    private float timer = 0f; //タイマー

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // タイマーを更新
        timer += Time.deltaTime;
        
        //パーティクル出て2秒間、フラグをfalseにする(プレーヤーは攻撃不可)
        if ((timer % 8) <= 2){
            ParticleFlag = false;
        } else {
            ParticleFlag = true;
        }
    }
}
