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
    //血しぶき
    [SerializeField]private EffectManger effectManger;
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
            //レネだけはenemybody付けてるので参照の仕方を変える
            enemyParameterController = GameObject.FindWithTag("EnemyBody").GetComponent<EnemyParameterController>();
        }
        //enemyParameterController = GameObject.FindWithTag(targetTagName).GetComponent<EnemyParameterController>();

        //if(enemyParameterController == null)
        //{
        //    enemyParameterController = GameObject.FindWithTag("EnemyBody").GetComponent<EnemyParameterController>();
        //}

        effectManger = GameObject.Find("EffectManager").GetComponent<EffectManger>();
        
        //SetController();
    }

    private void OnTriggerEnter(Collider col)
    {

        if(col.gameObject.tag == "EnemyBody")
        {

            enemyParameterController.DecreaseHp(hitDamage);
            hitcheck = true;
            effectManger.OnBlood(this.transform.position);

            Destroy(this.gameObject);
            
            //GameObject bloodInstance = Instantiate(blood,col.transform.position,Quaternion.identity);

            //Destroy(bloodInstance, disapper);
       
            Debug.Log("hit");
            //hitcheck = true;
            //ChangeHitChecked();
            //Debug.Log(enemyController.GetHp());
            
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

    //public void SetController()
    //{
    //    string target = GameObject.FindWithTag(targetTagName);
    //    if(target == "Player")
    //    {
    //        playerController = GameObject.Find(targetTagName).GetComponent<PlayerController>();
    //        targetEnemy = false;
    //    }else if(target == "Enemy")
    //    {
    //        enemyController = GameObject.Find(targetName).GetComponent<EnemyController>();
    //        targetEnemy = true;
    //    }
    //}
}
