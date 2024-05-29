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

    //敵を変更を適応させる
    private WeaponManager weaponManager;

    private bool end = false;

    [SerializeField] private GameObject endView;
    private Rigidbody rb;

    private void Awake()
    {
        //gameViewManager = GameObject.Find("GameView").GetComponent<GameViewManager>();
        gameViewManager = this.GetComponentInParent<GameViewManager>();
        firstEnemyPosition = new Vector3(gameViewManager.GetCenter().x + xAdd, yAdd, gameViewManager.GetCenter().z + zAdd);
        // enemy1Instance = Instantiate(enemy1, firstEnemyPosition, Quaternion.identity);
        // enemy1Instance.GetComponent<CharacterController>().enabled = false;
    }

    private void Start()
    {
        
        enemy1Instance.GetComponent<CharacterController>().enabled = true;
        currentEnemy = enemy1Instance;
        currentEnemyController = currentEnemy.GetComponent<EnemyController>();

        weaponManager = GameObject.Find("WeaponManager").GetComponent<WeaponManager>();
    }

    private void Update()
    {
        //Debug.Log(currentEnemyParameterController.GetHp());
        //hpが0以下になったら変更
        if (currentEnemyController.GetHp() <= 0)
        {
            ChangeEnemy();
        }
    }

    private void ChangeEnemy()
    {
        
        Vector3 currentPosition;
        //敵の個体番号でスイッチ
        switch (currentEnemyController.GetEnemyNum())
        {
                
            case 1:
                //敵入れ替えのためにやられた敵の位置を取得
                currentPosition = currentEnemy.transform.position;
                //現在の敵を削除
                Destroy(currentEnemy);
                //次の敵を生成
                enemy2Instance = Instantiate(enemy2, currentPosition, Quaternion.identity);
                //現在の敵を参照できるように
                currentEnemy = enemy2Instance;
                currentEnemyController = currentEnemy.GetComponent <EnemyController>();
                //weaponmanagerに変更を適応
                weaponManager.ChangeTargetEnemy(enemy2Instance);
                break;
            case 2:
                currentPosition = currentEnemy.transform.position;
                currentPosition.y += 2;
                Destroy(currentEnemy);
                enemy3Instance = Instantiate(enemy3, currentPosition, Quaternion.identity);
                currentEnemy = enemy3Instance;
                currentEnemyController = currentEnemy.GetComponent<EnemyController>();
                weaponManager.ChangeTargetEnemy(enemy3Instance);
                break;
            case 3:
                Instantiate(endView,gameViewManager.GetCenter(), Quaternion.identity);
                Destroy(currentEnemy);

                
                Destroy(GameObject.FindWithTag("GameView"));
                break;

        }
    }

    public void StartGame()
    {
        enemy1Instance = Instantiate(enemy1, firstEnemyPosition, Quaternion.identity);
        enemy1Instance.GetComponent<CharacterController>().enabled = true;
        
    }

    public bool CheckEnd()
    {
        return end;
    }

    
    

}

