using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Events : MonoBehaviour
{

    public static Events current;
    public event Action onStopMoving;
    public event Action onStartMoving;
    private void Awake()
    {
        current=this;
    }

    // Update is called once per frame
   
   public void StopMoving()
   {
       if (onStopMoving!=null)
       {
           onStopMoving();
       }
   }
     public void StartMoving()
   {
       if (onStartMoving!=null)
       {
           onStartMoving();
       }
   }
}
