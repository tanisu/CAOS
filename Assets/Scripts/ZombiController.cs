using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ZombiController : MonoBehaviour
{
    [SerializeField]
    Text endingText1;
    [SerializeField]
    GameObject endingText2;
    private bool playerHit;
    private float flashAlpha;
    private Color flashCColor;
    private SpriteRenderer spriteRenderer;
    
    void Start()
    {
        playerHit = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        flashCColor = spriteRenderer.color;
    }

    
    void Update()
    {
        if (GameManager.isStart)
        {
            if (playerHit)
            {
                StartCoroutine("DamagedFlash");
            }
            transform.position += new Vector3(Time.deltaTime * 1, 0f, 0f);
        }
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerHit = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            endingText1.text = "Ç®Å@Ç¶Å@ÇË";
            endingText2.SetActive(true);
;            //endingText.SetActive(true);
        }
    }


    IEnumerator DamagedFlash()
    {
        flashAlpha = Mathf.Sin(Time.time * 100) / 2 + 0.5f;

        flashCColor.a = flashAlpha;
        spriteRenderer.color = flashCColor;
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }
}
