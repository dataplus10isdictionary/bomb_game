using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BombPrefab : MonoBehaviour
{
    public GameObject bomb_pre;
    public float INTERVAL_TIME = 6.0f;
    private float countDown;
    public float X = 0;

    

    void Start()
    {
        countDown = 0.0f;

    }


    void Update()
    {
        bool gameFlag = GameObject.Find("Game Directior").GetComponent<GameDirectior>().GameFlag;
        if (gameFlag) {
            countDown -= Time.deltaTime;
            if (countDown <= 0f) {
                Instantiate(bomb_pre, new Vector3(X, 0, 0), Quaternion.identity);
                countDown = INTERVAL_TIME;
            }
        }
        else
        {
            GameObject.Find("Game Directior").GetComponent<GameDirectior>().GameOver();
        }
    }
}
