using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour{
    private int SignBit;
    public float LIMIT_TIME = 5.0f;
    public float MOVE_SPEED = 0.05f;
    public float MOVE_UPPER_LIMMIT = 4.0f;
    public float MOVE_LOWER_LIMMIT = -4.0f;
    //デバッグで出力がうざいので。
    bool firstDebug = true;


    void Start()
    {
        //初期値
        SignBit = 1;
        Destroy(gameObject, LIMIT_TIME);
    }
    

    void Update()
    {
        //生死の確認
        if (!IsDead()) {
            Walk();
        }else {
            if(firstDebug) {
                Debug.Log("bomb");
                firstDebug = false;
            }
        }
    }


    void Walk(){
        //わざわざ変数にする必要はないかも？
        float bombY = transform.position.y;
        if (bombY >= MOVE_UPPER_LIMMIT) {
            SignBit = -1;
        }else if (bombY <= MOVE_LOWER_LIMMIT) {
            SignBit = 1;
        }

        transform.Translate(0, SignBit * MOVE_SPEED, 0);
    }

    bool IsDead() {
        LIMIT_TIME -= Time.deltaTime;
        if (LIMIT_TIME <= 0.0f) {
            return true;
        }

        return false;  
    }

    bool IsInCircle(){
        return false;
    }
}
