using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    float dx;
    float dy;
    private Renderer r;
    private void Start()
    {
        r = GetComponent<Renderer>();
    }
    public void Setting(float angle,float speed)
    {
        dx = Mathf.Cos(angle) * speed;
        dy = Mathf.Sin(angle) * speed;
    }
    void Update()
    {
        transform.position += new Vector3(dx,dy, 0) * Time.deltaTime;
        if (!r.isVisible)
        {
            Destroy(this.gameObject);
        }
    }
    
}
