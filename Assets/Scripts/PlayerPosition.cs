using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    public static Vector3 pos;
    public bool player;
    // Start is called before the first frame update
    void Start()
    {
        if(player){
            pos=transform.position;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player){
            pos=transform.position;
        }
    }
}
