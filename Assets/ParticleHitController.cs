using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleHitController : MonoBehaviour
{
    private PlayerController playerController;
    private EnemyController enemyController;
    [SerializeField] private float hitDamage = 0.1f;
    [SerializeField] private string targetTagName = "Player";

    private ParticleSystem particleSystem;

    private void Start()
    {
        playerController = GameObject.FindWithTag(targetTagName).GetComponent<PlayerController>();

        particleSystem = GetComponent<ParticleSystem>();
    }

    private void OnParticleCollision(GameObject player)
    {
        PerformActionOnCollision(player);
        
    }

    void PerformActionOnCollision(GameObject player)
    {
        if (player.gameObject.tag == targetTagName)
        {
            playerController.DecreaseHp(hitDamage);
            Debug.Log(playerController.GetHp());
        }
    }
}
