using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ReneController : MonoBehaviour
{
    //èÛë‘Çä«óù
    private enum EnemyState
    {
        Chase,
        Wait,
        Attack,
        Damaged,
    }
    [SerializeField] private EnemyState state;

    [SerializeField] private GameObject attack1;


    private GameObject[] attacks;
    //[SerializeField] private GameObject attackPosition;
    //private ParticleSystem curse;

    private GameObject player;
    private PlayerController playerController;

    private float timer = 0f;

    [SerializeField] private AudioClip attackClip;
    private AudioSource attackSource;

    private bool sound = false;

    private void Start()
    {
        this.state = EnemyState.Wait;

        player = GameObject.FindWithTag("Player");
        playerController = player.GetComponent<PlayerController>();


        attacks = new GameObject[] { attack1};

        foreach (GameObject attack in attacks)
        {
            //attack.transform.rotation = Quaternion.LookRotation(targetDirection);
            attack.GetComponent<ParticleSystem>().Stop();
        }

        attackSource = this.AddComponent<AudioSource>();
        attackSource.clip = attackClip;
        attackSource.loop = false;

        //curse = this.GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        Vector3 targetInterval = player.transform.position - this.transform.position;
        Vector3 targetDirection = targetInterval.normalized;

        AtackPlayer();

        switch (state)
        {
            case EnemyState.Wait:
                if (targetInterval.magnitude > 5f)
                {
                    state = EnemyState.Chase;
                }
                break;
            case EnemyState.Chase:
                if (targetInterval.magnitude < 5f)
                {
                    state = EnemyState.Wait;
                }
                break;
            case EnemyState.Attack:
                //attack1.transform.rotation = Quaternion.LookRotation(targetDirection);

                //attack1.GetComponent<ParticleSystem>().Play();


                foreach (GameObject attack in attacks)
                {

                    attack.transform.rotation = Quaternion.LookRotation(targetDirection);
                    attack.GetComponent<ParticleSystem>().Play();

                }

                timer += Time.deltaTime;
                if (timer > 3f)
                {
                    timer = 0;
                    state = EnemyState.Wait;
                    //attack1.GetComponent<ParticleSystem>().Stop();
                    foreach (GameObject attack in attacks)
                    {
                        attack.transform.rotation = Quaternion.LookRotation(targetDirection);
                        attack.GetComponent<ParticleSystem>().Stop();
                        sound = false;
                    }
                }
                break;
        }
    }

    private void AtackPlayer()
    {
        float r = Random.Range(0, 100);

        switch (r)
        {
            case 5:
                state = EnemyState.Attack;
                AttackSound();
                sound = true;
                break;
        }
    }

    private void AttackSound()
    {
        if (!sound)
        {
            attackSource.Play();
            sound = true;
        }

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log(playerController.GetHp());
        }
    }
}
