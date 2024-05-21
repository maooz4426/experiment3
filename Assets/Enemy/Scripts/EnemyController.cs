using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float hp = 100;

    public float GetHp()
    {
        return hp;
    }

    public void DecreaseHp(float damage)
    {
        hp -= damage;
    }
}
