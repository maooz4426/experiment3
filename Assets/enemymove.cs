using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private string enemy;
    public GameObject player; // 追いかけられる方(プレイヤー(カメラ))
    public GameObject mya; // 追いかける方(ミャクミャク)
    public float enemySpeed = 20f; // 敵の移動速度
    public float stopDistance = 5f; // 追跡を停止する距離
    public float offsetDistance = 1f; // カメラの少し下に向かう距離

    void Start()
    {
        //プレイヤーオブジェクトを見つける
        player = GameObject.Find("Player");
        //myaはenemyである
        mya = GameObject.Find(enemy);
        
        // オブジェクトのローカル回転を調整
        transform.rotation = Quaternion.Euler(90, 0, 0);
    }
        
    void Update()
    {
       
        
        if (player == null)
            return; // プレイヤーオブジェクトがない場合は何もしない

        // プレイヤーと敵の距離を計算
        float distance = Vector3.Distance(mya.transform.position, player.transform.position);
                
        // プレイヤーを追いかける
        if (distance > stopDistance)
        {
            // カメラの少し下に向かう位置を計算
            Vector3 targetPosition = player.transform.position - player.transform.up * offsetDistance;
            
            
            transform.LookAt(targetPosition, Vector3.back);
            transform.position += transform.forward * enemySpeed * Time.deltaTime;
        }   
    }
}
