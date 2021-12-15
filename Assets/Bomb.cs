using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {
    protected int SignBit;
    protected bool Touching;
    protected float LIMIT_TIME;
    public float MOVE_SPEED = 0.05f;
    public float MOVE_UPPER_LIMMIT = 4.0f;
    public float MOVE_LOWER_LIMMIT = -4.0f;
    protected bool countFlag;
    GameDirectior gameDirectior;


    protected void Start()
    {
        //�����l
        SignBit = 1;
        Touching = false;
        LIMIT_TIME = 5.0f;
        gameDirectior = GameObject.Find("Game Directior").GetComponent<GameDirectior>();
        countFlag = false;
    }


    protected void Update()
    {
        LIMIT_TIME -= Time.deltaTime;
        if (!IsInCircle()){
            if (!Touching && !IsDead())
            {
                Walk();
            }
            else if(IsDead()){
                Destroy(gameObject);
                gameDirectior.GameFlag = false;
            }    
        }

        if (IsInCircle() && !countFlag)
        {
            gameDirectior.CountScore();
            countFlag = true;
        }
    }


    void Walk(){
        float bombY = transform.position.y;
        if (bombY >= MOVE_UPPER_LIMMIT) {
            SignBit = -1;
        }else if (bombY <= MOVE_LOWER_LIMMIT) {
            SignBit = 1;
        }

        transform.Translate(0, SignBit * MOVE_SPEED, 0);
    }

    bool IsDead() {
        if (LIMIT_TIME <= 0.0f) {
            return true;
        }

        return false;  
    }


    protected virtual bool IsInCircle(){
        float bombX = transform.position.x;
        if (bombX < -7f){
            return true;
        }
        return false;
    }


    public void OnMouseDrag()
    {
        Touching = true;
        //Bomb�̈ʒu�����[���h���W����X�N���[�����W�ɕϊ����āAObjectPoint�Ɋi�[
        Vector3 objectPoint
           = Camera.main.WorldToScreenPoint(transform.position);

        //Bomb�̌��݈ʒu(�}�E�X�ʒu)���ApointScreen�Ɋi�[
        Vector3 pointScreen
            = new Vector3(Input.mousePosition.x,
                          Input.mousePosition.y,
                          objectPoint.z);

        //Bomb�̌��݈ʒu���A�X�N���[�����W���烏�[���h���W�ɕϊ����āApointWorld�Ɋi�[
        Vector3 pointWorld = Camera.main.ScreenToWorldPoint(pointScreen);
        pointWorld.z = transform.position.z;

        //Bomb�̈ʒu���ApointWorld�ɂ���
        transform.position = pointWorld;
    
    }
    public void OnMouseUp()
    {
        Touching = false;
    }

}
