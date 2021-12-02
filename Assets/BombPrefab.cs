using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombPrefab : MonoBehaviour
{
    public GameObject bomb_pre;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount % 60 == 0) {
            Vector3 pos = new Vector3(0, 0, 0);
            Instantiate(bomb_pre, pos, Quaternion.identity);
        }
    }
}
