using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitController : MonoBehaviour
{
    private PlayerController playerController;
    private EnemyController enemyController;
    [SerializeField] private float hitDamage = 10f;
    [SerializeField] private string targetName = "Enemy";
    private bool hitcheck = false;
    private bool targetEnemy;

    private void Awake()
    {
        enemyController = GameObject.Find(targetName).GetComponent<EnemyController>();
        SetController();
    }

    private void OnTriggerEnter(Collider col)
    {

        if(col.gameObject.tag == "Enemy")
        {
            enemyController.DecreaseHp(hitDamage);
            //Debug.Log("hit");
            hitcheck = true;
            //ChangeHitChecked();
            Debug.Log(enemyController.GetHp());
        }else if(col.gameObject.tag == "Player")
        {
            playerController.DecreaseHp(hitDamage);
            Debug.Log(playerController.GetHp());
        }
    }

    public bool CheckHit()
    {
        return hitcheck;
    }

    public void ChangeHitChecked()
    {
        if (hitcheck)
        {
            hitcheck = false;
        }
        
    }

    public void SetDamage(float damage)
    {
        hitDamage = damage;
    }

    public void SetTarget(string name)
    {
        targetName = name;
    }

    public void SetController()
    {
        string target = GameObject.Find(targetName).tag;
        if(target == "Player")
        {
            playerController = GameObject.Find(targetName).GetComponent<PlayerController>();
            targetEnemy = false;
        }else if(target == "Enemy")
        {
            enemyController = GameObject.Find(targetName).GetComponent<EnemyController>();
            targetEnemy = true;
        }
    }
}
