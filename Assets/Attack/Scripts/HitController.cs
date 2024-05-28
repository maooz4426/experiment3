using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HitController : MonoBehaviour
{
    private PlayerController playerController;
    private EnemyController enemyController;
    [SerializeField] private float hitDamage = 10f;
    [SerializeField] private string targetTagName = "Enemy";
    private bool hitcheck = false;
    private bool targetEnemy;
    [SerializeField] private bool Enemy = true;

    //弾丸は当たったら消えるように
    [SerializeField] bool bullet = false;
    //血のエフェクト用に
    [SerializeField]private EffectManger effectManger;
    //バイブレーション用
    private RightWeaponController weaponController;
    //[SerializeField] private GameObject blood;
    //[SerializeField] private float disapper = 3f;


    [SerializeField] private AudioClip hitclip;
    private AudioSource hitSource;

    
    //[SerializeField] private AudioClip hitEnemyClip;
    //private AudioSource hitEnemySource;


    private void Start()
    {
        if (GameObject.FindWithTag(targetTagName))
        {
            enemyController = GameObject.FindWithTag(targetTagName).GetComponent<EnemyController>();
        }
        else
        {
            //���l������enemybody�t���Ă�̂ŎQ�Ƃ̎d����ς���
            enemyController = GameObject.FindWithTag("EnemyBody").GetComponent<EnemyController>();
        }
        

        effectManger = GameObject.Find("EffectManager").GetComponent<EffectManger>();

        weaponController = GameObject.Find("RightWeaponController").GetComponent<RightWeaponController>();

        hitSource = this.AddComponent<AudioSource>();
        hitSource.clip = hitclip;
        hitSource.loop = false;

        //hitEnemySource = this.AddComponent<AudioSource>();
        //hitEnemySource.clip = hitEnemyClip;
        //hitEnemySource.loop = false;
    }

    private void OnTriggerEnter(Collider col)
    {

        if(col.gameObject.tag == "EnemyBody")
        {

            hitSource.Play();

            //hitEnemySource.Play();

            enemyController.DecreaseHp(hitDamage);

            enemyController.PlayHitEnemySound();

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
            
            
        }
        //else if(col.gameObject.tag == "Player")
        //{
        //    playerController.DecreaseHp(hitDamage);
        //    Debug.Log(playerController.GetHp());
        //}
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
