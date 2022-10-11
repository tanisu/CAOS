using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterController : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;
    private float minY;
    private float maxY;
    private float nowY;
    private bool upMove;
    private void Start()
    {
        upMove = true;
        minY = -0.1f;
        maxY = 0.18f;
        nowY = transform.localPosition.y;
        
        InvokeRepeating("Move",0.1f,0.1f);
        
    }

    void Move()
    {
        if (GameManager.isStart)
        {
            if(transform.localPosition.y <= maxY && upMove)
            {
                nowY += 0.01f;
            }
            if(transform.localPosition.y > maxY)
            {
                Shot();
                upMove = false;
            }
            if(transform.localPosition.y >= minY && !upMove)
            {
                nowY -= 0.01f;
            }
            if(transform.localPosition.y < minY)
            {
                upMove = true;
            }
            transform.localPosition = new Vector3(transform.localPosition.x, nowY, transform.localPosition.z);
        }else if (GameManager.isEnding)
        {
            Shot();
        }
        
    }
    void Shot()
    {
        
        GameObject bullet =  Instantiate(bulletPrefab, new Vector3 (transform.position.x - 0.05f,transform.position.y - 0.55f,transform.position.z), transform.rotation);
        if (GameManager.isEnding)
        {
            bullet.GetComponent<CircleCollider2D>().isTrigger = false;
        }
    }
}
