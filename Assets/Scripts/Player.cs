using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Transform AxeTransform;
    public float MoveSpeed;
    public int MaxHealth;
    public int Health { get; private set; }  // Public property for Health

    float horizontalMove;
    float verticalMove;
    Vector3 movement;

    // Method to retrieve MaxHealth
    public int GetMaxHealth()
    {
        return MaxHealth;
    }

    void Start()
    {
        Health = MaxHealth;  // Initialize health at the start
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");
        movement = new Vector3(horizontalMove, verticalMove, 0) * Time.deltaTime * MoveSpeed;

        transform.position += movement;

        // Rotate axe towards the mouse pointer
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 AxeDirection = mousePos - transform.position;
        float angle = Mathf.Atan2(AxeDirection.y, AxeDirection.x) * Mathf.Rad2Deg - 90;
        AxeTransform.rotation = Quaternion.Euler(0, 0, angle);
    }

    //collider2dcollision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Player tagged object detected.");
            TakeDamage(1);
        }
    }


    // Method for taking damage
    public void TakeDamage(int someDamage)
    {
        Health -= someDamage;
        if (Health <= 0)
        {
            Debug.Log("Player is dead.");
            Death();

        }
    }

    // Player death logic
    void Death()
    {
        Destroy(gameObject);
    }
}
