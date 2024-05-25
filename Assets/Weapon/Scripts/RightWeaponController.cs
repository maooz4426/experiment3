using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RightWeaponController : MonoBehaviour
{
    [Header("weapon")]
    //使う武器を登録するためのリスト
    private List<GameObject> weapons = new List<GameObject> ();

    //右コントローラーのprefab
    [SerializeField] private GameObject rightController;
    //剣のprefab
    [SerializeField] private GameObject sord;
    //銃のprefab
    [SerializeField] private GameObject gun;
    //icepickのprefab
    [SerializeField] private GameObject icePick;
    //装備してるweapon
    private GameObject currentWeapon;
    //右コントローラーの位置
    private Transform parent;
    //一度押したら一つだけの武器に変更できるように
    private bool changeable = true;
    //武器入れ替えのためのcount
    private int weaponCnt = 0;

    private void Awake()
    {
        //武器を登録
        weapons.Add(rightController);
        weapons.Add(sord);
        weapons.Add(gun);
        weapons.Add (icePick);
        parent = this.transform;
        //初めは右コントローラーを表示
        currentWeapon = Instantiate(rightController, parent);
    }

    private void Update()
    {
        if (CheckView())
        {
            ChangeWeapon();
        }
    }

    //Viewがgameviewだったら武器変更行えるように
    private bool CheckView()
    {
        GameObject Gameview = GameObject.Find("GameView");
        if (Gameview != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ChangeWeapon()
    {
        //Debug.Log(changeable);
        //右中指のトリガーを上げたら動作
        if (OVRInput.Get(OVRInput.Button.SecondaryHandTrigger)&&changeable)
        {
            Debug.Log(weaponCnt);
            changeable = false;
         
            //右コントローラーを削除
            Destroy(currentWeapon);
            //剣を生成
            currentWeapon = Instantiate(weapons[weaponCnt], parent);
            Debug.Log("change");
            weaponCnt++;
          

        }else if (OVRInput.GetUp(OVRInput.Button.SecondaryHandTrigger))
        {
            //右中指のトリガーを上げたらtureに
            changeable=true;
            //cntリセット
            if (weaponCnt == weapons.Count )
            {
                weaponCnt = 0;
            }
        }
   
    }
}
