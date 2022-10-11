using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2Controller : MonoBehaviour
{
    private Renderer r;

    private void Start()
    {
        r = GetComponent<Renderer>();
    }

    void Update()
    {
        transform.position -= new Vector3(6f, 0, 0) * Time.deltaTime;
        if (!r.isVisible)
        {
            Destroy(this.gameObject);
        }
        if(transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }
}
