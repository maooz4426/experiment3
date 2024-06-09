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


    [SerializeField] private AudioClip hitclip;
    private AudioSource hitSource;

    private bool curse = false;
    

    private void Start()
    {
        if (targetTagName=="Enemy")
        {
            if (GameObject.FindWithTag(targetTagName))
            {
                enemyController = GameObject.FindWithTag(targetTagName).GetComponent<EnemyController>();
            }
            else
            {
                //EnemyがなかったらEnemyBodyに
                enemyController = GameObject.FindWithTag("EnemyBody").GetComponent<EnemyController>();
            }
           
        }
        else if (targetTagName=="Player")
        {
            playerController = GameObject.FindWithTag(targetTagName).GetComponent<PlayerController>();
        }
        

        effectManger = GameObject.Find("EffectManager").GetComponent<EffectManger>();

        weaponController = GameObject.Find("RightWeaponController").GetComponent<RightWeaponController>();

        hitSource = this.AddComponent<AudioSource>();
        hitSource.clip = hitclip;
        hitSource.loop = false;
    }

    private void OnTriggerEnter(Collider col)
    {

        if((col.gameObject.tag == targetTagName) || (col.gameObject.tag == "EnemyBody"))
        {

            hitSource.Play();

            //hitEnemySource.Play();
            if(targetTagName == "Enemy")
            {
                enemyController.DecreaseHp(hitDamage);

                enemyController.PlayHitEnemySound();

                effectManger.OnBlood(this.transform.position);
            }
            else if(targetTagName == "Player")
            {
                playerController.DecreaseHp(hitDamage);
                hitSource.Play();
                Debug.Log(playerController.GetHp());
            }
            

            hitcheck = true;

            if (!bullet || !curse)
            {
                VibrationController.instance.StartVibration(1.0f, 1.0f, 0.5f, OVRInput.Controller.RTouch);
            }
            
            if (bullet)
            {
                Destroy(this.gameObject);
            }
            Debug.Log("hit");
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
