using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirPlaneController : MonoBehaviour
{

    [SerializeField]
    private FireController fireBulletPrefab;
    void Start()
    {
        if (GameManager.stage > 3)
        {
            InvokeRepeating("ShotN", 5f, 3.5f);
            //ShotN(16, 2.5f);
        }

}

    void Shot(float angle ,float speed)
    {
        FireController bullet = Instantiate(fireBulletPrefab, transform.position, transform.rotation);
        bullet.Setting(angle,speed);
    }
    
    void ShotN()
    {
        int count = 16; 
        float speed = 2.5f;
        int bulletCount = count;
        for (int i = 0; i < bulletCount; i++)
        {
            if(i > 3 && i < 9)
            {
                float s = (i * 0.11f) + 1;

                float angle = (2 * Mathf.PI / s);
                Shot(angle, speed);
            }
            
        }
    }
}
