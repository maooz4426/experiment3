using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitController : MonoBehaviour
{
    private PlayerController playerController;
    private EnemyParameterController enemyParameterController;
    [SerializeField] private float hitDamage = 10f;
    [SerializeField] private string targetTagName = "Enemy";
    private bool hitcheck = false;
    private bool targetEnemy;

    //弾丸は当たったら消えるように
    [SerializeField] bool bullet = false;
    //血のエフェクト用に
    [SerializeField]private EffectManger effectManger;
    //バイブレーション用
    private RightWeaponController weaponController;
    //[SerializeField] private GameObject blood;
    //[SerializeField] private float disapper = 3f;

    private void Start()
    {
        if (GameObject.FindWithTag(targetTagName))
        {
            enemyParameterController = GameObject.FindWithTag(targetTagName).GetComponent<EnemyParameterController>();
        }
        else
        {
            //���l������enemybody�t���Ă�̂ŎQ�Ƃ̎d����ς���
            enemyParameterController = GameObject.FindWithTag("EnemyBody").GetComponent<EnemyParameterController>();
        }
        

        effectManger = GameObject.Find("EffectManager").GetComponent<EffectManger>();

        weaponController = GameObject.Find("RightWeaponController").GetComponent<RightWeaponController>();
    }

    private void OnTriggerEnter(Collider col)
    {

        if(col.gameObject.tag == "EnemyBody")
        {

            enemyParameterController.DecreaseHp(hitDamage);
            hitcheck = true;
            if (!bullet)
            {
                VibrationController.instance.StartVibration(1.0f, 1.0f, 0.5f, OVRInput.Controller.RTouch);
                
            }
            
            effectManger.OnBlood(this.transform.position);

            if (bullet)
            {
                Destroy(this.gameObject);
            }
            
       
            Debug.Log("hit");
            
            
        }else if(col.gameObject.tag == "Player")
        {
            playerController.DecreaseHp(hitDamage);
            Debug.Log(playerController.GetHp());
        }
    }

 

    public bool CheckHit()
    {
        return hitcheck;
    }

    public void ChangeHitChecked()
    {
        if (hitcheck)
        {
            hitcheck = false;
        }
        
    }

    public void SetDamage(float damage)
    {
        hitDamage = damage;
    }

    public void SetTarget(string name)
    {
        targetTagName = name;
    }

  
}
