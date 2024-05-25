using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameViewManager : MonoBehaviour
{
    private GameObject player;
 
   
    [SerializeField] private Terrain terrain; //GameObjectにしてはだめ
    private Terrain terrainInstance;
    private TerrainData terrainData;
    private Vector3 terrainSize;


    void Start()
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
    }
    
    public Vector3 GetCenter()
    {
        return new Vector3(terrainSize.x/2,0,terrainSize.z/2);
    }
}
