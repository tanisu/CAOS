using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimerController : MonoBehaviour
{
    public Text timerText;
    public int totalTime;
    int secondes;
    
    void Start()
    {
        if(GameManager.stage < GameManager.instance.maxStage)
        {
            timerText.text = $"{GameManager.stage}回戦\n\nレディー";
        }
        else　if(GameManager.stage == GameManager.instance.maxStage)
        {
            timerText.text = $"ラストフライト\n\nレディー";
        }
        
        StartCoroutine("CountDown",totalTime);
    }

    IEnumerator CountDown(int len)
    {
        yield return new WaitForSeconds(1f);
        AudioController.I.CountDown();
        
        for (int i = 0;i <= len; i++)
        {

            secondes = totalTime -  i;
            if(secondes == 0)
            {
                timerText.text = "ゴー！";
                GameManager.isStart = true;
            }
            else
            {
                timerText.text = secondes.ToString();
            }
            
            yield return new WaitForSeconds(1f);
        }
        yield return new WaitForSeconds(0.3f);
        timerText.text = "";
        if (!GameManager.isBGM)
        {
            AudioController.I.Fight();
            GameManager.isBGM = true;
        }
        
    }

}
