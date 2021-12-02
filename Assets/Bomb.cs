using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    bool isInCircle;
    bool dead;
    float limitTime;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        isInCircle = false;
        dead = false;
        limitTime = 5.0f;
        speed = -0.05f;
        Destroy(gameObject, 5.0f);

    }

    // Update is called once per frame
    void Update()
    {
        deadTime();
        if (dead == false)
        {
            walk();
        }
        else {
            Debug.Log("bomb");
        }
        

        
    }

    void deadTime(){
        limitTime -= Time.deltaTime;

        if (limitTime <= 0.0f) {
            dead = true;
        }
    }

    void walk()
    {
        if (transform.position.y >= 4)
        {
            speed = -0.05f;
        }
        else if (transform.position.y <= -4)
        {
            speed = 0.05f;
        }
        transform.Translate(0, speed, 0);
    }
}
