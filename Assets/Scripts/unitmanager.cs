using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unitmanager : MonoBehaviour
{
    public static unitmanager Instance { get; private set; }
    public GameObject Enemy;
    public GameObject Enemy2;

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

    }
    public GameObject player;
    private void Start()
    {
        player = GameObject.Find("Player");
        StartCoroutine(spawnenemy());
    }
    
    private IEnumerator spawnenemy()
    {
        while (true) 
        {
            yield return new WaitForSeconds(1f);
            
            Instantiate(Enemy, new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f), 0), Quaternion.identity);
            Instantiate(Enemy2, new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f), 0), Quaternion.identity);

        }
       
    }
    private void Update()
    {
       
    }
}
