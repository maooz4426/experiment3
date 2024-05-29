using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float hp = 100;
    [SerializeField] private int enemyNum;

    [SerializeField] private AudioClip hitEnemyClip;
    private AudioSource hitEnemySource;

    private void Start()
    {
        hitEnemySource = this.AddComponent<AudioSource>();
        hitEnemySource.clip = hitEnemyClip;
        hitEnemySource.loop = false;
    }

    public void PlayHitEnemySound()
    {
        try
        {
            hitEnemySource.Play();
        }catch (System.Exception e)
        {
            Debug.LogError(e.ToString());
        }
    }

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
