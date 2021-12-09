using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour{
    int SignBit;
    bool Touching;
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
        Touching = false;
        Destroy(gameObject, LIMIT_TIME);
    }
    

    void Update()
    {
        //生死の確認
        if (!IsDead() && (Touching==false) ) {
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

    public void OnMouseDrag()
    {
        Touching = true;
        //Bombの位置をワールド座標からスクリーン座標に変換して、ObjectPointに格納
        Vector3 objectPoint
           = Camera.main.WorldToScreenPoint(transform.position);

        //Bombの現在位置(マウス位置)を、pointScreenに格納
        Vector3 pointScreen
            = new Vector3(Input.mousePosition.x,
                          Input.mousePosition.y,
                          objectPoint.z);

        //Bombの現在位置を、スクリーン座標からワールド座標に変換して、pointWorldに格納
        Vector3 pointWorld = Camera.main.ScreenToWorldPoint(pointScreen);
        pointWorld.z = transform.position.z;

        //Bombの位置を、pointWorldにする
        transform.position = pointWorld;
    
    }
    public void OnMouseUp()
    {
        Touching = false;
    }

}
