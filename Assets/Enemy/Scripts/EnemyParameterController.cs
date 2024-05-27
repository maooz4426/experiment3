using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParameterController : MonoBehaviour
{
    [SerializeField] private float hp = 100;
    [SerializeField] private int enemyNum;

    public float GetHp()
    {
        return hp;
    }

    public void DecreaseHp(float damage)
    {
        hp -= damage;
    }

    public int GetEnemyNum()
    {
        return enemyNum;
    }
}
