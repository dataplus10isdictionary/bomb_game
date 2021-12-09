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
    //�f�o�b�O�ŏo�͂��������̂ŁB
    bool firstDebug = true;
    


    void Start()
    {
        //�����l
        SignBit = 1;
        Touching = false;
        Destroy(gameObject, LIMIT_TIME);
    }
    

    void Update()
    {
        //�����̊m�F
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
        //�킴�킴�ϐ��ɂ���K�v�͂Ȃ������H
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
