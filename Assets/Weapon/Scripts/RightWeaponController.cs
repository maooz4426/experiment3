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

        parent = this.transform;
        //初めは右コントローラーを表示
        currentWeapon = Instantiate(rightController, parent);
    }

    private void Update()
    {
        ChangeWeapon();
    }

    public void ChangeWeapon()
    {
        //Debug.Log(changeable);
        //右中指のトリガーを上げたら動作
        if (OVRInput.Get(OVRInput.Button.SecondaryHandTrigger)&&changeable)
        {
            Debug.Log(weaponCnt);
            changeable = false;
            if(weaponCnt == 0)
            {
                //右コントローラーを削除
                Destroy(currentWeapon);
                //剣を生成
                currentWeapon = Instantiate(sord, parent);
                Debug.Log("change");
                weaponCnt++;
            }
            else if(weaponCnt == 1)
            {
                //剣を削除
                Destroy(currentWeapon);
                //コントローラーを生成
                currentWeapon = Instantiate(rightController, parent);
                Debug.Log("change");
                weaponCnt++;
            }else if(weaponCnt == 2)
            {
                Destroy(currentWeapon);
                currentWeapon = Instantiate(gun, parent);
                weaponCnt++;
            }

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
