using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BombPrefab : MonoBehaviour
{
    public GameObject bomb_pre;
    public float INTERVAL_TIME;
    private float countDown;
    int n;
    bool SpeedFlag;
    



    void Start()
    {
        countDown = 0.0f;
        INTERVAL_TIME = 6.0f;
        n = 1;
        SpeedFlag = true;

    }


    void Update()
    {
        float time = GameObject.Find("Game Directior").GetComponent<GameDirectior>().GetTime();
        if (time >= 10*n && SpeedFlag == true && time <50) {
            n += 1;
            SpeedFlag = false;
            INTERVAL_TIME -= 1.0f; }
        
        if(time >= 10 * (n - 1) + 1){
            SpeedFlag = true;
        }
        


        float X = Random.Range(-5.6f, 5.6f);
        float Y = Random.Range(-3,3);
        bool gameFlag = GameObject.Find("Game Directior").GetComponent<GameDirectior>().GameFlag;
        if (gameFlag) {
            countDown -= Time.deltaTime;
            if (countDown <= 0f) {
                Instantiate(bomb_pre, new Vector3(X, Y, 0), Quaternion.identity);
                countDown = INTERVAL_TIME;
            }
        }
        else
        {
            GameObject.Find("Game Directior").GetComponent<GameDirectior>().GameOver();
        }
    }
}
