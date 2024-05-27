using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponManager : MonoBehaviour
{
    [Tooltip("playerprefab�̖��O�����")]
    [SerializeField] private string PlayerName;
    [SerializeField] private string EnemyName;

    private GameObject player;

    private GameObject enemy;


    [Header("WeaponParameter")]
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletDamage = 10f;
    private HitController bulletHitController;
    [SerializeField] private GameObject sord;
    [SerializeField] private float sordDamage = 10f;
    private HitController sordHitContorller;
    [SerializeField] private GameObject icepick;
    private HitController pickHitController;

    private float playerHp;
    private float enemyHp;

    private void Start()
    {
        player = GameObject.Find(PlayerName);
        enemy = GameObject.FindWithTag("Enemy");
        playerHp = player.GetComponent<PlayerController>().GetHp();
        enemyHp = enemy.GetComponent<EnemyController>().GetHp();

        bulletHitController = bullet.GetComponent<HitController>();
        bulletHitController.SetDamage(bulletDamage);
        //bulletHitController.SetTarget(EnemyName);

        sordHitContorller= sord.GetComponent<HitController>();
        sordHitContorller.SetDamage(sordDamage);
        //sordHitContorller.SetTarget(EnemyName);

        pickHitController = icepick.GetComponent<HitController>();
        //pickHitController.SetTarget(EnemyName);

    }

    private void Update()
    {
        playerHp = player.GetComponent<PlayerController>().GetHp();
        enemyHp = enemy.GetComponent<EnemyController>().GetHp();
    }

    public void ChangeTargetEnemy(GameObject enemyNow)
    {
        enemy = enemyNow;
        enemyHp = enemy.GetComponent<EnemyController>().GetHp();
        Debug.Log("changeEnemy");
    }
}
