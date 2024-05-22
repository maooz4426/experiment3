using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymove : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target; //追いかけられる方(プレイヤー)
    public GameObject mya; //追いかける方(ミャクミャク)
    public float enemyspeed = 1f; //敵の移動速度
    public float stopdistance = 10f; //カメラ追跡が終わる距離

    void Start()
    {
        target = GameObject.Find("Main Camera");
        mya = GameObject.Find("myakumyaku");
    }
        
    // Update is called once per frame
    void Update()
    {
        //距離を計算
        float distance = Vector3.Distance(mya.transform.position, target.transform.position);
                
        //プレイヤーを追いかける
        if(distance > stopdistance){
            transform.LookAt(target.transform);
            transform.position += transform.forward * enemyspeed;
        }
        
    }
}
