using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red_bomb : Bomb
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }

    protected override bool IsInCircle(){
        float bombX = transform.position.x;
        if (bombX > 7f)
        {
            return true;
        }
        return false;
    }
}
