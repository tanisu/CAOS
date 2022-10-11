using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    
    private Rigidbody2D enemyRb2d;
    public float power;
    private float max_power;
    [SerializeField]
    private Sprite loseSprite;
    private float interval = 1.5f;
    private float startTimer = 0.0f;
    private Animator animator;
    private SpriteRenderer mainRenderer;
    private float enemyMass = 1.1f;

    void Start()
    {

        power = power + (GameManager.stage * 0.01f);
        max_power = 1f;
        mainRenderer = GetComponent<SpriteRenderer>();
        enemyRb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        enemyMass = enemyMass + (GameManager.stage * 0.1f);
        enemyRb2d.mass = enemyMass;
        
    }

    public float GetEnemyPower()
    {
        return power;
    }

    private void  EnemyPowerUp()
    {
        
        if (power < max_power)
        {
            power += 0.01f;
        }
        

    }

    private void Update()
    {
        
        if (GameManager.isStart)
        {
            animator.SetBool("isStart", true);
            
            startTimer += Time.deltaTime;
            if (startTimer >= interval)
            {
                
                EnemyPowerUp();
                startTimer = 0f;

            }
        }
        else if(!GameManager.isStart && GameManager.isEnd)
        {
            animator.enabled = false;
            Destroy(enemyRb2d);
        }
    }
    private void FixedUpdate()
    {
        if (GameManager.isStart)
        {
            enemyRb2d.AddForce(transform.right * power);
        }
    }

    public void Pulled(float playerPower)
    {
        enemyRb2d.AddForce(transform.right * playerPower * -1 , ForceMode2D.Impulse);
    }

    public void Loose()
    {
        animator.enabled = false;
        mainRenderer.sprite = loseSprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeadLine"))
        {
            //animator.enabled = false;
            //mainRenderer.sprite = loseSprite;
            //GameManager.instance.isWin = true;
            //if(GameManager.stage < (GameManager.instance.maxStage - 1))
            //{
            //    GameManager.instance.GameOver($"WIN\n次は{GameManager.stage + 1}回戦目！\nスペースキー");
            //}else if(GameManager.stage == (GameManager.instance.maxStage - 1))
            //{
            //    GameManager.instance.GameOver($"WIN\n次回ラスト フライト！\nスペースキー");
            //}
            //else if(GameManager.stage == GameManager.instance.maxStage)
            //{
            //    GameManager.instance.GameOver($"おめでとう！\nスペースキー");
            //}
            
        }
    }

}
