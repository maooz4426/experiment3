using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameViewManager : MonoBehaviour
{
    private GameObject player;
    private PlayerController playerController;

    [Header("FieldsParameter")]
    [SerializeField] private Terrain terrain; //GameObject????????????
    [SerializeField] private GameObject loseView;
    private Terrain terrainInstance;
    private TerrainData terrainData;
    private Vector3 terrainSize;

    private EnemyManager enemyManager;

    [SerializeField] private GameObject EndView;
    private bool endview = false;

    private bool lose = false;


    //優先的に実行したいものをAwakeメソッドに
    void Awake()
    {
        
        player = GameObject.FindWithTag("Player");
        
        //playercontrollerで設置したgameview時の設定を実行
        playerController = player.GetComponent<PlayerController>();
        playerController.GameStart();
        
        
        
        
        // player = GameObject.Find("Player");
        // player.GetComponent<Rigidbody>().useGravity = true;

        //terrainを設定
        terrainInstance = Instantiate(terrain);
        terrainData = terrainInstance.terrainData;
        terrainSize = terrainData.size;

        //player???|?W?V??????Terrain???^??????
        //player.transform.position = new Vector3(terrainSize.x/2, 0, terrainSize.z/2);
        

        enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
    }

    void Start()
    {
        //terrainの中央にする
        player.transform.position = GetCenter();
    }

    private void Update()

    {

        if (player.GetComponent<PlayerController>().GetHp() < 0)
        {
            LoseView();
        }

       
        //{
        //    Vector3 position = new Vector3(player.transform.position.x, this.transform.position.y, this.transform.position.z + 100);
        //    Instantiate(loseView, position, Quaternion.identity);
        //}
        //if (enemyManager.CheckEnd() == true & endview==false)
        //{
        //    Vector3 position = GameObject.FindWithTag("EnemyBody").transform.position;
        //    Instantiate(EndView,position,Quaternion.identity);
        //    endview = true;
        //}
    }

    public Vector3 GetCenter()
    {
        return new Vector3(terrainSize.x/2,0,terrainSize.z/2);
    }

    private void LoseView()
    {
        if (!lose)
        {
            Vector3 position = new Vector3(player.transform.position.x, player.transform.position.y+100, player.transform.position.z + 1000);
            Instantiate(loseView, position, Quaternion.identity);
            Destroy(GameObject.FindWithTag("GameView"));
            player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            lose = true;
        }

    }
}
