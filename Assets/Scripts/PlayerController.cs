using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    GameObject marker;
    [SerializeField]
    private Sprite loseSprite;
    [SerializeField]
    private GameObject powerUp;

    public float power; //パワー
    
    private float addPower;//たされるパワー
    private Rigidbody2D rb2d;//プレイヤーのリジッドボディ
    private SpriteRenderer spriteRenderer;

    private GameObject enemy;
    private float enemyPower;
    private EnemyController enemyscript;
    private int push;
    
    private Vector3 diff;
    private Vector3 playerPosition;
    private Vector3 markerPosition;
    private Animator animator;
    
    private bool hitFlag;
    private bool powerUpFlag;
    private float flashAlpha;
    private Color flashCColor;
    private Color defaultColor;
    private float tmpPower;
    void Start()
    {
        

        
        push = 0;
        addPower = 0.01f;
        flashAlpha = 1f;
        hitFlag = false;
        powerUpFlag = false;
        
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        flashCColor = spriteRenderer.color;
        defaultColor = new Color(255, 255, 255, 255);

        enemy = GameObject.FindWithTag("Enemy");
        enemyPower = enemy.GetComponent<EnemyController>().power;
        enemyscript = enemy.GetComponent<EnemyController>();
        playerPosition = transform.position;
        markerPosition = marker.transform.position;
    }

    private void Update()
    {
        
        if (GameManager.isStart)
        {
            animator.SetBool("isStart", true);
            enemyPower = enemyscript.GetEnemyPower();
            diff = transform.position - playerPosition;
            marker.transform.position = markerPosition + diff;

            if (hitFlag && !powerUpFlag)
            {
                StartCoroutine("DamagedFlash");
            }
            if (powerUpFlag)
            {
                StartCoroutine("PowerUp");
            }
            

            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Return))
            {
                push++;
                if (push > 10)
                {
                    powerUpFlag = true;
                    power += addPower;
                    push = 0;
                    
                }
            }
        }
        else if(!GameManager.isStart && GameManager.isEnd)
        {
            animator.enabled = false;
            Destroy(rb2d);
        }
    }

    private void FixedUpdate()
    {
        if (GameManager.isStart)
        {
            rb2d.AddForce(transform.right * enemyPower);
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Return))
            {
 


                rb2d.AddForce((transform.right * power * -1 ), ForceMode2D.Impulse);
                enemyscript.Pulled(power);
            }
        }
    }

    public void Loose()
    {
        animator.enabled = false;
        spriteRenderer.sprite = loseSprite;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Bullet") || collision.CompareTag("Zombie") || collision.CompareTag("Fire"))
        {
            push = 0;
            if (hitFlag == false)
            {
                tmpPower = power;
                if (collision.CompareTag("Bullet"))
                {
                    power = -0.1f;
                }else if (collision.CompareTag("Zombie"))
                {
                    power = -0.15f;
                }else if (collision.CompareTag("Fire"))
                {
                    power = -0.3f;
                }
                
                hitFlag = true;
            }
            
        }
    }

    





    IEnumerator PowerUp()
    {  
        powerUp.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        powerUp.SetActive(false);
        powerUpFlag = false;
    }
    IEnumerator DamagedFlash()
    {
        flashAlpha = Mathf.Sin(Time.time * 100) / 2 + 0.5f;

        flashCColor.a = flashAlpha;
        spriteRenderer.color = flashCColor;
        
        
        yield return new WaitForSeconds(1f);
        spriteRenderer.color = defaultColor;

        power = tmpPower;
        hitFlag = false;
    }
}
