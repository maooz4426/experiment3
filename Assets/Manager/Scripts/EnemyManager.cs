using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject enemy1;
    [SerializeField] private GameObject enemy2;
    [SerializeField] private GameObject enemy3;
    private GameObject enemy1Instance;
    private GameObject enemy2Instance;
    private GameObject enemy3Instance;

    //現在の敵
    private GameObject currentEnemy;
    private EnemyController currentEnemyController;

    [Header("FirstEnemyPositionParameter")]
    private Vector3 firstEnemyPosition;
    [SerializeField] private float xAdd = 0;
    [SerializeField] private float yAdd = 10;
    [SerializeField] private float zAdd = 10;

    private GameViewManager gameViewManager;
    

    private void Awake()
    {
        gameViewManager = GameObject.Find("GameView").GetComponent<GameViewManager>();
        firstEnemyPosition = new Vector3 (gameViewManager.GetCenter().x + xAdd, yAdd, gameViewManager.GetCenter().z+zAdd);
        enemy1Instance = Instantiate(enemy1, firstEnemyPosition, Quaternion.identity);
        enemy1Instance.GetComponent<CharacterController>().enabled = false;
    }

    private void Start()
    {
        enemy1Instance.GetComponent<CharacterController>().enabled = true;
        currentEnemy = enemy1Instance;
        currentEnemyController = currentEnemy.GetComponent<EnemyController>();
    }

    private void Update()
    {
        if (currentEnemyController.GetHp() <= 0)
        {
            ChangeEnemy();
        }
    }

    private void ChangeEnemy()
    {
        //hpが0以下になったら変更
        Vector3 currentPosition;
        switch (currentEnemyController.GetEnemyNum())
        {
                
            case 1:
                currentPosition = currentEnemy.transform.position;
                Destroy(currentEnemy);
                enemy2Instance = Instantiate(enemy2, currentPosition, Quaternion.identity);
                break;
            case 2:
                currentPosition = currentEnemy.transform.position;
                Destroy(currentEnemy);
                enemy3Instance = Instantiate(enemy3, currentPosition, Quaternion.identity);
                break;

        }
    }
    

}

