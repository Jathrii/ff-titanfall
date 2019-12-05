using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script should be attached to all titans and pilots
//isPlayer should be set to true is it is attached to a player pilot/titan
public class PlayerPos : MonoBehaviour
{
    public static Vector3 pos;
    public bool isPlayer;
    // Start is called before the first frame update
    void Start()
    {
        if(isPlayer)
        pos=transform.position;

        
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayer)
        pos=transform.position;
    }
}
