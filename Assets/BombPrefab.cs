using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BombPrefab : MonoBehaviour
{
    public GameObject bomb_pre;
    //6.0fは要修正
    public float INTERVAL_TIME = 6.0f;
    private float countDown;

    void Start()
    {
        countDown = INTERVAL_TIME;
    }


    void Update()
    {
        countDown -= Time.deltaTime;
        if (countDown <= 0f) {
            Instantiate(bomb_pre, new Vector3(0, 0, 0), Quaternion.identity);
            countDown = INTERVAL_TIME;
        }

        //１秒ごとの処理じゃない気がする、、、
        //if (Time.frameCount % 60 == 0) {
        //    Vector3 pos = new Vector3(0, 0, 0);
        //    Instantiate(bomb_pre, pos, Quaternion.identity);
        //}
    }
}
