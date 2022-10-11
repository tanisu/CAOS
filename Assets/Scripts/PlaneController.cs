using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{

    [SerializeField]
    GameObject bulletPrefab;
    private Renderer r;

    void Start()
    {
        if (GameManager.stage < 3)
        {
            InvokeRepeating("Shot", 0.5f, 0.75f);
        }
        else
        {
            InvokeRepeating("Shot", 0.5f, 0.6f);
        }
        
        r = GetComponent<Renderer>();
    }

    
    void Update()
    {
        transform.position -= new Vector3(Time.deltaTime*2, 0f, 0f);
        if (!r.isVisible)
        {
            Destroy(this.gameObject);
        }
        if (GameManager.isEnd)
        {
            CancelInvoke();
        }
    }

    void Shot()
    {
        Instantiate(bulletPrefab,transform.position,transform.rotation);
    }
}
