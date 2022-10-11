using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneGenerator : MonoBehaviour
{

    [SerializeField]
    GameObject planePrefab;
    
    void Start()
    {
        if(GameManager.stage < 3) {
            InvokeRepeating("Spawn", 5f, 7f);
        }
        else
        {
            InvokeRepeating("Spawn", 5f, 6f);
        }
        
    }

    private void Update()
    {
        if (GameManager.isEnd)
        {
            CancelInvoke();
        }
    }

    void Spawn()
    {
        Vector3 spawnPositin = new Vector3(
            transform.position.x, 
            Random.Range(1f,3.8f),
            transform.position.z);
        Instantiate(planePrefab, spawnPositin, transform.rotation);
    }
}
