using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float MoveSpeed;
    [SerializeField] int MaxHealth;
    [SerializeField] Transform playerPos;
    Vector3 dirMove;
    Player player;

    int Health;

    int expAmount = 10;



    void Start()
    {
        Health = MaxHealth;

        player = FindFirstObjectByType<Player>();
    }

    void Update()
    {
        dirMove = unitmanager.Instance.player.transform.position - transform.position;

        transform.position += dirMove.normalized * Time.deltaTime * MoveSpeed;
    }

    public void TakeDamage(int someDamage)
    {
        Health -= someDamage;
        if (Health <= 0) Death();
    }

    void Death()
    {
        player.XP++;
        //player.XP += 1; // player.XP = player.XP + 1;
             Destroy(gameObject);
    }

    
}

