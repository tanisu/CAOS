using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject enemyPrefab;
    [SerializeField]
    GameObject zombiePrefab;
    [SerializeField]
    GameObject shooterPrefab;
    [SerializeField]
    GameObject marker;
    void Start()
    {
        
        Instantiate(enemyPrefab, transform.position, transform.rotation);
        if(GameManager.stage > 1)
        {
            InvokeRepeating("Spawn", 5f, 10f);
            
        }
        if (GameManager.stage > 2)
        {
            Instantiate(shooterPrefab, new Vector3(
            marker.transform.position.x - 0.1f,
            marker.transform.position.y - 0.1f,
            marker.transform.position.z
            ), marker.transform.rotation, marker.transform);
        }


    }

    private void Spawn()
    {
        Instantiate(zombiePrefab, new Vector3(-12f, transform.position.y, transform.position.z), transform.rotation);
    }


}
