﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resume : MonoBehaviour
{
    // Start is called before the first frame update
     Rigidbody rb;
     GameObject[] pauseObjects;
    
     public Vector3 movement;
     float z=0f;
      public AudioSource[] sounds;
 public AudioSource noise1;
 public AudioSource noise2;
  public AudioSource noise3;
  public AudioSource noise4;
  GameObject[] player;
    // Start is called before the first frame update
    void Start()
    {
    //Time.timeScale = 1;
	pauseObjects = GameObject.FindGameObjectsWithTag("pause");
   player =GameObject.FindGameObjectsWithTag("player");
   sounds= player[0].GetComponents<AudioSource>();;
noise1 = sounds[0];
 noise2 = sounds[1];
 noise3 = sounds[2];
 noise4 = sounds[3];    }

    // Update is called once per frame
    void Update()
    {
       
		
    }
    
        public void hidePaused(){
       
		foreach(GameObject g in pauseObjects){
			g.SetActive(false);
		}
         Time.timeScale = 1;
         noise3.Play();
	}
   private void OnCollisionExit(Collision collision){
      if(collision.gameObject.CompareTag("enemy")){
         Destroy(collision.gameObject);
    }}
    public void LoadLevel(string level){
		Application.LoadLevel(level);
	}
    
 /*    private void OnCollisionEnter(Collision collision){
      if(collision.gameObject.CompareTag("enemy")){
         Destroy(gameObject);
    }
     if(collision.gameObject.CompareTag("col")){
         Destroy(collision.gameObject);
    }
    }
    

     private void OnTriggerEnter(Collider other){
        Destroy(other.gameObject);
        // Destroy(GameObject.FindGameObject.g);
    }*/
     
    
    

}

