using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow_playernd : MonoBehaviour
{
    public GameObject player; 
    public Vector3 offset;
    // Start is called before the first frame update
    public Vector3 movement;
    // Start is called before the first frame update
 void Start () 
    {
       // movement =new Vector3(player.transform.position.x,player.transform.position.y, player.transform.position.z);
    
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position- player.transform.position;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate () 
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        //movement.z=player.transform.position.z;
        if(player!=null){
        transform.position = player.transform.position + offset;
    }}
        
    }