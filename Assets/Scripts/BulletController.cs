using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    void Update()
    {
        transform.position -= new Vector3(5f,3f,0)*Time.deltaTime;
    }
}
