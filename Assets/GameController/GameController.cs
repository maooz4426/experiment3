using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameController : MonoBehaviour
{
    [Tooltip("playerprefab‚Ì–¼‘O‚ð“ü—Í")]
    [SerializeField] private string PlayerName;
    [SerializeField] private string EnemyName;
    [Header("PlayerParameter")]
    [SerializeField] private GameObject player;

    [Header("EnemyParameter")]
    [SerializeField] private GameObject enemy;

    [Header("WeaponParameter")]
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletDamage = 10f;
    private HitController bulletHitController;
    [SerializeField] private GameObject sord;
    [SerializeField] private float sordDamage = 10f;
    private HitController sordHitContorller;


    private float playerHp;
    private float enemyHp;

    private void Awake()
    {
        playerHp = player.GetComponent<PlayerController>().GetHp();
        enemyHp = enemy.GetComponent<EnemyController>().GetHp();

        bulletHitController = bullet.GetComponent<HitController>();
        bulletHitController.SetDamage(bulletDamage);
        bulletHitController.SetTarget(EnemyName);

        sordHitContorller= sord.GetComponent<HitController>();
        sordHitContorller.SetDamage(sordDamage);
        sordHitContorller.SetTarget(EnemyName);
    }

    private void Update()
    {
        playerHp = player.GetComponent<PlayerController>().GetHp();
        enemyHp = enemy.GetComponent<EnemyController>().GetHp();
    }
}
