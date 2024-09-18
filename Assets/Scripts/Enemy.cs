using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float MoveSpeed;
    [SerializeField] int MaxHealth;
    [SerializeField] Transform playerPos;
    Vector3 dirMove;

    int Health;

    void Start()
    {
        Health = MaxHealth;
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
        Destroy(gameObject);
    }

    
}

