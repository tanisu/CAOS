using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject gameOverText;
    
    public int maxStage { get; private set; }


    public static GameManager instance;
    public static bool isStart;
    public static bool isEnd;
    public static int stage;
    public bool isWin;
    public static bool isEnding;
    public static bool isBGM = false;
    


    
    private void Awake()
    {
        instance = this;
        maxStage = 4;
        //isEnding = true;
    }

    void Start()
    {
        isStart = false;
        isEnd = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isEnding)
        {
            stage = 0;
            AudioController.I.AudioStop();
            isEnding = false;
            isBGM = false;
            SceneManager.LoadScene("Title");
        }
        if (isEnd)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {

                if (stage > maxStage)
                {
                    AudioController.I.AudioStop();
                    AudioController.I.Ending();
                    isEnding = true;
                    SceneManager.LoadScene("Ending");
                }
                else {
                    SceneManager.LoadScene("Main");
                }
                
            }
        }
    }

 

    public void GameOver(string str = "GameOver")
    {
        isStart = false;
        isEnd = true;
        
        gameOverText.GetComponent<Text>().text = str;
        gameOverText.SetActive(true);
        if (isWin)
        {
            
            stage++;
            
            
            AudioController.I.Win();
        }
        else
        {
            AudioController.I.Lose();
        }
        
    }

    public void OnClickStartButton()
    {
        AudioController.I.StartVoice();
        SceneManager.LoadScene("Main");
        stage = 1;
    }


}
