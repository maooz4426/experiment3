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

    [Header("FirstEnemyPositionParameter")]
    private Vector3 firstEnemyPosition;
    [SerializeField] private float xAdd = 0;
    [SerializeField] private float yAdd = 10;
    [SerializeField] private float zAdd = 10;

    private GameViewManager gameViewManager;
    

    private void Start()
    {
        gameViewManager = GameObject.Find("GameView").GetComponent<GameViewManager>();
        firstEnemyPosition = new Vector3 (gameViewManager.GetCenter().x + xAdd, yAdd, gameViewManager.GetCenter().z+zAdd);

        enemy1Instance = Instantiate(enemy1,firstEnemyPosition,Quaternion.identity);
        
    }
}
