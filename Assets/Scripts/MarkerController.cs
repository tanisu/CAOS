using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerController : MonoBehaviour
{
    GameObject enemyObj,playerObj;
    
    private void Start()
    {
        enemyObj = GameObject.FindWithTag("Enemy");
        playerObj = GameObject.FindWithTag("Player");

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("playerWin"))
        {
            enemyObj.GetComponent<EnemyController>().Loose();
            GameManager.instance.isWin = true;
            if (GameManager.stage < (GameManager.instance.maxStage - 1))
            {
                GameManager.instance.GameOver($"WIN\n����{GameManager.stage + 1}���ځI\n�X�y�[�X�L�[");
            }
            else if (GameManager.stage == (GameManager.instance.maxStage - 1))
            {
                GameManager.instance.GameOver($"WIN\n���񃉃X�g �t���C�g�I\n�X�y�[�X�L�[");
            }
            else if (GameManager.stage == GameManager.instance.maxStage)
            {
                GameManager.instance.GameOver($"���߂łƂ��I\n�X�y�[�X�L�[");
            }
        }
        else if(collision.CompareTag("enemyWin"))
        {
            playerObj.GetComponent<PlayerController>().Loose();

            GameManager.instance.isWin = false;
            GameManager.instance.GameOver("LOSE\n�������������I\n�X�y�[�X�L�[");
        }
    }
}
