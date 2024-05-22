using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyrotation : MonoBehaviour
{
    // Start is called before the first frame update
    public float enemyrotationSpeed = 200f; // 回転速度
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 1/300の確率で逆回転を行う
        if (Random.Range(0, 300) == 0)
        {
            enemyrotationSpeed *= -1; // -1倍することで逆回転を実装する
        }
        // 1/400の確率で速度を上げる
        if (Random.Range(0, 400) == 1)
        {
            enemyrotationSpeed += 45; // 25ずつ増やしていく
        }
        // 1/600の確率で速度を下げる
        if (Random.Range(0, 600) == 2)
        {
            enemyrotationSpeed -= 10; // 25ずつ減らしていく
        }
        transform.Rotate(Vector3.up, enemyrotationSpeed * Time.deltaTime);
    }
}
