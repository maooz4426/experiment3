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

    private Vector3 firstEnemyPosition;

    
    private GameViewManager gameViewManager;
    

    private void Start()
    {
        gameViewManager = GameObject.Find("GameView").GetComponent<GameViewManager>();
        firstEnemyPosition = new Vector3 (gameViewManager.GetCenter().x,10, gameViewManager.GetCenter().z+10);

        enemy1Instance = Instantiate(enemy1,firstEnemyPosition,Quaternion.identity);
        
    }
}
