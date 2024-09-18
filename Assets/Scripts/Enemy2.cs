using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    [SerializeField] float MoveSpeed;
    [SerializeField] int MaxHealth;
    [SerializeField] Transform playerPos;
    Vector3 dirMove;

    int xpValue = 10;
    GameObject XP;

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
    void DropXP()
    {
        //XPOrb orb = Instantiate(XP, transform.position, Quaternion.identity).GetComponent<XPOrb>;  // Create the XP object at the enemy's position
        //orb.setValues(xpValue);

    }

    void Death()
    {
        DropXP();
        Destroy(gameObject);
    }

    
}

