using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirectior : MonoBehaviour
{
    GameObject timer;
    float time;
    public bool GameFlag;
    public Text TextGameOver;
    public Text TextScore;
    public GameObject btn;
    public GameObject QuitBtn;
    int Score;

    void Start()
    {
        this.timer = GameObject.Find("Timer");
        GameFlag = true;
        btn.SetActive(false);
        QuitBtn.SetActive(false);
        Score = 0;
        Time.timeScale = 1f;
    }


    void Update()
    {
        time += Time.deltaTime;
        this.timer.GetComponent<Text>().text = time.ToString("F2");
        TextScore.text = "Score:" + Score.ToString();
    }

    public void GameOver() {
        Time.timeScale = 0f;
        TextGameOver.text = "GameOver";
        btn.SetActive(true);
        QuitBtn.SetActive(true);
    }

    public void CountScore()
    {
        Score++;
    }

    public float GetTime()
    {
        return time;
    }
}
