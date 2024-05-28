using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameViewManager : MonoBehaviour
{
    private GameObject player;

    [Header("FieldsParameter")]
    [SerializeField] private Terrain terrain; //GameObjectにしてはだめ
    private Terrain terrainInstance;
    private TerrainData terrainData;
    private Vector3 terrainSize;

    private EnemyManager enemyManager;

    [SerializeField] private GameObject EndView;
    private bool endview = false;


    void Awake()
    {
        player = GameObject.Find("Player");
        player.GetComponent<Rigidbody>().useGravity = true;

        //terrainを生成させてかつサイズを取得
        terrainInstance = Instantiate(terrain);
        terrainData = terrainInstance.terrainData;
        terrainSize = terrainData.size;

        //playerのポジションをTerrainの真ん中に
        //player.transform.position = new Vector3(terrainSize.x/2, 0, terrainSize.z/2);
        player.transform.position = GetCenter();

        enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
    }

    private void Update()
    {
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
}
