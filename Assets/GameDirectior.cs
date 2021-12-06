using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirectior : MonoBehaviour
{
    GameObject timer;
    float time;
    //public Text time2;


    // Start is called before the first frame update
    void Start()
    {
       this.timer = GameObject.Find("Timer");
    }

    // Update is called once per frame
    void Update()
    {
       time += Time.deltaTime;
       this.timer.GetComponent<Text>().text = time.ToString("F2");
    //    time2.text = time.ToString("F2");

    }
}
